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
        //과일 랜덤하게 나타나게 하기
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        type = Random.Range(1, 3); //type을 만들어서 다양한 과일들 추가

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


        //transform.localScale = new Vector3(size, size, 0); //사이즈 변경이 필요할 때 사용
    }

    // Update is called once per frame
    void Update()
    {

    }


    //Collision을 가진 오브젝트가 다른 Collision 값을 가진 함수와 부딪혔을 때 무조건 실행
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Ground에 부딪히면 사라진다.
        if (coll.gameObject.tag == "Ground")
        {
            gameManager.I.addScore(score);
            Destroy(gameObject);
        }

        //Player와 부딪히면 게임 종료.
        if (coll.gameObject.tag == "Player")
        {
            gameManager.I.gameOver();
        }
    }
}
