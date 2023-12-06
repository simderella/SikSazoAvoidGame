using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;


public class SoundoutBtn : MonoBehaviour
{
    public void TimeOn()
    {
        Time.timeScale = 1;
    }
    public void TimeOff()
    {
        Time.timeScale = 0;
    }    

}

