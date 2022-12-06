using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject m_off;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "music")
            if (PlayerPrefs.GetString("music") == "no")
            {
                m_off.SetActive(true);
            }
            else
            {
                m_off.SetActive(false);
            }
    }
    int time = 0;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "play":
                {
                    Application.LoadLevel("MainScene");
                    break;
                }
            case "help":
                {
                    Application.LoadLevel("HelpScene");
                    break;
                }
            case "skins":
                {
                    Application.LoadLevel("ChangeSkin");
                    break;
                }
            case "follow":
                {
                    Application.OpenURL("https://github.com/iNatashka99");
                    break;
                }
            case "restart_help":
                {
                    Application.LoadLevel("HelpScene");
                    break;
                }
            case "restart":
                {
                    Application.LoadLevel("MainScene");
                    break;
                }
            case "close":
                {
                    Application.LoadLevel("OpenScene");
                    break;
                }
            case "music":
                {
                    if (PlayerPrefs.GetString("music") != "no")
                    {
                        PlayerPrefs.SetString("music", "no");
                        m_off.SetActive(true);
                    }
                    else
                    {
                        PlayerPrefs.SetString("music", "yes");
                        m_off.SetActive(false);
                    }
                    break;
                }

        }
        if (PlayerPrefs.GetString("music") == "yes")
            GameObject.Find("tap").GetComponent<AudioSource>().Play();

    }
}
