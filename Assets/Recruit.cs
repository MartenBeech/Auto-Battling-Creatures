using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Recruit : MonoBehaviour
{
    public const int SIZE = 5;
    public static GameObject[] recruits = new GameObject[SIZE];
    public static Unit[] units = new Unit[SIZE];
    public static bool[] occupied = new bool[SIZE];
    public static GameObject[] videoPlayer = new GameObject[5];

    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            recruits[i] = GameObject.Find("Recruit" + i);
            videoPlayer[i] = GameObject.Find("VideoPlayer" + i);
        }
    }

    public void NewRecruit()
    {
        Tier1 tier1 = new Tier1();
        for (int i = 0; i < SIZE; i++)
        {
            Destroy(i);
        }

        for (int i = 0; i < SIZE; i++)
        {
            units[i] = tier1.Recruit();
            recruits[i].GetComponentInChildren<Image>().enabled = false;
            videoPlayer[i].GetComponentInChildren<VideoPlayer>().clip = null;
            videoPlayer[i].GetComponentInChildren<VideoPlayer>().clip = units[i].video;
            videoPlayer[i].GetComponentInChildren<VideoPlayer>().Play();
            Unit unit = new Unit();
            unit.UpdateDescription(recruits[i], units[i]);
            occupied[i] = true;
        }
    }

    public void BuyUnit(int i)
    {
        if (occupied[i])
        {
            Bench bench = new Bench();
            int benchNmb = bench.GetAvailableBench();
            if (benchNmb < Bench.SIZE)
            {
                Money money = new Money();
                if (money.UseGold(units[i].cost))
                {
                    Upgrade upgrade = new Upgrade();
                    units[i].level = upgrade.NewUnit(units[i].title);
                    for (int j = 1; j < units[i].level; j++)
                    {
                        units[i].attack = Mathf.RoundToInt(units[i].attack * 1.5f);
                        units[i].health = Mathf.RoundToInt(units[i].health * 1.5f);
                        units[i].maxHealth = Mathf.RoundToInt(units[i].maxHealth * 1.5f);
                        units[i].armor = Mathf.RoundToInt(units[i].armor * 1.5f);
                        units[i].resist = Mathf.RoundToInt(units[i].resist * 1.5f);
                    }
                    if (units[i].level == 4)
                    {
                        units[i].image = Resources.Load<Sprite>("Creature Icons Upgrade/" + units[i].image.name);
                    }

                    bench.AddUnit(units[i], benchNmb);
                    recruits[i].GetComponentInChildren<Image>().enabled = true;
                    videoPlayer[i].GetComponentInChildren<VideoPlayer>().clip = null;
                    videoPlayer[i].GetComponentInChildren<VideoPlayer>().Stop();
                    Destroy(i);
                }
            }
        }
    }

    public void Destroy(int i)
    {
        units[i] = null;
        recruits[i].GetComponentInChildren<Text>().text = null;
        recruits[i].GetComponentInChildren<Image>().sprite = null;
        occupied[i] = false;
    }
}
