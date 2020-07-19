using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clan : MonoBehaviour
{
    public const int SIZE = 7;
    public static GameObject[] clans = new GameObject[SIZE];
    public static int haven;
    public static int academy;
    public static int necropolis;
    public static int stronghold;
    public static int sylvan;
    public static int dungeon;
    public static int fortress;

    public static int ranged;
    public static int beast;
    public static int protector;
    public static int charger;
    public static int warrior;
    public static int magical;
    public static int nimble;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            clans[i] = GameObject.Find("Clan" + i);
        }
    }
    public void UpdateClans()
    {
        haven = 0;
        academy = 0;
        necropolis = 0;
        stronghold = 0;
        sylvan = 0;
        dungeon = 0;
        fortress = 0;

        ranged = 0;
        beast = 0;
        protector = 0;
        charger = 0;
        warrior = 0;
        magical = 0;
        nimble = 0;

        for (int i = 0; i < Formation.SIZE; i++)
        {
            if (Formation.occupied[i])
            {
                if (Formation.units[i].clan.Contains("Haven"))
                    haven++;
                if (Formation.units[i].clan.Contains("Academy"))
                    academy++;
                if (Formation.units[i].clan.Contains("Necropolis"))
                    necropolis++;
                if (Formation.units[i].clan.Contains("Stronghold"))
                    stronghold++;
                if (Formation.units[i].clan.Contains("Sylvan"))
                    sylvan++;
                if (Formation.units[i].clan.Contains("Dungeon"))
                    dungeon++;
                if (Formation.units[i].clan.Contains("Fortress"))
                    fortress++;

                if (Formation.units[i].clan.Contains("Ranged"))
                    ranged++;
                if (Formation.units[i].clan.Contains("Beast"))
                    beast++;
                if (Formation.units[i].clan.Contains("Protector"))
                    protector++;
                if (Formation.units[i].clan.Contains("Charger"))
                    charger++;
                if (Formation.units[i].clan.Contains("Warrior"))
                    warrior++;
                if (Formation.units[i].clan.Contains("Magical"))
                    magical++;
                if (Formation.units[i].clan.Contains("Nimble"))
                    nimble++;
            }
        }

        List<string> clanNames = new List<string>();
        clanNames.Add("Haven");
        clanNames.Add("Academy");
        clanNames.Add("Necropolis");
        clanNames.Add("Stronghold");
        clanNames.Add("Sylvan");
        clanNames.Add("Dungeon");
        clanNames.Add("Fortress");

        clanNames.Add("Ranged");
        clanNames.Add("Beast");
        clanNames.Add("Protector");
        clanNames.Add("Charger");
        clanNames.Add("Warrior");
        clanNames.Add("Magical");
        clanNames.Add("Nimble");

        List<int> clanValues = new List<int>();
        clanValues.Add(haven);
        clanValues.Add(academy);
        clanValues.Add(necropolis);
        clanValues.Add(stronghold);
        clanValues.Add(sylvan);
        clanValues.Add(dungeon);
        clanValues.Add(fortress);

        clanValues.Add(ranged);
        clanValues.Add(beast);
        clanValues.Add(protector);
        clanValues.Add(charger);
        clanValues.Add(warrior);
        clanValues.Add(magical);
        clanValues.Add(nimble);

        int k, j;
        int N = clanValues.Count;

        for (j = 1; j < N; j++)
        {
            for (k = j; k > 0 && clanValues[k] < clanValues[k - 1]; k--)
            {
                clanValues = Switch(clanValues, k, k - 1);
                clanNames = Switch(clanNames, k, k - 1);
            }
        }

        for (int i = 0; i < SIZE; i++)
        {
            if (clanValues[clanValues.Count - 1 - i] > 0)
            {
                clans[i].GetComponentInChildren<Text>().text = clanValues[clanValues.Count - 1 - i] + " - " + clanNames[clanNames.Count - 1 - i];
            }
            else
            {
                clans[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }

    private List<int> Switch(List<int> list, int i0, int i1)
    {
        int temp = list[i0];
        list[i0] = list[i1];
        list[i1] = temp;
        return list;
    }

    private List<string> Switch(List<string> list, int i0, int i1)
    {
        string temp = list[i0];
        list[i0] = list[i1];
        list[i1] = temp;
        return list;
    }
}
