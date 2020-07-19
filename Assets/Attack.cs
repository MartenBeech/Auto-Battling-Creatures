using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public bool AttackUnit(Unit unit)
    {
        
        if (DamageRandomInRange(unit, unit.attack + (unit.rage * 5), "Physical") < 30)
        {
            return true;
        }
        return false;
    }

    public void DealDamage(int from, int to, int damage, string type)
    {
        if (Bf.occupied[from] && Bf.occupied[to])
        {
            AnimaText animaText = new AnimaText();
            animaText.TakeDamage(from, to, damage, type);
        }
    }

    public int DamageRandomInRange(Unit unit, int damage, string type)
    {
        List<int> targets = new List<int>();
        if (unit.ally)
        {
            for (int i = unit.tile + 3; i <= unit.tile + (unit.range * 3); i += 3)
            {
                if (i > 29)
                {
                    break;
                }
                Tile tile = new Tile();
                List<int> tiles = tile.GetInFront(i - 3, unit.ally);
                for (int j = 0; j < tiles.Count; j++)
                {
                    if (Bf.occupied[tiles[j]])
                    {
                        if (Bf.units[tiles[j]].ally != unit.ally)
                        {
                            targets.Add(tiles[j]);
                        }
                    }
                }
                if (targets.Count > 0)
                {
                    break;
                }
            }
        }
        else
        {
            for (int i = unit.tile - 3; i >= unit.tile - (unit.range * 3); i -= 3)
            {
                if (i < 0)
                {
                    break;
                }
                Tile tile = new Tile();
                List<int> tiles = tile.GetInFront(i + 3, unit.ally);
                for (int j = 0; j < tiles.Count; j++)
                {
                    if (Bf.occupied[tiles[j]])
                    {
                        if (Bf.units[tiles[j]].ally != unit.ally)
                        {
                            targets.Add(tiles[j]);
                        }
                    }
                }
                if (targets.Count > 0)
                {
                    break;
                }
            }
        }

        if (targets.Count > 0)
        {
            int rnd = targets[Random.Range(0, targets.Count)];
            DealDamage(unit.tile, rnd, damage, type);
            return rnd;
        }
        return 30;
    }
}
