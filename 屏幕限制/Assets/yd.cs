using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class yd : MonoBehaviour 
{
    public float speed;
    private Camera maincamera;
    private void Start()
    {
        maincamera = Camera.main;
    }
    private void Update()
    {
        float hor=Input.GetAxis("Horizontal");
        float ver=Input.GetAxis("Vertical");
        if (hor!=0||ver!=0)
        {
            yidong(hor * Time.deltaTime * speed, ver * Time.deltaTime * speed);
        }
       
    }

    private void yidong(float hor,float ver)
    {  
        Vector3 pos= maincamera.WorldToScreenPoint(transform.position);
        if (pos.x<=28&&hor<0||pos.x>=Screen.width-28&&hor>0)
        {
            hor = 0;
        }
        if (pos.y>=Screen.height)
        {
            pos.y = 0;
        }
        else if (pos.y<=0)
        {
            pos.y = Screen.height;
        }
        transform.position = maincamera.ScreenToWorldPoint(pos);
        transform.Translate(hor, 0, ver);
        

    }
}
