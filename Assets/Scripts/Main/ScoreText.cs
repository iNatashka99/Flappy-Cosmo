using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text count;
    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<Text>();
        count.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        count.text = "Score: "+ PlayerPrefs.GetInt("Score").ToString();
    }
}
