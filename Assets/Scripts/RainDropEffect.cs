using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDropEffect : MonoBehaviour
{
    Light directionalLight;
    Color directionalLightColor;
    Color blueLight;
    Color brightLight;
    bool isGettingBright = false;
    public float elapsedTime;
    public float duration = 10;

    Color shaftStartColor, shaftColor;

    GameObject sunShaft;


    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GetComponentInChildren<Light>();
        sunShaft = GameObject.FindGameObjectWithTag("sunShaft");

        //starting light color
        blueLight = new Color(0.3f, 0.7f, 1);

        //brightened color 
        brightLight = new Color(0.97f,0.87f,0.7f);
        directionalLight.color = blueLight;
        elapsedTime = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        float interpolateRate = Mathf.PingPong(elapsedTime / duration, 1);

        directionalLight.color = Color.Lerp(blueLight, brightLight, interpolateRate);
        if(interpolateRate > 0.8f)
        {
            sunShaft.SetActive(true);
        }
        else
        {
            sunShaft.SetActive(false);
        }
        

        if (isGettingBright)
        {
            elapsedTime += Time.deltaTime;

        }
        else
        {
            elapsedTime -= Time.deltaTime;
        }
        if (elapsedTime < 0) elapsedTime = 0;
        else if (elapsedTime > duration) elapsedTime = duration;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            isGettingBright = true;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            isGettingBright = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            isGettingBright = false;
        }

    }
}
