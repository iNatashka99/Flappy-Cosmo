using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtCntrl : MonoBehaviour
{
    public GameObject pause, restart, close, LoseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int time = 0;
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameOver") == 0)
        {
            pause.SetActive(true);
            restart.SetActive(false);
            close.SetActive(false);
            LoseText.SetActive(false);
        }
        else
        {
            time++;
            if (time > 30)
            {
                restart.SetActive(true);
                close.SetActive(true);
                pause.SetActive(false);
                LoseText.SetActive(true);
            }
        }
    }
}
