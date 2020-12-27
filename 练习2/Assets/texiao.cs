using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
///
/// <summary>
public class texiao : MonoBehaviour 
{
    public GameObject tx;
    private float time;
    public float yctime=0.5f;

    public GameObject zd;
    private void Start()
    {
        if (Input.GetMouseButton(0))
        {
            sc();
        }
    }
    private void Update()
    {
        if (tx.activeInHierarchy&&Time.time>=yctime)
        {
            tx.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            xs(); 
        }
        if (Input.GetMouseButtonDown(0))
        {
            sc();
        }
    }

    private void sc()
    {
        Instantiate(zd, transform.position, Quaternion.identity);
    }

    private void xs()
    {
        tx.SetActive(true);
        time=Time.time +yctime;
    }
}
