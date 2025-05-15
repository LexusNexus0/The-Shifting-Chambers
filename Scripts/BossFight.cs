using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D fireball;
    public float fireballSpeed = 2;

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
    }

    public void fireBall()
    {
        Rigidbody2D fireBallClone = (Rigidbody2D)Instantiate(fireball, transform.position, transform.rotation);
        Vector3 playerPos = player.transform.position - this.transform.position;
        fireBallClone.velocity = new Vector2(playerPos.x, playerPos.y).normalized * fireballSpeed;
        Destroy(fireBallClone.gameObject, 3.0f);
    }
}
