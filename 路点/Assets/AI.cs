using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class AI : MonoBehaviour 
{
    private luxian[] luxians;
    private void chazhaoluxian()
    {
        luxians = new luxian[transform.childCount];
        for (int i = 0; i < luxians.Length; i++)
        {
            Transform luxiange = transform.GetChild(i);
            luxians[i].keyong = true;
            luxians[i] = new luxian();
            luxians[i].Wayposint = new Vector3[luxiange.childCount];
            for (int point = 0; point < luxiange.childCount; point++)
            {
                luxians[i].Wayposint[point] = luxiange.GetChild(point).position;

            }

        }
    }
}
