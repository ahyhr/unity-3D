using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
///
/// <summary>
public class jj : MonoBehaviour 
{
    private Camera camerar;
    public float[] jingtou;
    private int index;
    public GameObject image;
    private void Start()
    {
        camerar = transform.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (index<jingtou.Length-1)
            {
                index++;
                image.SetActive(true);
            }
            else
            {
                index = 0;
                image.SetActive(false);
            }
            
        }
        camerar.fieldOfView = Mathf.Lerp(camerar.fieldOfView, jingtou[index], 5f*Time.deltaTime);
        if (Mathf.Abs(camerar.fieldOfView-jingtou[index])<0.1f)
        {
            camerar.fieldOfView = jingtou[index];
        }
    }
}
