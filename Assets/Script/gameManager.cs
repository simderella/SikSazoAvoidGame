using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Threading;
using UnityEngine.SocialPlatforms;

public class gameManager : MonoBehaviour
{
    public GameObject Strawberry;
    public GameObject endPanel;
    float spendtime;
    int totalScore;
    public Text scoreText;
    public Text timeText;
    public GameObject panel;

    public Text thisScoreTxt;   //이번 점수 나타내기
    bool isRunning = true;

    public static gameManager I;
    void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeStrawberry", 0, 0.5f); //어떤 함수를 몇 초마다 발생시킨다.
        initGame();
    }

    void makeStrawberry()
    {
        Instantiate(Strawberry);	//딸기를 발생시킨다.
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        thisScoreTxt.text = spendtime.ToString("N2"); //나중에 탕후루 횟수 오르는 게 추가가 된다면 spendtime를 그걸로 변경.
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

        if(isRunning)   //점수의 시간차 없애기.
        {
            spendtime += Time.deltaTime;
            timeText.text = spendtime.ToString("N2");
        }
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
