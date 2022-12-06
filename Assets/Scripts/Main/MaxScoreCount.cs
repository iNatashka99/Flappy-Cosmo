using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScoreCount : MonoBehaviour
{
    Text count;
    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        count.text = "Your score: " + PlayerPrefs.GetInt("MaxScore").ToString();
    }
}
