using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaText : MonoBehaviour
{
    public GameObject prefab;
    private GameObject startSet;
    public static GameObject parent;
    private float counter = 1f;
    public static int bufSize = 0;
    private static GameObject[] bufPrefab = new GameObject[50];
    private static GameObject[] bufPos = new GameObject[50];
    private static string[] bufText = new string[50];
    private static Color[] bufColor = new Color[50];
    private static int[] bufDealer = new int[50];
    private static int[] bufTarget = new int[50];
    private static int[] bufDamage = new int[50];
    private bool bufDecreased = false;

    private void Awake()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f);

        if (bufDamage[0] > 0)
        {
            Bf.units[bufTarget[0]].health -= bufDamage[0];
            if (Bf.units[bufTarget[0]].health > Bf.units[bufTarget[0]].maxHealth)
            {
                Bf.units[bufTarget[0]].health = Bf.units[bufTarget[0]].maxHealth;
            }
            Bf.units[bufTarget[0]].mana += Random.Range(1, 9);
            if (Bf.units[bufTarget[0]].mana > Bf.units[bufTarget[0]].maxMana)
            {
                Bf.units[bufTarget[0]].mana = Bf.units[bufTarget[0]].maxMana;
            }
            Bf.units[bufDealer[0]].mana += Random.Range(8, 16);
            if (Bf.units[bufDealer[0]].mana > Bf.units[bufDealer[0]].maxMana)
            {
                Bf.units[bufDealer[0]].mana = Bf.units[bufDealer[0]].maxMana;
            }

            Unit unit = new Unit();
            unit.UpdateDescription(bufPos[0], Bf.units[bufTarget[0]]);
            unit.UpdateDescription(Bf.bfs[bufDealer[0]], Bf.units[bufDealer[0]]);
        }
    }
    void Update()
    {
        if (counter > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.0035f, -0.1f);
            counter -= Time.deltaTime;

            if (counter <= 0.5 && !bufDecreased)
            {
                bufDecreased = true;

                for (int i = 0; i < bufSize; i++)
                {
                    bufPrefab[i] = bufPrefab[i + 1];
                    bufPos[i] = bufPos[i + 1];
                    bufText[i] = bufText[i + 1];
                    bufColor[i] = bufColor[i + 1];
                    bufDealer[i] = bufDealer[i + 1];
                    bufTarget[i] = bufTarget[i + 1];
                    bufDamage[i] = bufDamage[i + 1];
                }
                bufSize--;

                if (bufSize > 0)
                {
                    bufPrefab[0].GetComponentInChildren<Text>().color = bufColor[0];
                    bufPrefab[0].GetComponentInChildren<Text>().text = bufText[0];

                    Instantiate(bufPrefab[0], bufPos[0].transform.position, bufPos[0].transform.rotation, GameObject.Find("Animation").transform);
                }
            }

            if (counter <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int from, int to, int damage, string type)
    {
        prefab = Resources.Load<GameObject>("Prefabs/DamageText");
        parent = GameObject.Find("Animation");
        startSet = Bf.bfs[to];

        if (damage < 0)
        {
            prefab.GetComponentInChildren<Text>().color = Color.green;
            prefab.GetComponentInChildren<Text>().text = "+" + (damage * (-1)).ToString();
        }
        else if (damage >= 0)
        {
            if (type == "Physical")
            {
                prefab.GetComponentInChildren<Text>().color = Color.red;
                if (Bf.units[to].armor >= 0)
                {
                    double dmgD = damage * (1 - ((0.03 * Bf.units[to].armor) / ((0.03 * Bf.units[to].armor) + 3)));
                    float dmgF = (float)dmgD;
                    damage = Mathf.RoundToInt(dmgF);
                }
                else
                {
                    double dmgD = damage * damage / (damage * (1 - ((0.03 * -Bf.units[to].armor) / ((0.03 * -Bf.units[to].armor) + 3))));
                    float dmgF = (float)dmgD;
                    damage = Mathf.RoundToInt(dmgF);
                }
            }
            else if (type == "Magical")
            {
                prefab.GetComponentInChildren<Text>().color = Color.blue;
                if (Bf.units[to].resist >= 0)
                {
                    double dmgD = damage * (1 - ((0.03 * Bf.units[to].resist) / ((0.03 * Bf.units[to].resist) + 3)));
                    float dmgF = (float)dmgD;
                    damage = Mathf.RoundToInt(dmgF);
                }
                else
                {
                    double dmgD = damage * damage / (damage * (1 - ((0.03 * -Bf.units[to].resist) / ((0.03 * -Bf.units[to].resist) + 3))));
                    float dmgF = (float)dmgD;
                    damage = Mathf.RoundToInt(dmgF);
                }
            }
            else if (type == "True")
            {
                prefab.GetComponentInChildren<Text>().color = Color.white;
            }

            prefab.GetComponentInChildren<Text>().text = (damage * (-1)).ToString();
        }

        bufPos[bufSize] = startSet;
        bufText[bufSize] = prefab.GetComponentInChildren<Text>().text;
        bufColor[bufSize] = prefab.GetComponentInChildren<Text>().color;
        bufPrefab[bufSize] = prefab;
        bufDealer[bufSize] = from;
        bufTarget[bufSize] = to;
        bufDamage[bufSize] = damage;
        Bf.bfs[from].GetComponent<Image>().color = Color.red;

        if (bufSize == 0)
        {
            Instantiate(bufPrefab[bufSize], bufPos[bufSize].transform.position, bufPos[bufSize].transform.rotation, parent.transform);
        }
        bufSize++;
    }

    public void ShowText(GameObject to, string text, Color textColor)
    {
        prefab = Resources.Load<GameObject>("Prefabs/DamageText");
        parent = GameObject.Find("Animation");
        startSet = to;
        prefab.GetComponentInChildren<Text>().color = textColor;
        prefab.GetComponentInChildren<Text>().text = text;

        bufPos[bufSize] = startSet;
        bufText[bufSize] = prefab.GetComponentInChildren<Text>().text;
        bufColor[bufSize] = prefab.GetComponentInChildren<Text>().color;
        bufPrefab[bufSize] = prefab;

        if (bufSize == 0)
        {
            Instantiate(bufPrefab[0], bufPos[0].transform.position, bufPos[0].transform.rotation, parent.transform);
        }
        bufSize++;
    }
}
