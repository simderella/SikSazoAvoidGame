using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartBtn : MonoBehaviour
{
    public GameObject gamemode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        gamemode.SetActive(true);
        //SceneManager.LoadScene("MainScene");
    }

    public void ChooseGameMode()
    {
        SceneManager.LoadScene("MainScene");
    }
}
