using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //���� �����ϰ� ��Ÿ���� �ϱ�
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);
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
            Destroy(gameObject);
        }

        //Player�� �ε����� �������.
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
