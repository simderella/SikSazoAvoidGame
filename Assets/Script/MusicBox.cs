using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;


public class MusicBox : MonoBehaviour
{
    [SerializeField] AudioSource music;

    public void OnMusic()
    {
        music.volume = music.volume == 0 ? (float)0.3f : 0;
    }

}

