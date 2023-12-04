using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject Strawberry, Apple, Orange, Banana, Cherry, Kiwi, Melon, Pineapple;
    public GameObject endPanel;
    float spendtime;
    int totalScore;
    public Text scoreText;
    public Text timeText;
    public GameObject panel;
    int type;

    public static gameManager I;
    void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeFruits", 0, 0.5f); //어떤 함수를 몇 초마다 발생시킨다.
        initGame();
    }

    void makeFruits()
    {
        type = Random.Range(1, 9);

        switch (type)
        {
            case 1:
                Instantiate(Strawberry);
                break;
            case 2:
                Instantiate(Apple);
                break;
            case 3:
                Instantiate(Orange);
                break;
            case 4:
                Instantiate(Banana);
                break;
            case 5:
                Instantiate(Cherry);
                break;
            case 6:
                Instantiate(Kiwi);
                break;
            case 7:
                Instantiate(Melon);
                break;
            case 8:
                Instantiate(Pineapple);
                break;
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        endPanel.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Strawberry")
        {
            gameManager.I.gameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spendtime += Time.deltaTime;
        if (spendtime > 10)
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            spendtime = 0.0f;
        }
        timeText.text = spendtime.ToString("N1");
    }
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    void initGame()
    {
        Time.timeScale = 1.0f;
        //totalScore = 0;
        spendtime = 0.0f;
    }
    public void addScore(int Score)
    {
        totalScore += Score;
    }

}
