using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public bool StartRandomiser = false;
    public GameObject player;
    public string roomNumber = "";
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
            switch (roomNumber)
            {
                case "1":
                    player.GetComponent<DoorWork>().DoorLeftCode = "";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "2";
                    player.GetComponent<DoorWork>().DoorDownCode = "7";
                    break;
                case "2":
                    player.GetComponent<DoorWork>().DoorLeftCode = "1";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "3";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "3":
                    player.GetComponent<DoorWork>().DoorLeftCode = "2";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "6":
                    player.GetComponent<DoorWork>().DoorLeftCode = "";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "7";
                    player.GetComponent<DoorWork>().DoorDownCode = "10";
                    break;
                case "7":
                    player.GetComponent<DoorWork>().DoorLeftCode = "6";
                    player.GetComponent<DoorWork>().DoorUpCode = "1";
                    player.GetComponent<DoorWork>().DoorRightCode = "";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "10":
                    player.GetComponent<DoorWork>().DoorLeftCode = "";
                    player.GetComponent<DoorWork>().DoorUpCode = "6";
                    player.GetComponent<DoorWork>().DoorRightCode = "11";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "11":
                    player.GetComponent<DoorWork>().DoorLeftCode = "10";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "12";
                    player.GetComponent<DoorWork>().DoorDownCode = "14";
                    break;
                case "12":
                    player.GetComponent<DoorWork>().DoorLeftCode = "11";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "13":
                    player.GetComponent<DoorWork>().DoorLeftCode = "";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "14";
                    player.GetComponent<DoorWork>().DoorDownCode = "16";
                    break;
                case "14":
                    player.GetComponent<DoorWork>().DoorLeftCode = "13";
                    player.GetComponent<DoorWork>().DoorUpCode = "11";
                    player.GetComponent<DoorWork>().DoorRightCode = "15";
                    player.GetComponent<DoorWork>().DoorDownCode = "17";
                    break;
                case "15":
                    player.GetComponent<DoorWork>().DoorLeftCode = "14";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "16":
                    player.GetComponent<DoorWork>().DoorLeftCode = "";
                    player.GetComponent<DoorWork>().DoorUpCode = "13";
                    player.GetComponent<DoorWork>().DoorRightCode = "17";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "17":
                    player.GetComponent<DoorWork>().DoorLeftCode = "16";
                    player.GetComponent<DoorWork>().DoorUpCode = "14";
                    player.GetComponent<DoorWork>().DoorRightCode = "18";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "18":
                    player.GetComponent<DoorWork>().DoorLeftCode = "17";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "19";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
                case "19":
                    player.GetComponent<DoorWork>().DoorLeftCode = "18";
                    player.GetComponent<DoorWork>().DoorUpCode = "";
                    player.GetComponent<DoorWork>().DoorRightCode = "";
                    player.GetComponent<DoorWork>().DoorDownCode = "";
                    break;
            }

            enterRoom = false;
        }
    }
}
