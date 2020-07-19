using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public List<int> GetInFront(int i, bool ally)
    {
        List<int> tiles = new List<int>();
        if (ally)
        {
            if (i % 3 == 0)
            {
                tiles.Add(i + 3);
                tiles.Add(i + 4);
                tiles.Add(i + 5);
            }
            else if (i % 3 == 1)
            {
                tiles.Add(i + 2);
                tiles.Add(i + 3);
                tiles.Add(i + 4);
            }
            else if (i % 3 == 2)
            {
                tiles.Add(i + 1);
                tiles.Add(i + 2);
                tiles.Add(i + 3);
            }
        }
        else
        {
            if (i % 3 == 0)
            {
                tiles.Add(i - 1);
                tiles.Add(i - 2);
                tiles.Add(i - 3);
            }
            else if (i % 3 == 1)
            {
                tiles.Add(i - 2);
                tiles.Add(i - 3);
                tiles.Add(i - 4);
            }
            else if (i % 3 == 2)
            {
                tiles.Add(i - 3);
                tiles.Add(i - 4);
                tiles.Add(i - 5);
            }
        }
        return tiles;
    }
}
