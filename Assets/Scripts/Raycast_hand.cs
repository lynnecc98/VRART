using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast_hand : MonoBehaviour
{
    public LineRenderer raycastVisualize;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f; 
    OvrAvatar ovrAvatar;
    GameObject cube;
    Vector3 hitPosition;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] raycastPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        hitPosition = Vector3.zero;
        raycastVisualize.SetPositions(raycastPositions);
        raycastVisualize.SetWidth(laserWidth, laserWidth);
        ovrAvatar = FindObjectOfType<OvrAvatar>();
        cube = GameObject.FindGameObjectWithTag("pos");
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawTouch.RIndexTrigger))
        {
            raycast(ovrAvatar.HandRight.transform.position, ovrAvatar.HandRight.transform.forward, laserMaxLength);
            raycastVisualize.enabled = true;
        }
        else
        {
            raycastVisualize.enabled = false;
        }
    }

    void raycast(Vector3 starting, Vector3 direction, float length)
    {
        Ray ray = new Ray(starting, direction);
        hitPosition = starting + (length * direction);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (raycastHit.collider.tag.Equals("Respawn"))
            {
                hitPosition = raycastHit.point;
                cube.transform.localPosition = hitPosition;
            }
        }
        else
        {
            hitPosition = starting + (length * direction);

        }
        raycastVisualize.SetPosition(0, starting);
        raycastVisualize.SetPosition(1, hitPosition);
    }
}