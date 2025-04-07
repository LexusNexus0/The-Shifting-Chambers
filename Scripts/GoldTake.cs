using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTake : MonoBehaviour
{
    public GameObject GoldQuestion;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeGold()
    {
        GoldQuestion.SetActive(false);
        RoomManager.clearRooms();
        Debug.Log("Gold taken.");
        RoomManager.generateRandomDoorway();
        player.GetComponent<RandomManager>().isRandom = true;
        this.gameObject.SetActive(false);
    }


    public void NotTakeGold()
    {
        GoldQuestion.SetActive(false);
        Debug.Log("Gold left");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            GoldQuestion.SetActive(true);
            other.gameObject.transform.position = new Vector2(0, -2.5f);
        }
        
    }
}
