using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AddScore : MonoBehaviour
{
    int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "tooth")
        {
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Ground")
        {
            gameManager.I.addScore(Score);
            Destroy(gameObject);
        }
    }
}
