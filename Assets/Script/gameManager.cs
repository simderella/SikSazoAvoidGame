using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Threading;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class gameManager : MonoBehaviour
{
    public GameObject Strawberry;
    public GameObject endPanel;
    float spendtime;
    int totalScore = 0;
    public Text scoreText;
    public Text timeText;
    public GameObject panel;

    public Text thisScoreTxt;   //�̹� ���� ��Ÿ����
    public Text maxScoreTxt;    //�ְ� ���� ��Ÿ����
    bool isRunning = true;

    public static gameManager I;
    void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("makeStrawberry", 0, 0.3f); //� �Լ��� �� �ʸ��� �߻���Ų��.
        initGame();
    }

    void makeStrawberry()
    {
        Instantiate(Strawberry);	//���⸦ �߻���Ų��.
    }

    public void gameOver()
    {
        isRunning = false;
        Time.timeScale = 0.0f;
        thisScoreTxt.text = spendtime.ToString("N1"); //���߿� ���ķ� Ƚ�� ������ �� �߰��� �ȴٸ� spendtime�� �װɷ� ����.
        endPanel.SetActive(true);

        if(PlayerPrefs.HasKey("bestScore") == false)    //�ְ� ���� ��Ÿ����
        {
            PlayerPrefs.SetFloat("bestScore", spendtime); //�� �κе� ���߿� ���ķ� ���� Ƚ���� ���� ����.
        }
        else
        {
            if(PlayerPrefs.GetFloat("bestScore") < spendtime)
            {
                PlayerPrefs.SetFloat("bestScore", spendtime);
            }
        }
        float maxScore = PlayerPrefs.GetFloat("bestScore"); //�ְ� ���� ����ֱ�
        maxScoreTxt.text =  maxScore.ToString("N1");
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
        if (spendtime > 60)
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            spendtime = 0.0f;
        }
        timeText.text = spendtime.ToString("N1");

        if(isRunning)   //������ �ð��� ���ֱ�.
        {
            spendtime += Time.deltaTime;
            timeText.text = spendtime.ToString("N1");
        }
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void initGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        spendtime = 0.0f;
    }

    public void addScore(int Score)
    {
        totalScore += Score;
        scoreText.text = totalScore.ToString();
    }

}
