using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///
/// <summary>
public class Pig : MonoBehaviour 
{
    public float maxSpeed=10;
    public float minSpeed=5;
    public Sprite hurt;
    public GameObject boom;
    public GameObject pigScore;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude>maxSpeed)//猪死亡
        {
            die();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)//受伤更换图片
        {
            GetComponent<SpriteRenderer>().sprite=hurt;
        }
    }

    void die()
    {
        Destroy(gameObject);
        Instantiate(boom,transform.position,Quaternion.identity);
        GameObject go=(GameObject)Instantiate(pigScore, transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(go, 1.5f);
    }
}
