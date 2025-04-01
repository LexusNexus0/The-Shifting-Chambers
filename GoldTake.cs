using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTake : MonoBehaviour
{
    public GameObject GoldQuestion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeGold()
    {
        GoldQuestion.SetActive(false);
        RoomManager.clearRooms();
        Debug.Log("Gold taken.");
        RoomManager.StartRandomiser = true;
        RoomManager.generateRandomDoorway();
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
