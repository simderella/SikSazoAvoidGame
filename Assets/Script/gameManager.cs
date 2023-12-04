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
    int totalScore = 0;
    public Text scoreText;
    public Text timeText;
    public GameObject panel;

    public Text thisScoreTxt;   //�̹� ���� ��Ÿ����
    bool isRunning = true;

    public static gameManager I;
    void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeStrawberry", 0, 0.3f); //� �Լ��� �� �ʸ��� �߻���Ų��.
        initGame();
    }

    void makeStrawberry()
    {
        Instantiate(Strawberry);	//���⸦ �߻���Ų��.
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        thisScoreTxt.text = spendtime.ToString("N2"); //���߿� ���ķ� Ƚ�� ������ �� �߰��� �ȴٸ� spendtime�� �װɷ� ����.
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
        totalScore = 0;
        spendtime = 0.0f;
    }


}
