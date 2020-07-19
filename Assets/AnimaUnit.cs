using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaUnit : MonoBehaviour
{
    public static GameObject startSet;
    public static GameObject endSet;
    public static int iTo;
    public static GameObject prefab;
    public static GameObject parent;
    public static Unit unit;
    private GameObject startPoint;
    private GameObject endPoint;
    private int _to;

    private float counter = 1f;

    private void Awake()
    {
        startPoint = startSet;
        endPoint = endSet;
        _to = iTo;
    }

    void Update()
    {
        if (counter > 0)
        {
            Vector3 dir = endPoint.transform.position - startPoint.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPoint.transform.position.x - startPoint.transform.position.x, 2) +
                Mathf.Pow(endPoint.transform.position.y - startPoint.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * Time.deltaTime);
        }

        else if (counter <= 0)
        {
            Bf bf = new Bf();
            bf.AddUnit(unit, _to);
            Destroy(gameObject);
        }

        counter -= Time.deltaTime;
    }

    public void MoveUnit(int from, int to)
    {
        prefab = Resources.Load<GameObject>("Prefabs/Unit");
        parent = GameObject.Find("Animation");
        unit = Bf.units[from];
        iTo = to;
        startSet = Bf.bfs[from];
        endSet = Bf.bfs[to];

        prefab.GetComponentInChildren<Image>().sprite = Bf.bfs[from].GetComponentInChildren<Image>().sprite;
        prefab.GetComponentInChildren<Text>().text = Bf.bfs[from].GetComponentInChildren<Text>().text;
        prefab.GetComponentInChildren<Text>().color = Bf.bfs[from].GetComponentInChildren<Text>().color;

        prefab = Instantiate(prefab, startSet.transform.position, startSet.transform.rotation, parent.transform);
    }
}
