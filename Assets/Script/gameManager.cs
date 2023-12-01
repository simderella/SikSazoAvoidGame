using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        InvokeRepeating("makeStrawberry", 0, 0.5f); //어떤 함수를 몇 초마다 발생시킨다.
    }

    void makeStrawberry()
    {
        Instantiate(Strawberry);	//딸기를 발생시킨다.
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

    }
}
