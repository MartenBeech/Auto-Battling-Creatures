using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    public static GameObject sell;

    private void Start()
    {
        sell = GameObject.Find("Sell");
    }

    public void SellClicked()
    {
        Money money = new Money();
        if (Bench.iBench < Bench.SIZE)
        {
            money.UseGold(-Bench.units[Bench.iBench].cost);
            Bench bench = new Bench();
            bench.Destroy(Bench.iBench);
            Bench.iBench = Bench.SIZE;
        }
        else if (Formation.iFormation < Formation.SIZE)
        {
            money.UseGold(-Formation.units[Formation.iFormation].cost);
            Formation formation = new Formation();
            formation.Destroy(Formation.iFormation);
            Formation.iFormation = Formation.SIZE;
        }
        else
        {
            Info.infos[0].GetComponentInChildren<Text>().text = "Select a unit.\nThen click 'Sell Unit' to refund all gold used on that unit.";
        }
    }
}
