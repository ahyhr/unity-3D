using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class shengcheng : MonoBehaviour 
{
    public GameObject[] go;
    private float time;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            int random = Random.Range(0, go.Length);
            int y=Random.Range(0, 10);
            int x = Random.Range(0, 10);
            int z = Random.Range(0, 10);

            Instantiate(go[random],new Vector3(x,y,z), Quaternion.identity);
            

        }
        
    }

}
