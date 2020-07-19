using UnityEngine;
using UnityEngine.UI;

public class Bench : MonoBehaviour
{
    public const int SIZE = 10;
    public static GameObject[] benches = new GameObject[SIZE];
    public static Unit[] units = new Unit[SIZE];
    public static bool[] occupied = new bool[SIZE];
    private static int IBench;
    public static int iBench
    {
        get 
        { 
            return IBench; 
        }
        set 
        { 
            IBench = value;
            if (IBench < SIZE)
            {
                benches[IBench].GetComponentInChildren<Image>().color = Color.gray;
            }
            else
            {
                for (int i = 0; i < SIZE; i++)
                {
                    benches[i].GetComponentInChildren<Image>().color = Color.white;
                }
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            benches[i] = GameObject.Find("Bench" + i);
            units[i] = null;
            occupied[i] = false;
        }
        iBench = SIZE;
    }

    public int GetAvailableBench()
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (!occupied[i])
                return i;
        }
        return SIZE;
    }

    public void AddUnit(Unit unit, int i)
    {
        units[i] = new Unit();
        unit.AddStats(unit, units[i]);
        unit.UpdateDescription(benches[i], units[i]);
        occupied[i] = true;
    }

    public void Destroy(int i)
    {
        units[i] = null;
        benches[i].GetComponentInChildren<Text>().text = null;
        benches[i].GetComponentInChildren<Image>().sprite = null;
        occupied[i] = false;
    }

    public void BenchClicked(int i)
    {
        Formation formation = new Formation();
        int iFormation = Formation.iFormation;
        if (iFormation < Formation.SIZE)
        {
            if (!occupied[i])
            {
                AddUnit(Formation.units[iFormation], i);
                formation.Destroy(iFormation);
            }
            else
            {
                Unit temp = units[i];
                AddUnit(Formation.units[iFormation], i);
                formation.AddUnit(temp, iFormation);
            }
        }

        else if (iBench == SIZE && !occupied[i])
        {
            iBench = SIZE;
        }
        else if (iBench == SIZE)
        {
            iBench = i;
            Info info = new Info();
            info.ShowUnit(units[i]);
        }
        else
        {
            if (iBench != i)
            {
                if (!occupied[i])
                {
                    AddUnit(units[iBench], i);
                    Destroy(iBench);
                }
                else
                {
                    Unit temp = units[i];
                    AddUnit(units[iBench], i);
                    AddUnit(temp, iBench);
                }
            }
            iBench = SIZE;
        }
        Formation.iFormation = Formation.SIZE;
    }
}
