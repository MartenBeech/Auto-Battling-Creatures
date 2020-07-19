using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static GameObject money;
    public static int gold = 100;

    private void Start()
    {
        money = GameObject.Find("Money");
        money.GetComponentInChildren<Text>().text = "Gold:\n" + gold;
    }
    

    public bool UseGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            money.GetComponentInChildren<Text>().text = "Gold:\n" + gold;
            return true;
        }
        return false;
    }
}
