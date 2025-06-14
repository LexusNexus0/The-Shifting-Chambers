using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class BossFight : MonoBehaviour
{
    public GameObject player;
    public GameObject dummy;
    public Rigidbody2D fireball;
    public Rigidbody2D miniFireball;
    public float fireballSpeed;
    private Vector3 fireLocation = Vector2.zero;
    private Vector3 arm1pos = new Vector2(-20, 4.875f);
    private Vector3 arm2pos = new Vector2(20, 4.875f);
    private Vector3 arm3pos = new Vector2(20, -4.875f);
    private Vector3 arm4pos = new Vector2(-20, -4.875f);

    public bool redGemAquired = false;
    public bool blueGemAquired = false;
    public bool greenGemAquired = false;

    private bool arm1inuse = false;
    private bool arm2inuse = false;
    private bool arm3inuse = false;
    private bool arm4inuse = false;

    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    private Color laserDim = new Color(1.0f, 0.0f, 0.0f, 0.7f);
    private Color laserFull = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private int lasersActive = 0;

    public float currentBossHealth = 100.0f;
    public float maxBossHealth = 100.0f;
    public Slider bossHeathBar;
    public int activeBatteries;
    private Coroutine regening;

    public List<GameObject> Doors = new() { };
    public List<GameObject> Batteries = new() { };
    public List<GameObject> BossArms = new() { };
    public List<Vector3> FinalArmPos = new() { new Vector3(-24, -9, 0), new Vector3(-24, 9, 0), new Vector3(24, 9, 0), new Vector3(24, -9, 0) };
    private bool doorsClosed = false;
    public bool fightStarted = false;
    public bool randomiserOn = false;
    private bool playerInPos = false;
    private bool playerSwitched = false;
    private Animator bossAnimator;

    private float cooldown = 2.0f;
    private float nextAttack;
    private float battleTimer = 0.0f;
    public GameObject bigLaser;
    private bool laserFired = false;
    private bool doneFinalAttack = false;
    private bool battleFinished = false;
    public bool bossDead = false;

    public GameObject playerHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossAnimator = GetComponent<Animator>();
        fireballSpeed = 15;
        activeBatteries = 5;
    }

    // Update is called once per frame
    void Update()
    {
        bossHeathBar.value = currentBossHealth;

        // Runs once the player enters the room and the randomiser is on.
        // Disables the player's movement and switches them out for a dummy for a cutscene.
        if (randomiserOn && !fightStarted && !playerSwitched && !battleFinished)
        {
            player.GetComponent<PlayerMovement>().moveLocked = true;
            dummy.transform.position = player.transform.position;
            dummy.SetActive(true);
            player.SetActive(false);
            playerSwitched = true;
        }

        // Runs once the player has been switched out for the dummy in the previous code block.
        // Moves the dummy and invisible player closer to the boss then runs the awaken cutscene.
        if (playerSwitched)
        {
            if (!playerInPos)
            {
                float step = 5 * Time.deltaTime;
                dummy.transform.position = Vector3.MoveTowards(dummy.transform.position, new Vector3(8.5f, 0, player.transform.position.z), step);
                player.transform.position = dummy.transform.position;

                if (dummy.transform.position == new Vector3(8.5f, 0, player.transform.position.z))
                {
                    playerInPos = true;
                    bossAnimator.SetBool("BattleBegin", true);
                    ChangeDoorState();
                    StartCoroutine(WatchAwakenCutscene());
                }
            }
        }

        // Runs once the battle has started.
        if (fightStarted && !doneFinalAttack)
        {
            battleTimer += Time.deltaTime;
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + cooldown;
                int rNum = Random.Range(1, 9);
                if (rNum >= 7 && currentBossHealth > 50)
                {
                    FireLaser();
                }
                else
                {
                    fireBall();
                }
            }

            if (battleTimer > 60)
            {
                cooldown = 0.5f;
            }
            else if (battleTimer > 30)
            {
                cooldown = 1.0f;
            }
            else if (battleTimer > 15)
            {
                cooldown = 1.5f;
            }

            if (activeBatteries == 2 && !laserFired)
            {
                laserFired = true;
                StartCoroutine(FireBigLaser());
            }

            if (activeBatteries == 1 && currentBossHealth < 33) 
            {
                StartCoroutine(FireBigLaser());
                StartCoroutine(FinalAttack());
                doneFinalAttack = true;
            }
        }

        if (currentBossHealth <= 0  && !battleFinished)
        {
            if (!doneFinalAttack)
            {
                currentBossHealth = 5;
            }
            else
            {
                fightStarted = false;
                ChangeDoorState();
                bigLaser.SetActive(false);
                currentBossHealth = 0;
                battleFinished = true;
                player.GetComponent<RandomManager>().bossDead = true;
                bossAnimator.SetBool("DeadBoss", bossDead);
                StartCoroutine(RemoveArms());
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireBall();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            FireLaser();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            randomiserOn = !randomiserOn;
        }

        if (bossDead)
        {
            bossAnimator.SetBool("DeadBoss", bossDead);
            DeactivateBatteries();
            DeactivateArms();
        }
    }

    public void fireBall()
    {
        currentBossHealth -= 5;
        if (regening == null)
        {
            regening = StartCoroutine(RegenBossHealth());
        }
        
        List<int> firePoints = new List<int> { 1, 2, 3, 4, 5 };

        // Shuffle the list
        for (int i = 0; i < firePoints.Count; i++)
        {
            int swapIndex = Random.Range(i, firePoints.Count);
            int temp = firePoints[i];
            firePoints[i] = firePoints[swapIndex];
            firePoints[swapIndex] = temp;
        }  

        foreach (int i in firePoints)
        {
            if (i == 1 && !arm1inuse)
            {
                fireLocation = arm1pos;
                break;
            }
            else if (i == 2 && !arm2inuse)
            {
                fireLocation = arm2pos;
                break;
            }
            else if (i == 3 && !arm3inuse)
            {
                fireLocation = arm3pos;
                break;
            }
            else if (i == 4 && !arm4inuse)
            {
                fireLocation = arm4pos;
                break;
            }
            else if (i == 5)
            {
                fireLocation = new Vector2(transform.position.x - 2.1f, transform.position.y);
                break;
            }
        }

        Vector3 playerPos = player.transform.position - fireLocation;
        Rigidbody2D fireBallClone = Instantiate(fireball, fireLocation, Quaternion.identity);
        float rot = Mathf.Atan2(-playerPos.y, -playerPos.x) * Mathf.Rad2Deg;
        fireBallClone.transform.rotation = Quaternion.Euler(0, 0, rot);
        fireBallClone.velocity = new Vector2(playerPos.x, playerPos.y).normalized * fireballSpeed;
        Destroy(fireBallClone.gameObject, 4.0f);
    }

    private void FireLaser()
    {
        List<int> laserIndices = new List<int> { 1, 2, 3, 4 };

        // Shuffle the list so the first pick is random, and order is random
        for (int i = 0; i < laserIndices.Count; i++)
        {
            int swapIndex = Random.Range(i, laserIndices.Count);
            int temp = laserIndices[i];
            laserIndices[i] = laserIndices[swapIndex];
            laserIndices[swapIndex] = temp;
        }

        bool fired = false;

        foreach (int i in laserIndices)
        {
            if (i == 1 && !arm1inuse)
            {
                startLaser(laser1);
                arm1inuse = true;
                fired = true;
                break;
            }
            else if (i == 2 && !arm2inuse)
            {
                startLaser(laser2);
                arm2inuse = true;
                fired = true;
                break;
            }
            else if (i == 3 && !arm3inuse)
            {
                startLaser(laser3);
                arm3inuse = true;
                fired = true;
                break;
            }
            else if (i == 4 && !arm4inuse)
            {
                startLaser(laser4);
                arm4inuse = true;
                fired = true;
                break;
            }
        }

        if (!fired)
        {
            fireBall();
        }
    }
    
    private void startLaser(GameObject laser)
    {
        laser.GetComponent<Renderer>().material.color = laserDim;
        laser.SetActive(true);
        StartCoroutine(DelayFire(2.5f, laser));
    }

    IEnumerator DelayFire(float delay, GameObject laser)
    {
        yield return new WaitForSeconds(delay);
        laser.GetComponent<Renderer>().material.color = laserFull;
        lasersActive++;
        StartCoroutine(DepleteBossHealth());
        if (regening == null)
        {
            regening = StartCoroutine(RegenBossHealth());
        }

        yield return new WaitForSeconds(5f);
        laser.SetActive(false);
        lasersActive--;
        int laserNum = laser.name[5] - '0';
        switch (laserNum)
        {
            case 1:
                arm1inuse = false;
                break;
            case 2:
                arm2inuse = false;
                break;
            case 3:
                arm3inuse = false;
                break;
            case 4:
                arm4inuse = false;
                break;
        }
            
    }

    private void ChangeDoorState()
    {
        doorsClosed = !doorsClosed;
        for (int i = 0; i < Doors.Count; i++)
        {
            Doors[i].GetComponent<Animator>().SetBool("BattleStart", doorsClosed);
            Doors[i].GetComponent<BoxCollider2D>().enabled = doorsClosed;
        }
    }

    private IEnumerator DepleteBossHealth()
    {
        while (lasersActive >= 1)
        {
            currentBossHealth -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator RegenBossHealth()
    {
        yield return new WaitForSeconds(1f);

        while (currentBossHealth < maxBossHealth && fightStarted)
        {
            currentBossHealth += activeBatteries * 0.75f;
            if (currentBossHealth > maxBossHealth)
            {
                currentBossHealth = maxBossHealth;
            }
            yield return new WaitForSeconds(0.1f);
        }

        regening = null;
    }

    private IEnumerator WatchAwakenCutscene()
    {
        yield return new WaitForSeconds(3f);
        player.SetActive(true);
        dummy.SetActive(false);
        playerHealthbar.SetActive(true);
        bossHeathBar.gameObject.SetActive(true);
        player.GetComponentInChildren<PlayerHealth>().healthReady = true;
        // insert code to do with gems here
        player.GetComponent<PlayerMovement>().moveLocked = false;
        yield return new WaitForSeconds(1);
        fightStarted = true;
        playerSwitched = false;
    }

    private IEnumerator FireBigLaser()
    {
        while (bigLaser.transform.position != new Vector3(0, 0, 0))
        {
            float step = 5 * Time.deltaTime;
            bigLaser.transform.position = Vector3.MoveTowards(bigLaser.transform.position, new Vector3(0, 0, 0), step);
            yield return null;
        }
        yield return new WaitForSeconds(5f);
        bigLaser.transform.position = new Vector3(-26, 0, 0);
    }

    private IEnumerator FinalAttack()
    {
        while (currentBossHealth > 0)
        {
            for (int i = 1; i < 5; i++)
            {
                currentBossHealth -= 2.5f;
                switch (i)
                {
                    case 1:
                        fireLocation = arm1pos;
                        break;
                    case 2:
                        fireLocation = arm2pos;
                        break;
                    case 3:
                        fireLocation = arm3pos;
                        break;
                    case 4:
                        fireLocation = arm4pos;
                        break;
                }
             
                Vector3 playerPos = player.transform.position - fireLocation;
                Rigidbody2D fireBallClone = Instantiate(fireball, fireLocation, Quaternion.identity);
                float rot = Mathf.Atan2(-playerPos.y, -playerPos.x) * Mathf.Rad2Deg;
                fireBallClone.transform.rotation = Quaternion.Euler(0, 0, rot);
                fireBallClone.velocity = new Vector2(playerPos.x, playerPos.y).normalized * fireballSpeed;
                Destroy(fireBallClone.gameObject, 4.0f);

                yield return new WaitForSeconds(0.25f);
            }
        }
    }

    private void DeactivateBatteries()
    {
        for (int i = 0; i < Batteries.Count; i++)
        {
            Batteries[i].GetComponent<Animator>().SetBool("BatteryDestroyed", true);
        }
    }

    private IEnumerator RemoveArms()
    {
        while (BossArms[0].transform.position != FinalArmPos[0])
        {
            for (int i = 0; i < BossArms.Count; i++)
            {
                float step = 1 * Time.deltaTime;
                BossArms[i].transform.position = Vector3.MoveTowards(BossArms[i].transform.position, FinalArmPos[i], step);
            }
            yield return null;
        }
        bossDead = true;
    }

    private void DeactivateArms()
    {
        for (int i = 0; i < BossArms.Count; i++)
        {
            BossArms[i].SetActive(false);
        }
    }
}
