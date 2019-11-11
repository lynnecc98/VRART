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
    public Vector3 two_pos;

    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public GameObject cube;


    // Start is called before the first frame update
    void Start()
    {
        print("do something");
        two_pos = new Vector3(-12, -1, 22);
        cube = GameObject.FindGameObjectWithTag("pos");

        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Physics.gravity = cube.transform.position - transform.position;


        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                print(transform.position);
                //Instantiate(particle, transform.position, transform.rotation);
        }




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
