using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xianzhi : MonoBehaviour 
{
    private void Update()
    {
        float hor=Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        xz(hor, ver);
    }

    private void xz(float hor,float ver)
    {
        Vector3 pos=Camera.main.WorldToScreenPoint(transform.position);
        if (pos.x<=0&&hor<0||pos.x>=Screen.width&&hor>0)
        {
            hor = 0;
        }
        if (pos.y>=Screen.height)
        {
            pos.y = 0;
        }
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        transform.Translate(hor, 0, ver);
    }
}
