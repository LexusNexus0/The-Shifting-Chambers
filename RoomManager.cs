using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static bool StartRandomiser = false;
    public GameObject player;
    public string roomNumber = "";
    public bool enterRoom = false;

    // Finish entering all the rooms from table
    public static string[,] rooms = {
        { "", "", "17L", "" },
        { "", "", "02L", "07U" }, 
        { "01R", "", "03L", "08U1" }, 
        { "02R", "", "", "" }, 
        { "", "", "", "08U2" }, 
        { "", "", "", "09U" }, 
        { "", "", "07L", "10U" },
        { "06R", "01D", "", "" },
        { "02D", "04D", "09L", "12U" },
        { "08R", "05D", "", "" },
        { "", "06D", "11L", "" },
        { "10R", "", "12L", "14U" },
        { "11R", "08D", "", "" },
        { "", "", "14L", "16U" },
        { "13R", "11D", "15L", "17U" },
        { "14R", "", "", "" },
        { "", "13D", "17L", "" },
        { "16R", "14D", "18L", "" },
        { "17R", "", "19L", "" },
        { "18R", "", "", "" }
    };

    public static List<string> leftDoors = new() { "02L", "03L", "07L", "09L", "11L", "12L", "14L", "15L", "17L", "18L", "19L" };
    public static List<string> upDoors = new()  { "07U", "08U1", "08U2", "09U", "10U", "12U", "14U", "16U", "17U" };
    public static List<string> rightDoors = new() { "01R", "02R", "06R", "08R", "10R", "11R", "13R", "14R", "16R", "17R", "18R" };
    public static List<string> downDoors = new() { "01D", "02D", "04D", "05D", "06D", "08D", "11D", "13D", "14D" };

    

    public static void clearRooms()
    {
        for (int i = 1; i < rooms.GetLength(0); i++)
        {
            for (int j = 0; j < rooms.GetLength(1); j++)
            {
                if (rooms[i, j] != "")
                {
                    rooms[i, j] = "X";
                }
            }
        }
    }

    public static void generateRandomDoorway()
    {
        for (int i = 1; i < rooms.GetLength(0); i++)
        {
            for (int j = 0; j < rooms.GetLength(1); j++)
            {
                if (rooms[i, j] == "X" && i != 8)
                {
                    if (j == 0)
                    {
                        int rNum = Random.Range(0, rightDoors.Count);
                        rooms[i, j] = rightDoors[rNum];
                        rightDoors.RemoveAt(rNum);
                    }
                    else if (j == 1) 
                    {
                        int rNum = Random.Range(0, downDoors.Count);
                        rooms[i, j] = downDoors[rNum];
                        downDoors.RemoveAt(rNum);
                    }
                    else if (j == 2)
                    {
                        int rNum = Random.Range(0, leftDoors.Count);
                        rooms[i, j] = leftDoors[rNum];
                        leftDoors.RemoveAt(rNum);
                    }
                    else if (j == 3)
                    {
                        int rNum = Random.Range(0, upDoors.Count);
                        rooms[i, j] = upDoors[rNum];
                        upDoors.RemoveAt(rNum);
                    }
                }
                else if (rooms[i, j] == "X" && i == 8)
                {
                    if (j == 0 || j == 1)
                    {
                        int rNum = Random.Range(0, downDoors.Count);
                        rooms[i, j] = downDoors[rNum];
                        downDoors.RemoveAt(rNum);
                    }
                    else if (j == 2)
                    {
                        int rNum = Random.Range(0, leftDoors.Count);
                        rooms[i, j] = leftDoors[rNum];
                        leftDoors.RemoveAt(rNum); 
                    }
                    else if (j == 3)
                    {
                        int rNum = Random.Range(0, upDoors.Count);
                        rooms[i, j] = upDoors[rNum];
                        upDoors.RemoveAt(rNum);
                    }
                }
            }
        }

        printRooms();
    }

    public static void printRooms()
    {
        for (int i = 0; i < rooms.GetLength(0); i++) 
        {
            string theRooms = i.ToString() +": ";

            for (int j = 0; j < rooms.GetLength(1); j++)
            {
                theRooms = theRooms + ", " + rooms[i, j];
            }
            Debug.Log(theRooms);
        }
    }
}
