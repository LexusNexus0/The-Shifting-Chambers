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

    public GameObject randomiser;

    private void OnTriggerEnter2D(Collider2D other)
    {
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
            transform.position = new Vector3(transform.position.x, -5.5f, transform.position.z);
        }
        else if (other.tag == "DoorRight")
        {
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);
        }
        else if (other.tag == "DoorDown")
        {
            transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
        }
    }
}
