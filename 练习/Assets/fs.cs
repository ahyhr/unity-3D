using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class fs : MonoBehaviour 
{
    public GameObject zd;
    private void Update()
    {
        float ve = Input.GetAxis("Vertical");
        transform.Translate(0, 0, ve);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(zd, transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale =1f;
        }
    }
    
   

}
