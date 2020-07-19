using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public static GameObject round;
    private static int CurFloor = 0;
    private static int CurRound = 0;
    public static int curFloor
    {
        get
        {
            return CurFloor;
        }
        set
        {
            CurFloor = value;
            round.GetComponentInChildren<Text>().text = "Floor: " + CurFloor + "\n" + "Round: " + CurRound;
        }
    }
    public static int curRound
    {
        get
        {
            return CurRound;
        }
        set
        {
            CurRound = value;
            round.GetComponentInChildren<Text>().text = "Floor: " + CurFloor + "\n" + "Round: " + CurRound;
        }
    }

    private void Start()
    {
        round = GameObject.Find("ArenaRound");
    }
}
