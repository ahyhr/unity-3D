using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///
/// <summary>
public class jianceline : MonoBehaviour 
{
    public Wayline[] lines;
    public GameObject cub;

    private void Start()
    {
        chazao();
        for (int i = 0; i < 3; i++)
        {
            Invoke("sc", 2f);
        }
    }
    private void sc()
    {
        Wayline[] kylj=kylines();
        Wayline line = kylj[Random.Range(0, kylj.Length)];
        GameObject go=Instantiate(cub, line.waypoints[0], Quaternion.identity) as GameObject;
        xunlu xunlu=go.GetComponent<xunlu>();
        xunlu.line = line;
        xunlu.line.isok = false;
    }
    private void chazao()
    {
        lines = new Wayline[transform.childCount];
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = new Wayline();
            lines[i].isok = true;
            lines[i].waypoints =new Vector3[transform.GetChild(i).childCount];
            for (int point = 0; point < transform.GetChild(i).childCount; point++)
            {
                lines[i].waypoints[point] = transform.GetChild(i).GetChild(point).position;
            }
        }
    }

    private Wayline[] kylines()
    {
        List<Wayline> list = new List<Wayline>(lines.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].isok)
            {
                list.Add(lines[i]);
            }
        }
        return list.ToArray();
    }
}
