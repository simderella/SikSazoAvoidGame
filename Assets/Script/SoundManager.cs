using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource sound_player;
    public Slider sound_slider;
    public GameObject _SoundOff;
    public GameObject _SoundOn;


    private void Awake()
    {
        sound_player = GameObject.Find("SoundPlayer").GetComponent<AudioSource>();
        sound_slider = sound_slider.GetComponent<Slider>();

        sound_slider.onValueChanged.AddListener(ChangsSound);

    }

    void ChangsSound(float value) //���� ����
    {
        sound_player.volume = value;
    }

    void SoundOff() //����
    {
        _SoundOff.SetActive(false);
        _SoundOn.SetActive(true);
        sound_player.enabled = false;
    }
    void SoundOn() //��
    {
        _SoundOff.SetActive(true);
        _SoundOn.SetActive(false);
        sound_player.enabled = true;
    }

}



