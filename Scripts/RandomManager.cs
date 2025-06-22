using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomManager : MonoBehaviour
{
    public bool isRandom = false;
    public bool hasRan = true;
    public bool KeyGotten = false;
    public string SceneName1;
    public string SceneName2;
    public bool bossDead = false;
    public bool doorOpen = false;

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
                        GameObject.FindGameObjectWithTag("Gold").GetComponent<Animator>().SetBool("GoldTaken", true);
                        GameObject.FindGameObjectWithTag("Gold").GetComponent<PolygonCollider2D>().isTrigger = false;
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
                    case "Room17":
                        if (bossDead)
                        {
                            GameObject.Find("ExitDoor").GetComponent<Animator>().SetBool("GameWon", bossDead);
                            GameObject.Find("ExitDoor").GetComponent<BoxCollider2D>().enabled = false;
                            GameObject.Find("InfoText").SetActive(false);
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
                    case "Room17":
                        GameObject.Find("InfoText").SetActive(false);
                        if (doorOpen)
                        {
                            GameObject.Find("ExitDoor").GetComponent<Animator>().SetBool("GameWon", doorOpen);
                            GameObject.Find("ExitDoor").GetComponent<BoxCollider2D>().enabled = false;
                        }
                        break;
                }
            }

            if (KeyGotten && SceneName1 == "Room18")
            {
                GameObject.Find("LockedRightDoor").GetComponent<Animator>().SetBool("KeyGotten", KeyGotten);
                GameObject.Find("LockedRightDoor").GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (KeyGotten && SceneName1 == "Room01")
            {
                GameObject.FindGameObjectWithTag("Key").SetActive(false);
            }
            hasRan = true;
        }
    }
}
