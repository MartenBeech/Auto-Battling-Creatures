using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Ready : MonoBehaviour
{
    public static GameObject ready;
    private GameObject cam;
    private GameObject canvasArena;

    private void Start()
    {
        ready = GameObject.Find("Ready");
    }

    public void ReadyClicked()
    {
        cam = GameObject.Find("Main Camera");
        canvasArena = GameObject.Find("Canvas Arena");
        cam.transform.position = new Vector3(canvasArena.transform.position.x, canvasArena.transform.position.y, -10);

        Bf bf = new Bf();
        for (int i = 0; i < Formation.SIZE; i++)
        {
            if (Formation.occupied[i])
            {
                bf.AddUnit(Formation.units[i], i);
            }
        }

        for (int i = 0; i < Recruit.SIZE; i++)
        {
            Recruit.videoPlayer[i].GetComponentInChildren<VideoPlayer>().clip = null;
        }

        Enemy enemy = new Enemy();
        bf.AddUnit(enemy.Recruit("ccc"), 29);
        bf.AddUnit(enemy.Recruit("ccc"), 28);
        bf.AddUnit(enemy.Recruit("ccc"), 27);
    }
}
