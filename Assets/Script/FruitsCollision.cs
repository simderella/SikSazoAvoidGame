using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //과일 랜덤하게 나타나게 하기
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);
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
            Destroy(gameObject);
        }

        //Player에 부딪히면 사라진다.
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
