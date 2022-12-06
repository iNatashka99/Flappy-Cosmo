using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_or_Cancel : MonoBehaviour
{
    public GameObject panel, butt_close;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("MaxScore", 40);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Bye":
                {
                    PlayerPrefs.SetInt("MaxScore", (PlayerPrefs.GetInt("MaxScore") - PlayerPrefs.GetInt("Skin") * 20));
                    PlayerPrefs.SetString("SkinUnlocked", PlayerPrefs.GetString("SkinUnlocked") + " " + PlayerPrefs.GetInt("Skin").ToString());
                    panel.SetActive(false);
                    butt_close.SetActive(true);
                    break;
                }
            case "Cancel":
                {
                    string s = PlayerPrefs.GetString("SkinUnlocked");
                    int n = s.Length;
                    string t = "";
                    while (n > 0 && s[n-1]!=' ')
                    {
                        t += s[n - 1];
                        n = n - 1;
                    }
                    PlayerPrefs.SetInt("Skin", int.Parse(t));
                    panel.SetActive(false);
                    butt_close.SetActive(true);
                    break;
                }

        }
        if (PlayerPrefs.GetString("music") == "yes")
            GameObject.Find("tap").GetComponent<AudioSource>().Play();

    }
}
