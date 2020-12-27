using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class AutoDestroy : MonoBehaviour 
{
    public float timer = 1.0f;
    void Start()
    {
        Destroy(this.gameObject, timer);
    }
}
