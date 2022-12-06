using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinGet : MonoBehaviour
{
    public Material[] mat = new Material[8];
    public GameObject cyl;
    Renderer rend;
    // Start is called before the first frame update
    private void Start()
    {
        rend = cyl.GetComponent<Renderer>();
        rend.enabled = true;
    }
    void Update()
    {
        int num = PlayerPrefs.GetInt("Skin");
        rend.sharedMaterial = mat[num];
    }

}
