using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomManager : MonoBehaviour
{
    public bool isRandom = false;
    private bool hasRan = true;
    public string SceneName1;
    public string SceneName2;

    void Update()
    {
        SceneName1 = SceneManager.GetActiveScene().name;
        if (SceneName1 != SceneName2)
        {
            hasRan = false;
            SceneName2 = SceneName1;
        }

        if (!hasRan)
        {
            if (isRandom)
            {
                switch (SceneName1)
                {
                    case "Room02":
                        GameObject.FindGameObjectWithTag("FullWall").SetActive(false);
                        break;
                    case "Room05":
                        GameObject.FindGameObjectWithTag("Gold").SetActive(false);
                        break;
                }
            }
            else
            {
                switch (SceneName1)
                {
                    case "Room02":
                        GameObject.FindGameObjectWithTag("DoorRight").SetActive(false);
                        GameObject.FindGameObjectWithTag("DoorWall").SetActive(false);
                        break;
                }
            }

            hasRan = true;
        }
    }
}
