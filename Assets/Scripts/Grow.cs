using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float x = 0.01f;
    public float y = 0.01f;
    public float z = 0.01f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.localScale += new Vector3(x, y, z);
            transform.position += new Vector3(0f,y/2);
        }
    }


}
