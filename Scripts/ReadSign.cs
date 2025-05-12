using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadSign : MonoBehaviour
{
    public GameObject signText;
    public bool playerColliding = false;

    void Update()
    {
        if (playerColliding && Input.GetKeyDown(KeyCode.E))
        {
            signText.SetActive(!signText.activeSelf);
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
