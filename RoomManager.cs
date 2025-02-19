using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public bool StartRandomiser = false;
    public GameObject player;
    public string roomNumber = "17";
    public bool enterRoom = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        enterRoom = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartRandomiser && enterRoom)
        {
            Debug.Log("Room number: " + roomNumber);
            if (roomNumber == "16")
            {
                player.GetComponent<DoorWork>().DoorLeftCode = "";
                player.GetComponent<DoorWork>().DoorUpCode = "13";
                player.GetComponent<DoorWork>().DoorRightCode = "17";
                player.GetComponent<DoorWork>().DoorDownCode = "";
            }
            else if (roomNumber == "17")
            {
                player.GetComponent<DoorWork>().DoorLeftCode = "16";
                player.GetComponent<DoorWork>().DoorUpCode = "14";
                player.GetComponent<DoorWork>().DoorRightCode = "18";
                player.GetComponent<DoorWork>().DoorDownCode = "";
            }

            enterRoom = false;
        }
    }
}
