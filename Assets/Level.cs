using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static GameObject level;

    private void Start()
    {
        level = GameObject.Find("Level");
        level.GetComponentInChildren<Text>().text = "Level: " + current + "\n\n" + "Levelup: " + cost + " gold";
    }

    public static int current = 1;
    public static int cost = 1;

    public void LevelUp()
    {
        Money money = new Money();
        if (money.UseGold(cost))
        {
            current++;
            cost *= 2;
            level.GetComponentInChildren<Text>().text = "Level: " + current + "\n" + "Level-Up cost: " + cost;
        }
    }
}
