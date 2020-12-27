using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class sji : MonoBehaviour 
{
    private GameObject diren;
    public float movespeed=100;

    private void Update()
    {
        transform.Translate(movespeed * Time.deltaTime, 0,0);
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

}
