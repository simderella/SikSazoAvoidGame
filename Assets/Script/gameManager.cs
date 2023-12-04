using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
    public GameObject Strawberry;
    public GameObject endPanel;


    public static gameManager I;
    void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeStrawberry", 0, 0.5f); //� �Լ��� �� �ʸ��� �߻���Ų��.
    }

    void makeStrawberry()
    {
        Instantiate(Strawberry);	//���⸦ �߻���Ų��.
    }


    public void gameOver()
    {
        Time.timeScale = 0.0f;
        endPanel.SetActive(true);

    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
