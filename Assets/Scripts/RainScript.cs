using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{

    public Vector3 prevPos;
    public Vector3 currentDirection;
    public Vector3 temp_vector;
    public ParticleSystem.MinMaxCurve rotation;

    public GameObject particle;

    private ParticleSystem ps;
    public float hSliderValue = 1.0F;


    // Start is called before the first frame update
    void Start()
    {
        print("do something");

        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Physics.gravity = cube.transform.position - transform.position;

        



        //var main = ps.main;
        //rotation = main.startRotation;


        //var tempDir = transform.position - prevPos;
        //if (tempDir.magnitude > 0.001f) {
        //    currentDirection = tempDir;
        //} 

        //else {


        //    currentDirection = temp_vector;
        //} 


        //prevPos = transform.position;
        //currentDirection.y = 0;

    }
}
