using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///
/// <summary>
public class FindLine : MonoBehaviour 
{
    public Wayline[] lines;
    public GameObject gameob;

    private void Start()
    {
        FindLuXian();
        for (int i = 0; i < 4; i++)
        {
            sc();
        }
        
    }

    private void sc()
    {
        Wayline[] kyluxian=KYline();
        Wayline line=kyluxian[Random.Range(0, kyluxian.Length)];
        GameObject go=Instantiate(gameob, line.waypoints[0], Quaternion.identity)as GameObject;
        xunlu xunlu=go.GetComponent<xunlu>();
        xunlu.line = line;
        xunlu.line.isus = false;
    }

    private void FindLuXian()
    {
        lines = new Wayline[transform.childCount];
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = new Wayline();
            lines[i].isus = true;
            lines[i].waypoints = new Vector3[transform.GetChild(i).childCount];
            for (int point = 0; point < transform.GetChild(i).childCount; point++)
            {
                lines[i].waypoints[point] = transform.GetChild(i).GetChild(point).position;
            }
        }
    }

    private Wayline[] KYline()
    {
        List<Wayline> list = new List<Wayline>(lines.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].isus)
            {
                list.Add(lines[i]);
            }
        }
        return list.ToArray();
    }

}
