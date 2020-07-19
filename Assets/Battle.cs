using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    private List<Unit> unitTurns = new List<Unit>();
    private string action;
    public float counter = 2f;

    private void Update()
    {
        if (counter > 0 && counter < 1.9f)
        {
            counter -= Time.deltaTime;

            if (counter <= 0 && AnimaText.bufSize > 0)
            {
                counter = 1.05f;
            }
        }
        else if (counter <= 0)
        {
            counter = 2;
            if (action == "Ability")
            {
                Move();
            }
            else if (action == "Move")
            {
                Attack();
            }
            else if (action == "Attack")
            {
                Ability();
            }
        }
    }

    public void NewRound()
    {
        int ally = 29;
        int enemy = 0;

        for (int i = 0; i < 30; i++)
        {
            if (Bf.occupied[ally - i])
            {
                if (Bf.units[ally - i].ally)
                {
                    unitTurns.Add(Bf.units[ally - i]);
                }
            }
            if (Bf.occupied[enemy + i])
            {
                if (!Bf.units[enemy + i].ally)
                {
                    unitTurns.Add(Bf.units[enemy + i]);
                }
            }
        }
        Ability();
    }

    private void Ability()
    {
        action = "Ability";
        for (int i = 0; i < Bf.SIZE; i++)
        {
            Bf.bfs[i].GetComponent<Image>().color = Color.white;
        }

        if (unitTurns.Count > 0)
        {
            if (unitTurns[0].mana >= unitTurns[0].maxMana)
            {
                Ability ability = new Ability();
                ability.Use(unitTurns[0]);
                counter = 1.05f;
            }
            else
            {
                counter = 0.01f;
            }
        }
    }

    private void Move()
    {
        action = "Move";
        for (int i = 0; i < Bf.SIZE; i++)
        {
            Bf.bfs[i].GetComponent<Image>().color = Color.white;
        }

        if (unitTurns.Count > 0)
        {
            Move move = new Move();
            if (move.MoveUnit(unitTurns[0]))
            {
                counter = 1.05f;
            }
            else
            {
                counter = 0.01f;
            }
        }
    }

    private void Attack()
    {
        action = "Attack";
        Attack attack = new Attack();
        for (int i = 0; i < unitTurns[0].multistrike + 1; i++)
        {
            if (attack.AttackUnit(unitTurns[0]))
            {
                counter = 1.05f;
            }
            else
            {
                counter = 0.01f;
                break;
            }

            if (i == unitTurns[0].multistrike)
            {
                Bf.units[unitTurns[0].tile].rage = 0;
            }
        }
        
        unitTurns.RemoveAt(0);
    }
}
