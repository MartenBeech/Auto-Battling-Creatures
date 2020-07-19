using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Unit : MonoBehaviour
{
    public int attack = 0;
    public int health = 0;
    public int maxHealth = 0;
    public int range = 2;
    public int speed = 2;
    public int cost = 0;
    public int mana = 0;
    public int maxMana = 0;
    public int armor = 0;
    public int resist = 0;
    public int ability = 100;

    public int tile = 30;
    public bool ally = false;
    public int level = 1;

    public string title = "N/A";
    public Sprite image;
    public VideoClip video;

    public int rage = 0;
    public int multistrike = 0;

    public string clan = "";
    //public bool haven = false;
    //public bool academy = false;
    //public bool necropolis = false;
    //public bool stronghold = false;
    //public bool sylvan = false;
    //public bool dungeon = false;
    //public bool fortress = false;

    //public bool ranged = false;
    //public bool beast = false;
    //public bool protector = false;
    //public bool charger = false;
    //public bool warrior = false;
    //public bool magical = false;
    //public bool nimble = false;



    public void UpdateDescription(GameObject gameObject, Unit unit)
    {
        gameObject.GetComponentInChildren<Text>().text = "<color=cyan>" + unit.mana + " / " + unit.maxMana + "</color>" + "\n\n\n" + unit.attack + " / " + unit.health;
        gameObject.GetComponentInChildren<Image>().sprite = unit.image;
    }

    public void AddStats(Unit from, Unit to)
    {
        to.attack = from.attack;
        to.health = from.health;
        to.maxHealth = from.maxHealth;
        to.range = from.range;
        to.speed = from.speed;
        to.cost = from.cost;
        to.mana = from.mana;
        to.maxMana = from.maxMana;
        to.armor = from.armor;
        to.resist = from.resist;
        to.ability = from.ability;

        to.ally = from.ally;
        to.level = from.level;

        to.title = from.title;
        to.image = from.image;

        to.rage = from.rage;
        to.multistrike = from.multistrike;

        to.clan = from.clan;

        //to.haven = from.haven;
        //to.academy = from.academy;
        //to.necropolis = from.necropolis;
        //to.stronghold = from.stronghold;
        //to.sylvan = from.sylvan;
        //to.dungeon = from.dungeon;
        //to.fortress = from.fortress;

        //to.ranged = from.ranged;
        //to.beast = from.beast;
        //to.protector = from.protector;
        //to.charger = from.charger;
        //to.warrior = from.warrior;
        //to.magical = from.magical;
        //to.nimble = from.nimble;

    }
}
