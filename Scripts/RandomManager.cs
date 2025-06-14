using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomManager : MonoBehaviour
{
    public bool isRandom = false;
    private bool hasRan = true;
    public bool KeyGotten = false;
    public string SceneName1;
    public string SceneName2;
    public bool bossDead = false;

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
                    case "Room08":
                        if (!bossDead)
                        {
                            GameObject.Find("BossBody").GetComponent<BossFight>().randomiserOn = true;
                        }
                        else
                        {
                            GameObject.Find("BossBody").GetComponent<BossFight>().bossDead = true;
                        }
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
                        GameObject.Find("OpenRightDoor").SetActive(false);
                        break;
                }
            }

            if (!KeyGotten && SceneName1 == "Room18")
            {
                GameObject.Find("OpenRightDoor").SetActive(false);
            }
            else if (KeyGotten && SceneName1 == "Room18")
            {
                GameObject.Find("LockedRightDoor").SetActive(false);
            }
            else if (KeyGotten && SceneName1 == "Room01")
            {
                GameObject.FindGameObjectWithTag("Key").SetActive(false);
            }
            hasRan = true;
        }
    }
}
