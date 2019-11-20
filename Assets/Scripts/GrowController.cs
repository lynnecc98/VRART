using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowController : MonoBehaviour
{
    //public GameObject treesPrefab;
    //public GameObject flowersPrefab;
    public GameObject naturePrefab;

    public float x = 0.01f;
    public float y = 0.01f;
    public float z = 0.01f;

    private float timer = 0f;
    private bool growing = false;

    private int harvestCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (true) {
            GameObject natureSpawn = Instantiate(naturePrefab);
            natureSpawn.transform.position = new Vector3(0, 0, 0);
            natureSpawn.transform.localScale += new Vector3(x, y, z);
            natureSpawn.transform.position += new Vector3(0f, y / 2);
            timer += 0.1f;

            if (timer >= 10)
            {
                growing = false;
                Destroy(natureSpawn, 5);
                harvestCount++;
            }
        }
    }
}
