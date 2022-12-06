using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScin : MonoBehaviour
{
    public GameObject skin_num;
    public int num;
    public GameObject panel_buy, butt_buy, butt_close;

    private void Start()
    {
        panel_buy.SetActive(false);
        if (PlayerPrefs.HasKey("Skin"))
            PlayerPrefs.SetInt("Skin", num);
        else
            PlayerPrefs.SetInt("Skin", 0);
        if (!PlayerPrefs.HasKey("SkinUnlocked"))
            PlayerPrefs.SetString("SkinUnlocked", PlayerPrefs.GetInt("Skin").ToString());
    }

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetString("SkinUnlocked").Contains(num.ToString()))
            PlayerPrefs.SetInt("Skin", num);
        else
        {
            PlayerPrefs.SetInt("Skin", num);
            panel_buy.SetActive(true);
            butt_close.SetActive(false);
            butt_buy.SetActive(true);
            if (PlayerPrefs.GetInt("MaxScore")<PlayerPrefs.GetInt("Skin")*20)
                butt_buy.SetActive(false);
        }
    }
}
