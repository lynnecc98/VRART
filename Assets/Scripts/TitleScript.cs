using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleScript : MonoBehaviour
{

    public GameObject TitleScreen;
    private bool Show = false;
    private bool timerOn = true;
    public int counter = 0;
    public int disappearTime = 80 * 1000000;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn) {
            counter++;
        }
        
        if (counter >= disappearTime) {
            timerOn = false;
            TitleScreen.SetActive(false);
        }

    }

    public void ShowAndHideInfo()
    {
        if (!Show)
        {
            TitleScreen.SetActive(true);
            Show = true;
        }
        else
        {
            TitleScreen.SetActive(false);
            Show = false;
        }
    }
}