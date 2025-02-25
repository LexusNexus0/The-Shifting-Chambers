using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < (40/9) &&  player.transform.position.x > (-40/9))
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (player.transform.position.x > (40/9)) {
            transform.position = new Vector3(4.444444f, transform.position.y, transform.position.z);
        }
        else if (player.transform.position.x < (-40/9)) {
            transform.position = new Vector3(4.444444f, transform.position.y, transform.position.z);
        }
    }
}
