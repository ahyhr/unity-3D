using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///
/// <summary>
public class Findlines : MonoBehaviour 
{
    public Wayline[] lines;
    public GameObject[] Gob;
    private void Start()
    {
        Findline();
        for (int i = 0; i <3; i++)
        {
            InvokeRepeating("sc", 0, Random.Range(0,5));
        }
       
    }
    private void sc()
    {
        Wayline[] ky = Kylines();
        Wayline line = ky[Random.Range(0,ky.Length)];
        GameObject go=Instantiate(Gob[Random.Range(0,Gob.Length)], line.Waypoints[0], Quaternion.identity)as GameObject;
        xunlu xunlu=go.GetComponent<xunlu>();
        xunlu.line = line;
    }

    private Wayline[] Kylines()
    {
        List<Wayline> list = new List<Wayline>(lines.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            list.Add(lines[i]);
        }
        return list.ToArray();
    }

    private void Findline()
    {
        lines = new Wayline[transform.childCount];
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = new Wayline();
            lines[i].Waypoints = new Vector3[transform.GetChild(i).childCount];
            for (int point = 0; point < transform.GetChild(i).childCount; point++)
            {
                lines[i].Waypoints[point] = transform.GetChild(i).GetChild(point).position;
                print("01");
            }
        }
    }

}
