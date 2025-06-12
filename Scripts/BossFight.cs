using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossFight : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D fireball;
    public Rigidbody2D miniFireball;
    public float fireballSpeed = 2;
    private Vector3 fireLocation = Vector2.zero;
    private Vector3 arm1pos = new Vector2(-20.65f, 5.65f);
    private Vector3 arm2pos = new Vector2(20.65f, 5.65f);
    private Vector3 arm3pos = new Vector2(20.65f, -5.65f);
    private Vector3 arm4pos = new Vector2(-20.65f, -5.65f);

    private bool arm1inuse = false;
    private bool arm2inuse = false;
    private bool arm3inuse = false;
    private bool arm4inuse = false;

    public GameObject laser1;
    public GameObject laser2;
    private Color laserDim = new Color(1.0f, 0.5f, 0.5f, 0.7f);
    private Color laserFull = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    private float fightTimer = 0.0f;
    private string displayTime = "0:00";
    private string prevTime = "0:00";
    public TMP_Text displayTimer;
    public float bossHealth = 100.0f;
    public TMP_Text displayHealth;
    public int activeBatteries = 4;

    public List<GameObject> Doors = new() { };
    public bool fightStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // player.GetComponent<PlayerMovement>().moveLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        fightTimer += Time.deltaTime;
        DisplayTime();
        if (prevTime != displayTime)
        {
            if (bossHealth < 100)
            {
                bossHealth += (5 * activeBatteries);
            }

            if (bossHealth > 100)
            {
                bossHealth = 100;
            }
            prevTime = displayTime;
        }
        displayHealth.text = "Boss Health: " + bossHealth.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireBall();
            fightStarted = !fightStarted;
            ChangeDoorState();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            int rNum = Random.Range(1, 3);
            switch (rNum)
            {
                case 1:
                    startLaser(laser1);
                    arm1inuse = true;
                    arm3inuse = true;
                    break;
                case 2:
                    startLaser(laser2);
                    arm2inuse = true;
                    arm4inuse = true;
                    break;
            }
            
        }

    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(fightTimer / 60);
        int seconds = Mathf.FloorToInt(fightTimer % 60);
        displayTime = string.Format("{0}:{1:00}", minutes, seconds);
        displayTimer.text = displayTime;
    }

    public void fireBall()
    {
        bossHealth -= 5;
        int ranNum = Random.Range(1, 6);
        if (ranNum == 1 && !arm1inuse)
        {
            fireLocation = arm1pos;
        }
        else if (ranNum == 2 && !arm2inuse)
        {
            fireLocation = arm2pos;
        }
        else if (ranNum == 3 && !arm3inuse)
        {
            fireLocation = arm3pos;
        }
        else if (ranNum == 4 && !arm4inuse)
        {
            fireLocation = arm4pos;
        }
        else
        {
            fireLocation = transform.position;
        }

        Rigidbody2D fireBallClone = (Rigidbody2D)Instantiate(fireball, fireLocation, transform.rotation);
        Vector3 playerPos = player.transform.position - fireLocation;
        fireBallClone.velocity = new Vector2(playerPos.x, playerPos.y).normalized * fireballSpeed;
        Destroy(fireBallClone.gameObject, 3.0f);
    }

    public void startLaser(GameObject laser)
    {
        laser.GetComponent<Renderer>().material.color = laserDim;
        laser.SetActive(true);
        StartCoroutine(DelayFire(2.5f, laser));
    }

    public void fireLaser(GameObject laser)
    {
        laser.GetComponent<Renderer>().material.color = laserFull;
    }

    IEnumerator DelayFire(float delay, GameObject laser)
    {
        yield return new WaitForSeconds(delay);
        fireLaser(laser);
    }

    public void disableLaser(GameObject laser)
    {
        laser.SetActive(false);
        if (laser == laser1)
        {
            arm1inuse = false;
            arm3inuse = false;
        }
        else if (laser == laser2)
        {
            arm2inuse = false;
            arm4inuse = false;
        }
    }

    public void SprayFireballs(Vector3 armPos)
    {

    }

    private void ChangeDoorState()
    {
        for (int i = 0; i < Doors.Count; i++)
        {
            Doors[i].GetComponent<Animator>().SetBool("BattleStart", fightStarted);
            Doors[i].GetComponent<BoxCollider2D>().enabled = fightStarted;
        }
    }
}
