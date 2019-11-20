using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float x = 0.01f;
    public float y = 0.01f;
    public float z = 0.01f;

    private float timer = 0f;
    private bool grow = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.localScale += new Vector3(x, y, z);
            transform.position += new Vector3(0f,y/2);
            timer += 0.1f;
        }


    }


}
