using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_flap : MonoBehaviour
{
    Rigidbody rb;
    bool fl = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y <= -4.5f) && (fl))
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(0, 750, 0);
            fl = false;
        }
        if ((transform.position.y >= -4.5f) && (!fl))
            fl = true;
    }
}
