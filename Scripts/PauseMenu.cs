using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    private GameObject pauseMenu;
    public bool inGame = false;

    void Awake()
    {
        pauseMenu = this.transform.GetChild(0).gameObject;
        DontDestroyOnLoad(pauseMenu.transform.parent.gameObject);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame && Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void MainMenu()
    {
        ResetGame();
        SceneManager.LoadScene(sceneName: "HomeScreen");
    }

    private void ResetGame()
    {
        SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Player"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.Find("PauseCanvas"), SceneManager.GetActiveScene());
        RoomManager.rooms = RoomManager.roomsTemplate;
        RoomManager.leftDoors = RoomManager.TLeftDoors;
        RoomManager.upDoors = RoomManager.TUpDoors;
        RoomManager.rightDoors = RoomManager.TRightDoors;
        RoomManager.downDoors = RoomManager.TDownDoors;
        RoomManager.secretLDoors = RoomManager.TSecretLDoors;
        RoomManager.secretRDoors = RoomManager.TSecretRDoors;
    }
}
