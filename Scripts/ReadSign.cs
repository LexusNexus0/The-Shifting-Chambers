using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadSign : MonoBehaviour
{
    public GameObject signText;
    public bool playerColliding = false;
    public GameObject player;
    private bool hasRan = false;
    public bool leaveRoom;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerColliding && Input.GetKeyDown(KeyCode.E))
        {
            signText.SetActive(!signText.activeSelf);
            player.GetComponent<PlayerMovement>().moveLocked = signText.activeSelf;

            if (leaveRoom && !hasRan)
            {
                hasRan = true;
                player.GetComponent<RandomManager>().doorOpen = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerColliding = false;
        }
    }
}
