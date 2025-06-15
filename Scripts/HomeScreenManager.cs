using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{
    public GameObject player;
    private GameObject currentPlayer;

    public void StartGame()
    {
        Instantiate(player, new Vector3(0, -5, 0), Quaternion.identity);
        SceneManager.LoadScene(sceneName: "Room17");
    }

    public void showRulesTips()
    {
        SceneManager.LoadScene(sceneName: "Story&Tips");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(sceneName: "HomeScreen");
    }

    public void MainMenu()
    {
        ResetGame();
        SceneManager.LoadScene(sceneName: "HomeScreen");
    }

    public void NewGame()
    {
        ResetGame();
        StartGame();
    }

    public void RestartBoss()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        currentPlayer.transform.position = new Vector3(0, 0, 0);
        currentPlayer.GetComponent<PlayerMovement>().moveLocked = false;
        SceneManager.LoadScene(sceneName: "Room08");
    }

    private void ResetGame()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        SceneManager.MoveGameObjectToScene(currentPlayer, SceneManager.GetActiveScene());
        RoomManager.rooms = RoomManager.roomsTemplate;
        RoomManager.leftDoors = RoomManager.TLeftDoors;
        RoomManager.upDoors = RoomManager.TUpDoors;
        RoomManager.rightDoors = RoomManager.TRightDoors;
        RoomManager.downDoors = RoomManager.TDownDoors;
        RoomManager.secretLDoors = RoomManager.TSecretLDoors;
        RoomManager.secretRDoors = RoomManager.TSecretRDoors;
    }
}
