using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        
    }
    int time = 0;
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameOver") != 0)
        {
            time++;
            if (time > 30)
            {
                Destroy(gameObject);
            }
        }
    }
}
