using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class dong : MonoBehaviour 
{
    public float speed = 10;
    private void FixedUpdate()
    {
        this.transform.Rotate(0, speed*Time.fixedDeltaTime, 0);
    }

}
