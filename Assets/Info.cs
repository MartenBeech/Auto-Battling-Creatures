using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public static GameObject[] infos = new GameObject[2];

    private void Start()
    {
        infos[0] = GameObject.Find("Info");
        infos[1] = GameObject.Find("InfoArena");
    }

    public void ShowUnit(Unit unit)
    {
        for (int i = 0; i < 2; i++)
        {
            infos[i].GetComponentInChildren<Text>().text = unit.title + "\n\n" +
                "Attack:\t\t\t\t" + unit.attack + "\n" +
                "Health:\t\t\t\t" + unit.health + "/" + unit.maxHealth + "\n" +
                "Armor/Resist:\t" + unit.armor + "/" + unit.resist;
        }
    }
}
