using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWork : MonoBehaviour
{
    public string DoorLeftCode = string.Empty;
    public string DoorUpCode = string.Empty;
    public string DoorRightCode = string.Empty;
    public string DoorDownCode = string.Empty;
    public string location = string.Empty;

    public GameObject randomiser;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // New room gen stuff
        Debug.Log(other.tag);
        location = other.tag;
        if (location[2].Equals('L'))
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
            SceneManager.LoadScene(sceneName: "Room" + location[0] + location[1]);
        }

        // Old room gen stuff
        if (other.tag == "DoorLeft")
        {
            if (!string.IsNullOrEmpty(DoorLeftCode))
            {
                transform.position = new Vector3(8, transform.position.y, transform.position.z);
                SceneManager.LoadScene(sceneName: "Room" + DoorLeftCode);
                randomiser.GetComponent<RoomManager>().roomNumber = DoorLeftCode;
                randomiser.GetComponent<RoomManager>().enterRoom = true;
            }
            else
            {
                transform.position = new Vector3(9, transform.position.y, transform.position.z);
            }
        }
        else if (other.tag == "DoorUp")
        {
            if (!string.IsNullOrEmpty(DoorUpCode))
            {
                transform.position = new Vector3(transform.position.x, -4, transform.position.z);
                SceneManager.LoadScene(sceneName: "Room" + DoorUpCode);
                randomiser.GetComponent<RoomManager>().roomNumber = DoorUpCode;
                randomiser.GetComponent<RoomManager>().enterRoom = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, -5.5f, transform.position.z);
            }
        }
        else if (other.tag == "DoorRight")
        {
            if (!string.IsNullOrEmpty(DoorRightCode))
            {
                transform.position = new Vector3(-8, transform.position.y, transform.position.z);
                SceneManager.LoadScene(sceneName: "Room" + DoorRightCode);
                randomiser.GetComponent<RoomManager>().roomNumber = DoorRightCode;
                randomiser.GetComponent<RoomManager>().enterRoom = true;
            }
            else
            {
                transform.position = new Vector3(-9, transform.position.y, transform.position.z);
            }
        }
        else if (other.tag == "DoorDown")
        {
            if (!string.IsNullOrEmpty(DoorDownCode))
            {
                transform.position = new Vector3(transform.position.x, 4, transform.position.z);
                SceneManager.LoadScene(sceneName: "Room" + DoorDownCode);
                randomiser.GetComponent<RoomManager>().roomNumber = DoorDownCode;
                randomiser.GetComponent<RoomManager>().enterRoom = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
            }
        }
    }
}
