using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public bool MoveUnit(Unit unit)
    {
        int moveTo = unit.tile;
        if (unit.ally)
        {
            for (int i = unit.tile + 3; i <= unit.tile + (unit.speed * 3); i += 3)
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
                        if (!Bf.units[tiles[j]].ally)
                        {
                            goto OutOfLoop;
                        }
                    }
                }
                if (!Bf.occupied[i])
                {
                    moveTo = i;
                }
            }
        }
        else
        {
            for (int i = unit.tile - 3; i >= unit.tile - (unit.speed * 3); i -= 3)
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
                        if (Bf.units[tiles[j]].ally)
                        {
                            goto OutOfLoop;
                        }
                    }
                }
                if (!Bf.occupied[i])
                {
                    moveTo = i;
                }
            }
        }

    OutOfLoop:

        if (unit.tile != moveTo)
        {
            AnimaUnit animaUnit = new AnimaUnit();
            animaUnit.MoveUnit(unit.tile, moveTo);
            Bf bf = new Bf();
            bf.Destroy(unit.tile);
            unit.tile = moveTo;
            return true;
        }
        return false;

    }
}
