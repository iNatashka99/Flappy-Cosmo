using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        if (PlayerPrefs.GetString("music") == "yes")
            GameObject.Find("amm").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
