using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public bool StartRandomiser = false;
    public GameObject player;
    public string roomNumber = "";
    public bool enterRoom = false;

    // Finish entering all the rooms from table
    public string[,] rooms = {
        { "", "", "17L", "" },
        { "", "", "02L", "07U" }, 
        { "01R", "", "03L", "08U1" }, 
        { "02R", "", "", "" }, 
        { "", "", "", "08U2" }, 
        { "", "", "", "09U" }, 
        { "", "", "07L", "10U" },
        { "06R", "01D", "", "" },
        { "02D", "04D", "09L", "12U" },
        { "08R", "05D", "", "" },
        { "", "06D", "11L", "" },
        { "10R", "", "12L", "14U" },
        { "11R", "08D", "", "" },
        { "", "", "14L", "16U" },
        { "13R", "11D", "15L", "17U" },
        { "14R", "", "", "" },
        { "", "13D", "17L", "" },
        { "16R", "14D", "18L", "" },
        { "17R", "", "19L", "" },
        { "18R", "", "", "" }
    };

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
