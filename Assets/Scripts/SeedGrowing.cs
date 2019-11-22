﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowing : MonoBehaviour
{
    public float seedSize = 1;
    public int growingTime = 3; //비 올 때 다 자랄때 까지 걸리는 시간
    public int shrinkTime = 10; //다시 수축하는 데 걸리는 시간
    public float age;

    public float maxScale = 1.0f;
    public float minScale = 0.1f;
    public float scaleFactor;
    public Vector3 scale;
    public Vector3 position;
    public float defaultY_pos = 0;
    public bool isRainDrop = false;
    // Start is called before the first frame update
    void Start()
    {
        age = transform.localScale.x / seedSize;

        scaleFactor = seedSize * age;
        position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        defaultY_pos = position.y + scaleFactor / 2; ;
        
        scale = new Vector3(minScale, minScale, minScale);
        transform.localScale = scale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRainDrop)
        {
            age += Time.deltaTime / growingTime;

            if (age > 1)
            {
                age = 1;
            }
        }
        else
        {
            age -= Time.deltaTime / shrinkTime;
            if(age < 0)
            {
                age = 0;
            }
        }

        scaleFactor = seedSize * age;
        if (scaleFactor < minScale) scaleFactor = minScale;
        scale.x = scaleFactor;
        scale.y = scaleFactor;
        scale.z = scaleFactor;
        transform.localScale = scale;


        position.y = defaultY_pos - scale.y / 2;
        transform.localPosition = position;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pos")
        {
            isRainDrop = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "pos")
        {
            isRainDrop = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pos")
        {
            isRainDrop = false;
        }

    }
}
