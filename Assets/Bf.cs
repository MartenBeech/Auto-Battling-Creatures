using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bf : MonoBehaviour
{
    public const int SIZE = 30;
    public static GameObject[] bfs = new GameObject[SIZE];
    public static Unit[] units = new Unit[SIZE];
    public static bool[] occupied = new bool[SIZE];


    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            bfs[i] = GameObject.Find("Bf" + i);
            units[i] = null;
            occupied[i] = false;
        }
    }
    public void AddUnit(Unit unit, int i)
    {
        units[i] = new Unit();
        units[i].tile = i;
        unit.AddStats(unit, units[i]);
        unit.UpdateDescription(bfs[i], units[i]);
        if (unit.ally)
        {
            bfs[i].GetComponentInChildren<Text>().color = Color.green;
        }
        else
        {
            bfs[i].GetComponentInChildren<Text>().color = Color.red;
        }
        bfs[i].GetComponentInChildren<Image>().sprite = units[i].image;
        occupied[i] = true;
    }

    public void Destroy(int i)
    {
        units[i] = null;
        bfs[i].GetComponentInChildren<Text>().text = null;
        bfs[i].GetComponentInChildren<Image>().sprite = null;
        occupied[i] = false;
    }

    public void BfClicked(int i)
    {
        Info info = new Info();
        info.ShowUnit(units[i]);
    }
}
