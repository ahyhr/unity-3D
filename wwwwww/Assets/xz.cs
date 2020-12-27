using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xz : MonoBehaviour 
{
    public GameObject cub;
    public ches HP;
    public int hp;
    private void Awake()
    {
       
    }
    private void Update()
    {
        hp=HP.HP;
        if (Input.GetKey(KeyCode.R))
        {
            xuanzhuan();
        }
    }

    private void xuanzhuan()
    {
        
        Vector3 vec=cub.transform.position - this.transform.position;
        
        //transform.rotation=Quaternion.LookRotation(vec,Vector3.right);
        transform.rotation=Quaternion.FromToRotation(Vector3.right, vec);
        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, qua, 1f * Time.deltaTime);
        //if (Quaternion.Angle(transform.rotation,qua)<=10)
        //{
        //    this.transform.rotation = qua;
        //}
    }
}
