using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Unit Recruit(string name)
    {
        Unit unit = new Unit();
        switch (name)
        {
            case "ccc":
                unit.attack = 3;
                unit.health = unit.maxHealth = 28;
                unit.range = 2;
                unit.speed = 2;
                unit.cost = 1;
                unit.mana = 50;
                unit.maxMana = 1000;
                break;

            case "ddd":
                unit.attack = 8;
                unit.health = unit.maxHealth = 5;
                unit.range = 4;
                unit.speed = 2;
                unit.cost = 2;
                unit.mana = 50;
                unit.maxMana = 1000;
                break;
            
        }
        unit.cost = 0;
        unit.ally = false;
        return unit;
    }
}
