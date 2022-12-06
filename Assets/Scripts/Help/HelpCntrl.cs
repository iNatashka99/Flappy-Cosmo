using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpCntrl : MonoBehaviour
{
    public GameObject nlo, wall, light_part;
    GameObject[] walls = new GameObject[2];
    public Camera MainCam;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 start = new Vector3(65, wall.transform.localScale.y / 2 + 20, 0);
        walls[0] = Instantiate(wall);
        walls[0].transform.position = start;
        walls[1] = Instantiate(wall);
        walls[1].transform.position = start - new Vector3(0, walls[0].transform.localScale.y + 20, 0);
        lg = Instantiate(light_part);
        lg.transform.position = new Vector3(walls[0].transform.position.x, walls[0].transform.position.y - walls[0].transform.localScale.y / 2 - 10, 0);
    }

    GameObject lg;
    int time = 0;
    bool fl = true;

    void Update()
    {
        if (PlayerPrefs.GetInt("GameOver") == 0)
        {
            if (nlo.transform.position.x < 30)
            {
                t.text = "Tap to fly";
            }
            else if (nlo.transform.position.x < 80)
            {
                t.text = "Fly around the walls and collect light";
                if ((nlo.transform.position.x > 60)&&(nlo.transform.position.x < 69)&& 
                    ((nlo.transform.position.y > walls[0].transform.position.y - walls[0].transform.localScale.y/2-2)
                    ||(nlo.transform.position.y < walls[1].transform.position.y + walls[1].transform.localScale.y / 2+2)))
                        nlo.transform.position = new Vector3(30, 0, 0);

            }
            else if (nlo.transform.position.x < 130)
            {
                if (fl)
                {
                    t.text = "If you hit a wall, the game is over";
                    walls[0] = Instantiate(wall);
                    walls[0].transform.position = new Vector3(130, 0, 0);
                    fl = false;
                }
            }
            if (nlo.transform.position.y < -40 || nlo.transform.position.y > 40)
            {
                nlo.GetComponent<Rigidbody>().velocity = new Vector3(nlo.GetComponent<Rigidbody>().velocity.x, 0, 0);
                nlo.transform.position = new Vector3(nlo.transform.position.x, 0, nlo.transform.position.z);
            }
        }

        if (PlayerPrefs.GetInt("GameOver") == 1)
        {
            time++;
            if (time > 50)
            {
                Destroy(walls[0]);
                if (walls[1] != null)
                    Destroy(walls[1]);
                t.text = "Have fun and follow me =)";
            }

        }
    }
}
