using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tier1 : MonoBehaviour
{
    public Unit Recruit()
    {
        List<string> units = new List<string>();
        units.Add("Crossbowman");
        units.Add("Dire Wolf");
        units.Add("Sentinel");

        for (int i = 0; i < units.Count; i++)
        {
            Upgrade upgrade = new Upgrade();
            if (upgrade.GetUnitAmount(units[i], false) >= 8)
            {
                units.RemoveAt(i);
                i--;
            }
        }

        string title = units[Random.Range(0, units.Count)];

        Unit unit = new Unit();
        unit.title = title;
        unit.cost = 1;
        unit.ally = true;
        unit.armor = 0;
        unit.resist = 0;
        switch (title)
        {
            case "Crossbowman":
                unit.attack = 10;
                unit.health = unit.maxHealth = 10;
                unit.mana = 100;
                unit.maxMana = 100;
                unit.image = Resources.Load<Sprite>("Creature Icons/1-1-" + unit.title);

                unit.clan = "HavenRanged";
                break;

            case "Dire Wolf":
                unit.attack = 10;
                unit.health = unit.maxHealth = 10;
                unit.mana = 50;
                unit.maxMana = 100;
                unit.image = Resources.Load<Sprite>("Creature Icons/1-2-" + unit.title);

                unit.clan = "HavenBeast";
                break;

            case "Sentinel":
                unit.attack = 10;
                unit.health = unit.maxHealth = 10;
                unit.mana = 50;
                unit.maxMana = 100;
                unit.image = Resources.Load<Sprite>("Creature Icons/1-3-" + unit.title);
                unit.multistrike = 2;

                unit.clan = "HavenProtector";
                break;

        }

        
        unit.video = Resources.Load<VideoClip>("Creature Animations/" + unit.image.name);
        return unit;
    }
}
