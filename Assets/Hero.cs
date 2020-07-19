using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public const int SIZE = 2;
    GameObject[] heroes = new GameObject[SIZE];

    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            heroes[i] = GameObject.Find("Hero" + i);
        }
    }
}
