using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWork : MonoBehaviour
{
    public string location = string.Empty;
    public bool inRoom8 = false;
    public int roomNum;
    public string stringRoom = "";
    private string prevDoor = "";

    private void Start()
    {
        roomNum = 17;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DoorLeft")
        {
            location = RoomManager.rooms[roomNum, 0];
            prevDoor = "L";
            LoadRoom();
        }
        else if (other.tag == "DoorUp")
        {
            location = RoomManager.rooms[roomNum, 1];
            prevDoor = "U";
            LoadRoom();
        }
        else if (other.tag == "DoorRight")
        {
            location = RoomManager.rooms[roomNum, 2];
            prevDoor = "R";
            LoadRoom();
        }
        else if (other.tag == "DoorDown" && SceneManager.GetActiveScene().name != "Room17")
        {
            location = RoomManager.rooms[roomNum, 3];
            prevDoor = "D";
            LoadRoom();
        }
        else if (other.tag == "DoorDown" && SceneManager.GetActiveScene().name == "Room17")
        {
            this.gameObject.GetComponent<PlayerMovement>().moveLocked = true;

            if (this.gameObject.GetComponent<RandomManager>().doorOpen != true)
            {
                SceneManager.LoadScene(sceneName: "WinScreen");
            }
            else
            {
                SceneManager.LoadScene(sceneName: "JustLeaveEndWin");
            }
            
            GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().inGame = false;
        }
    }

    private void LoadRoom()
    {
        stringRoom = "" + location[0] + location[1];
        roomNum = int.Parse(stringRoom);

        if (stringRoom != "08" && !inRoom8)
        {
            if (location[2].Equals('L'))
            {
                transform.position = new Vector3(transform.position.x - 31.75f, transform.position.y, transform.position.z);
            }
            else if (location[2].Equals('U'))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 17.5f, transform.position.z);
            }
            else if (location[2].Equals('R'))
            {
                transform.position = new Vector3(transform.position.x + 31.75f, transform.position.y, transform.position.z);
            }
            else if (location[2].Equals('D'))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 17.5f, transform.position.z);
            }
            SceneManager.LoadScene(sceneName: "Room" + location[0] + location[1]);
        }
        else if (stringRoom == "08" && !inRoom8)
        {
            if (location[2].Equals('R'))
            {
                transform.position = new Vector3(transform.position.x + 39.65f, transform.position.y, transform.position.z);
            }
            else if (location[2].Equals('D'))
            {
                transform.position = new Vector3(transform.position.x + 8.125f, transform.position.y - 17.5f, transform.position.z);
            }
            else if (location[2].Equals('U'))
            {
                if (location[3].Equals('1'))
                {
                    transform.position = new Vector3(transform.position.x - 8.125f, transform.position.y + 17.5f, transform.position.z);
                }
                else if (location[3].Equals('2'))
                {
                    transform.position = new Vector3(transform.position.x + 8.125f, transform.position.y + 17.5f, transform.position.z);
                }
            }
            SceneManager.LoadScene(sceneName: "Room08");
            inRoom8 = true;
        }
        else if (stringRoom != "08" && inRoom8)
        {
            if (prevDoor == "R")
            {
                transform.position = new Vector3(transform.position.x - 39.65f, transform.position.y, transform.position.z);
            }
            else if (prevDoor == "L")
            {
                transform.position = new Vector3(transform.position.x + 8.125f, transform.position.y - 17.5f, transform.position.z);
            }
            else if (prevDoor == "U") 
            {
                transform.position = new Vector3(transform.position.x - 8.125f, transform.position.y - 17.5f, transform.position.z);
            }
            else if (prevDoor == "D")
            {
                transform.position = new Vector3(transform.position.x - 8.125f, transform.position.y + 17.5f, transform.position.z);
            }
            SceneManager.LoadScene(sceneName: "Room" + location[0] + location[1]);
            inRoom8 = false;
        }
        else if (stringRoom == "08" && inRoom8)
        {
            if (prevDoor == "L")
            {
                transform.position = new Vector3(transform.position.x + 16.25f, transform.position.y - 17.5f, transform.position.z);
            }
            else if (prevDoor == "U")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 17.5f, transform.position.z);
            }
            else if (prevDoor == "D")
            {
                if (location[3].Equals('1'))
                {
                    transform.position = new Vector3(transform.position.x - 16.25f, transform.position.y + 17.5f, transform.position.z);
                }
                else if (!location[3].Equals("2"))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 17.5f, transform.position.z);
                }
            }
        }

        this.gameObject.GetComponent<RandomManager>().hasRan = false;
    }
}
