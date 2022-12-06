using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCntrl : MonoBehaviour
{
    public GameObject wall, light_part;
    public float distance;
    Camera MainCam;
    GameObject[,] walls = new GameObject[2,3];
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score",0);
        MainCam = gameObject.GetComponent<Camera>();
        Vector3 start = new Vector3(25, wall.transform.localScale.y/2+20, 0);
        walls[0,0] = Instantiate(wall);
        walls[0,0].transform.position = start;
        walls[1,0] = Instantiate(wall);
        walls[1,0].transform.position = start - new Vector3(0,walls[0,0].transform.localScale.y + 20,0);

        int l = Random.Range(0, 2);
        int f = Random.Range(0, 2);
        float zn = Mathf.Pow(-1f, (float)f);
        Vector3 newLoc;
        if ((zn * diff + walls[0, 0].transform.position.y < 15) || (zn * diff + walls[0, 0].transform.position.y > 60))
            newLoc = new Vector3(distance + walls[0, 0].transform.position.x, -zn * diff + walls[0, 0].transform.position.y, 0);

        else
            newLoc = new Vector3(distance + walls[0, 0].transform.position.x, zn * diff + walls[0, 0].transform.position.y, 0);
        walls[0, 1] = Instantiate(wall);
        walls[0, 1].transform.position = newLoc;

        if (l != 0)
        {
            lg = Instantiate(light_part);
            lg.transform.position = new Vector3(walls[0, 1].transform.position.x, newLoc.y - walls[0, 1].transform.localScale.y / 2 - 10, 0);
        }

        walls[1, 1] = Instantiate(wall);
        walls[1, 1].transform.position = walls[0, 1].transform.position - new Vector3(0, walls[0, 1].transform.localScale.y + 20, 0);



        l = Random.Range(0, 2);
        f = Random.Range(0, 2);
        zn = Mathf.Pow(-1f, (float)f);
        if ((zn * diff + walls[0, 1].transform.position.y < 15) || (zn * diff + walls[0, 1].transform.position.y > 60))
            newLoc = new Vector3(distance + walls[0, 1].transform.position.x, -zn * diff + walls[0, 1].transform.position.y, 0);

        else
            newLoc = new Vector3(distance + walls[0, 1].transform.position.x, zn * diff + walls[0, 1].transform.position.y, 0);
        walls[0, 2] = Instantiate(wall);
        walls[0, 2].transform.position = newLoc;
        if (l != 0)
        {
            lg = Instantiate(light_part);
            lg.transform.position = new Vector3(walls[0, 2].transform.position.x, newLoc.y - walls[0, 2].transform.localScale.y / 2 - 10, 0);
        }

        walls[1, 2] = Instantiate(wall);
        walls[1, 2].transform.position = walls[0, 2].transform.position - new Vector3(0, walls[0, 2].transform.localScale.y + 20, 0);
    }
    GameObject lg;
    bool obn = false;
    // Update is called once per frame

    float diff = 10f;

    void Update()
    {
        if (PlayerPrefs.GetInt("GameOver") == 0)
        {
            Vector3 point = MainCam.WorldToViewportPoint(walls[0,2].transform.position);
            if ((point.x > -0.5f) && (point.x < 0.5f))
            {
                int l = Random.Range(0, 2);
                int f = Random.Range(0, 2);
                float zn = Mathf.Pow(-1f, (float)f);
                Vector3 newLoc;
                if ((zn * diff + walls[0, 2].transform.position.y<15) || (zn * diff + walls[0, 2].transform.position.y > 60))
                    newLoc = new Vector3(distance + walls[0, 2].transform.position.x, -zn*diff + walls[0, 2].transform.position.y, 0);
                    
                else
                    newLoc = new Vector3(distance + walls[0, 2].transform.position.x, zn * diff + walls[0, 2].transform.position.y, 0);
                walls[0, 0].transform.position = walls[0, 1].transform.position;
                walls[1, 0].transform.position = walls[1, 1].transform.position;
                walls[0, 1].transform.position = walls[0, 2].transform.position;
                walls[1, 1].transform.position = walls[1, 2].transform.position;
                walls[0, 2].transform.position = newLoc;

                if (l!=0)
                {
                    lg = Instantiate(light_part);
                    lg.transform.position = new Vector3(walls[0, 2].transform.position.x,newLoc.y - walls[0, 2].transform.localScale.y/2 - 10, 0);
                }

                walls[1,2].transform.position = walls[0, 2].transform.position - new Vector3(0, walls[0,2].transform.localScale.y + 20, 0);
            }
        }
        else
        {
            if (!obn)
            {
                PlayerPrefs.SetInt("MaxScore", PlayerPrefs.GetInt("MaxScore") + PlayerPrefs.GetInt("Score"));
                obn = true;
            }
        }

    }
}
