using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movementDirection;
    private Rigidbody2D player;

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
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        player.velocity = movementDirection * speed;

        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(sceneName: "Room05");
            this.GetComponent<DoorWork>().rooomNum = 5;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(sceneName: "Room14");
            this.GetComponent<DoorWork>().rooomNum = 14;
        }
    }
}
