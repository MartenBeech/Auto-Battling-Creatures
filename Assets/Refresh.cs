using UnityEngine;
using UnityEngine.UI;

public class Refresh : MonoBehaviour
{
    public static GameObject refresh;

    private void Start()
    {
        refresh = GameObject.Find("Refresh");
    }

    public void RefreshClicked()
    {
        Recruit recruit = new Recruit();
        recruit.NewRecruit();
    }
}
