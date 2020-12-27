using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
///
/// <summary>
public class hp : MonoBehaviour 
{
    public Slider sli;
    public int xl=100;
    public int damage=2;
    private void Start()
    {
        sli.maxValue = xl;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            sli.value -= damage;
        }
        else if (Input.GetMouseButton(1))
        {
            sli.value += damage;
        }
    }
}
