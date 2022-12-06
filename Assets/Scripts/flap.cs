using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flap : MonoBehaviour
{
    Rigidbody rb;
    public GameObject nlo;
    Vector3 force = new Vector3(0, 500);
    float speed_x = 10;
    public float speed_diff;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("GameOver", 0);
        rb = nlo.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed_x, 0, 0);
    }

    bool fl = true;

    // Update is called once per frame
    void Update()
    {
        
            if (PlayerPrefs.GetInt("GameOver") == 0)
            {
                if ((rb.velocity.y < 15) && (rb.velocity.y > 0))
                    rb.velocity = new Vector3(rb.velocity.x, -7, 0);
                rb.velocity = new Vector3(rb.velocity.x + speed_diff, rb.velocity.y, 0);
                if (nlo.transform.position.y < -44 || nlo.transform.position.y > 44)
                    PlayerPrefs.SetInt("GameOver", 1);
            }
            else if (fl)
            {
                Vector3 pos = nlo.transform.position;
                Quaternion rot = new Quaternion(0, 0, 0, 0);
                GameObject exp = Instantiate(explosion, pos, rot) as GameObject;
                Destroy(nlo);
                fl = false;
                if (PlayerPrefs.GetString("music") == "yes")
                    GameObject.Find("explosion").GetComponent<AudioSource>().Play();
        }

    }
    /*
    private void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
        Gizmos.DrawSphere(nlo.transform.position, 5f);
    }
    */
    int time = 0;

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("GameOver") == 0)
        {
            time++;
            if (PlayerPrefs.GetString("music") == "yes")
                GameObject.Find("flap").GetComponent<AudioSource>().Play();
            if (rb.velocity.y < 0)
                rb.velocity = new Vector3(rb.velocity.x, 5, 0);
            rb.AddForce(force);
        }
    }

    private void OnMouseDrag()
    {
        if (PlayerPrefs.GetInt("GameOver") == 0)
        {
            if (time > 0)
            {
                if (time < 10)
                {
                    time++;
                    rb.AddForce(force);
                }
                else
                {
                    rb.velocity = new Vector3(rb.velocity.x, 15, 0);
                }
            }
        }
    }

}
