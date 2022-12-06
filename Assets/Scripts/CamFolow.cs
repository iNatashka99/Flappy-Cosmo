using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFolow : MonoBehaviour
{
    public GameObject nlo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameOver") == 0)
            transform.position = nlo.transform.position + new Vector3(+5, -nlo.transform.position.y, -30);
    }
}
