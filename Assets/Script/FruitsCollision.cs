using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class FruitsCollision : MonoBehaviour
{
    int type;
    float size;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        //���� �����ϰ� ��Ÿ���� �ϱ�
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        type = Random.Range(1, 3); //type�� ���� �پ��� ���ϵ� �߰�

        if (type == 1)
        {
            //size = 0.5f;
            score = 1;
        }
        if (type == 2)
        {
            //size = 1f;
            score = 2;
        }


        //transform.localScale = new Vector3(size, size, 0); //������ ������ �ʿ��� �� ���
    }

    // Update is called once per frame
    void Update()
    {

    }


    //Collision�� ���� ������Ʈ�� �ٸ� Collision ���� ���� �Լ��� �ε����� �� ������ ����
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Ground�� �ε����� �������.
        if (coll.gameObject.tag == "Ground")
        {
            GameManager.I.addScore(score);
            Destroy(gameObject);
        }

        //Player�� �ε����� ���� ����.
        if (coll.gameObject.tag == "Player")
        {
            GameManager.I.gameOver();
        }
    }
}
