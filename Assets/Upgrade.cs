using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public int GetUnitAmount(string title, bool alreadyOwned)
    {
        int nUnits = 0;
        if (alreadyOwned)
        {
            nUnits++;
        }

        for (int i = 0; i < Bench.SIZE; i++)
        {
            if (Bench.occupied[i])
            {
                if (Bench.units[i].title == title)
                {
                    if (Bench.units[i].level == 1)
                    {
                        nUnits += 1;
                    }
                    else if (Bench.units[i].level == 2)
                    {
                        nUnits += 2;
                    }
                    else if (Bench.units[i].level == 3)
                    {
                        nUnits += 4;
                    }
                    else if (Bench.units[i].level == 4)
                    {
                        nUnits += 8;
                    }
                }
            }
        }
        for (int i = 0; i < Formation.SIZE; i++)
        {
            if (Formation.occupied[i])
            {
                if (Formation.units[i].title == title)
                {
                    if (Formation.units[i].level == 1)
                    {
                        nUnits += 1;
                    }
                    else if (Formation.units[i].level == 2)
                    {
                        nUnits += 2;
                    }
                    else if (Formation.units[i].level == 3)
                    {
                        nUnits += 4;
                    }
                    else if (Formation.units[i].level == 4)
                    {
                        nUnits += 8;
                    }
                }
            }
        }

        if (!alreadyOwned)
        {
            for (int i = 0; i < Recruit.SIZE; i++)
            {
                if (Recruit.occupied[i])
                {
                    if (Recruit.units[i].title == title)
                    {
                        nUnits += 1;
                    }
                }
            }
        }
        return nUnits;
    }
    
    public int NewUnit(string title)
    {
        int nUnits = GetUnitAmount(title, true);

        if (nUnits == 2 || nUnits == 6)
        {
            UpgradeUnits(title, 2);
            return 2;
        }
        else if (nUnits == 4)
        {
            UpgradeUnits(title, 3);
            return 3;
        }
        else if (nUnits == 8)
        {
            UpgradeUnits(title, 4);
            return 4;
        }
        return 1;
    }

    private void UpgradeUnits(string title, int level)
    {
        AnimaText animaText = new AnimaText();
        
        for (int i = 0; i < Bench.SIZE; i++)
        {
            if (Bench.occupied[i])
            {
                if (Bench.units[i].title == title && Bench.units[i].level < level)
                {
                    Bench bench = new Bench();
                    bench.Destroy(i);
                    animaText.ShowText(Bench.benches[i], "Upgraded", Color.green);
                }
            }
        }
        for (int i = 0; i < Formation.SIZE; i++)
        {
            if (Formation.occupied[i])
            {
                if (Formation.units[i].title == title && Formation.units[i].level < level)
                {
                    Formation formation = new Formation();
                    formation.Destroy(i);
                    animaText.ShowText(Formation.formations[i], "Upgraded", Color.green);
                }
            }
        }
    }
}
