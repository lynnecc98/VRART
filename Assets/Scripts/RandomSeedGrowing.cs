using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSeedGrowing : MonoBehaviour
{
    public float seedSize = 1;
    public int growingTime = 3; //비 올 때 다 자랄때 까지 걸리는 시간
    public int shrinkTime = 10; //다시 수축하는 데 걸리는 시간
    public float age;

    public float maxScale = 1.0f;
    public float minScale = 0.1f;
    public float scaleFactor;
    public Vector3 defaultScale;
    public Vector3 position;
    public float defaultY_pos = 0;
    public bool isRainDrop = false;
    GameObject randomPlant;
    private bool isRegenerated = false;

    private string[] plantList = { "BluePoppyCluster", "Bush_A", "Bush_B", "ChervilCluster", "DaisyCluster", "DandelionCluster", "ElephantEar_A", "ElephantEar_B", "FAE_Birch_A", "FAE_Birch_B", "FAE_Birch_C", "FAE_Spruce_A", "FAE_Spruce_B", "FAE_Spruce_C", "Fern", "Grass", "GrassPatch", "GrassTall", "GrassThick" };
    // Start is called before the first frame update
    void Start()
    {
        age = transform.localScale.x / seedSize;
        defaultScale = transform.localScale;

        scaleFactor = seedSize * age;
        position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        defaultY_pos = position.y + scaleFactor;

        transform.localScale = defaultScale * minScale;
        generateRandomPlant();
    }

    private void generateRandomPlant()
    {
        int randomSeed = (int)Random.Range(0, plantList.Length);
        if (randomSeed == plantList.Length) randomSeed--;

        randomPlant = (GameObject)Instantiate(Resources.Load(plantList[randomSeed]));

        randomPlant.layer = LayerMask.NameToLayer("Seed");
        randomPlant.transform.parent = transform;
        randomPlant.transform.localPosition = new Vector3(0, 0, 0);
        randomPlant.transform.localScale= new Vector3(1,1,1);
        isRegenerated = true;

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
                if (isRegenerated)
                {
                    isRegenerated = false;
                }
            }
        }
        else
        {
            age -= Time.deltaTime / shrinkTime;
            if (age < 0)
            {
                age = 0;
                if (!isRegenerated)
                {
                    Destroy(randomPlant);
                    generateRandomPlant();
                }

            }
        }

        scaleFactor = seedSize * age;
        if (scaleFactor < minScale) scaleFactor = minScale;
        transform.localScale = defaultScale * scaleFactor;


        //position.y = defaultY_pos - transform.localScale.y;
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
