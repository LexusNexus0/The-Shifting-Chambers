using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D fireball;
    public float fireballSpeed = 2;
    private Vector3 fireLocation = Vector2.zero;
    private Vector3 arm1pos = new Vector2(-12.82f, 3.93f);
    private Vector3 arm2pos = new Vector2(12.82f, 3.93f);
    private Vector3 arm3pos = new Vector2(12.82f, -3.93f);
    private Vector3 arm4pos = new Vector2(-12.82f, -3.93f);

    public GameObject laser1;
    public GameObject laser2;
    private Color laserDim = new Color(1.0f, 0.5f, 0.5f, 0.7f);
    private Color laserFull = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // player.GetComponent<PlayerMovement>().moveLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireBall();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            int rNum = Random.Range(1, 3);
            switch (rNum)
            {
                case 1:
                    startLaser(laser1);
                    break;
                case 2:
                    startLaser(laser2);
                    break;
            }
            
        }

    }

    public void fireBall()
    {
        int ranNum = Random.Range(1, 6);
        switch (ranNum)
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
            case 5:
                fireLocation = transform.position;
                break;
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
        StartCoroutine(DelayFire(3f, laser));
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
}
