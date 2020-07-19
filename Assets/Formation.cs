using UnityEngine;
using UnityEngine.UI;

public class Formation : MonoBehaviour
{
    public const int SIZE = 9;
    public static GameObject[] formations = new GameObject[SIZE];
    public static Unit[] units = new Unit[SIZE];
    public static bool[] occupied = new bool[SIZE];
    private static int IFormation;
    public static int iFormation
    {
        get
        {
            return IFormation;
        }
        set
        {
            IFormation = value;
            if (IFormation < SIZE)
            {
                formations[IFormation].GetComponentInChildren<Image>().color = Color.gray;
            }
            else
            {
                for (int i = 0; i < SIZE; i++)
                {
                    formations[i].GetComponentInChildren<Image>().color = Color.white;
                }
            }
        }
    }
    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            formations[i] = GameObject.Find("Formation" + i);
            units[i] = null;
            occupied[i] = false;
        }
        iFormation = SIZE;
    }

    public void AddUnit(Unit unit, int i)
    {
        units[i] = new Unit();
        units[i].tile = i;
        unit.AddStats(unit, units[i]);
        unit.UpdateDescription(formations[i], units[i]);
        occupied[i] = true;
        Clan clan = new Clan();
        clan.UpdateClans();
    }

    public void Destroy(int i)
    {
        units[i] = null;
        formations[i].GetComponentInChildren<Text>().text = null;
        formations[i].GetComponentInChildren<Image>().sprite = null;
        occupied[i] = false;
        Clan clan = new Clan();
        clan.UpdateClans();
    }

    public void FormationClicked(int i)
    {
        Bench bench = new Bench();
        int iBench = Bench.iBench;
        if (iBench < Bench.SIZE)
        {
            if (!occupied[i])
            {
                AddUnit(Bench.units[iBench], i);
                bench.Destroy(iBench);
            }
            else
            {
                Unit temp = units[i];
                AddUnit(Bench.units[iBench], i);
                bench.AddUnit(temp, iBench);
            }
        }

        else if (iFormation == SIZE && !occupied[i])
        {
            iFormation = SIZE;
        }
        else if (iFormation == SIZE)
        {
            iFormation = i;
            Info info = new Info();
            info.ShowUnit(units[i]);
        }
        else
        {
            if (iFormation != i)
            {
                if (occupied[iFormation] || occupied[i])
                {
                    if (!occupied[iFormation])
                    {
                        AddUnit(units[i], iFormation);
                        Destroy(i);
                    }
                    else if (!occupied[i])
                    {
                        AddUnit(units[iFormation], i);
                        Destroy(iFormation);
                    }
                    else
                    {
                        Unit temp = units[i];
                        AddUnit(units[iFormation], i);
                        AddUnit(temp, iFormation);
                    }
                }
            }
            iFormation = SIZE;
        }
        Bench.iBench = Bench.SIZE;
    }
}
