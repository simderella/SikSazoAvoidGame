using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicBox : MonoBehaviour
{
    private Toggle toggle;
    private bool isOn;
    //GameObject musicBox = new GameObject("MusicBox");

    void IsMusicBox()
    {
        isOn = toggle.isOn;

        if (isOn)
        {
            isOn = false;
            //AudioClip.Play();
        }
        else
        {
            isOn = true;
            //AudioClip.Stop();
        }

    }
}
