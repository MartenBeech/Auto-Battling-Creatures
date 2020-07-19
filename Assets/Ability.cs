using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    
    public void Use(Unit unit)
    {
        AnimaText animaText = new AnimaText();
        animaText.ShowText(Bf.bfs[unit.tile], "Ability Used", Color.cyan);
        Attack attack = new Attack();

        switch (unit.title)
        {
            case "Crossbowman":
                for (int i = unit.tile % 3; i < 30; i += 3)
                {
                    if (Bf.occupied[i])
                    {
                        if (Bf.units[i].ally != unit.ally)
                        {
                            
                            attack.DealDamage(unit.tile, i, unit.attack, "Magical");
                        }
                    }
                }
                break;

            case "Dire Wolf":
                unit.rage += 3;
                break;

            case "Sentinel":
                int target = attack.DamageRandomInRange(unit, unit.attack * 3, "Magical");
                Bf.units[target].armor -= unit.attack * 3;
                break;
        }

        unit.mana = 0;
        unit.UpdateDescription(Bf.bfs[unit.tile], unit);
    }
}
