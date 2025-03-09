using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWork : MonoBehaviour
{
    public string location = string.Empty;
    public int rooomNum = 0;
    public string stringRoom = "";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DoorLeft")
        {
            location = RoomManager.rooms[rooomNum, 0];
            LoadRoom();
        }
        else if (other.tag == "DoorUp")
        {
            location = RoomManager.rooms[rooomNum, 1];
            LoadRoom();
        }
        else if (other.tag == "DoorRight")
        {
            location = RoomManager.rooms[rooomNum, 2];
            LoadRoom();
        }
        else if (other.tag == "DoorDown")
        {
            location = RoomManager.rooms[rooomNum, 3];
            LoadRoom();
        }
    }

    private void LoadRoom()
    {
        stringRoom = "" + location[0] + location[1];
        rooomNum = int.Parse(stringRoom);

        if (stringRoom != "08")
        {
            if (location[2].Equals('L'))
            {
                transform.position = new Vector3(-8, 0, transform.position.z);
            }
            else if (location[2].Equals('U'))
            {
                transform.position = new Vector3(0, 4, transform.position.z);
            }
            else if (location[2].Equals('R'))
            {
                transform.position = new Vector3(8, 0, transform.position.z);
            }
            else if (location[2].Equals('D'))
            {
                transform.position = new Vector3(0, -4, transform.position.z);
            }
            SceneManager.LoadScene(sceneName: "Room" + location[0] + location[1]);
        }
        else if (stringRoom == "08")
        {
            if (location[2].Equals('R'))
            {
                transform.position = new Vector3(12.5f, 0, transform.position.z);
            }
            else if (location[2].Equals('D'))
            {
                transform.position = new Vector3(6, -3.75f, transform.position.z);
            }
            else if (location[2].Equals('U'))
            {
                if (location[3].Equals('1'))
                {
                    transform.position = new Vector3(-6, 3.75f, transform.position.z);
                }
                else if (location[3].Equals('2'))
                {
                    transform.position = new Vector3(6, 3.75f, transform.position.z);
                }
            }
            SceneManager.LoadScene(sceneName: "Room08");
        }
    }
}
