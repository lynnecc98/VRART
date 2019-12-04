using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Title : MonoBehaviour
{

    public GameObject TitleScreen;
    private bool Show = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAndHideInfo()
    {
        if (!Show)
        {
            TitleScreen.SetActive(true);
            Show = true;
        }
        else {
            TitleScreen.SetActive(false);
            Show = false;
        }
    }
}