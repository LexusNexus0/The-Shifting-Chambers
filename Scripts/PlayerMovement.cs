using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    private Vector2 movementDirection;
    private Rigidbody2D player;
    public bool moveLocked = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveLocked)
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else
        {
            movementDirection = Vector2.zero;
        }

        player.velocity = movementDirection * speed;

        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(sceneName: "Room05");
            this.GetComponent<DoorWork>().roomNum = 5;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(sceneName: "Room08");
            this.GetComponent<DoorWork>().roomNum = 8;
            this.GetComponent<DoorWork>().inRoom8 = true;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            moveLocked = !moveLocked;
        }
    }
}
