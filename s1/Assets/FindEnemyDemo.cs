using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class FindEnemyDemo : MonoBehaviour 
{
    private Enemy FindEnemyMinBuyDistance(Enemy[]allEnemy)
    {
        Enemy min = allEnemy[0];
        float minDistance = Vector3.Distance(this.transform.position, min.transform.position);
        for (int i = 1; i < allEnemy.Length; i++)
        {
            float NextDistance = Vector3.Distance(this.transform.position, allEnemy[i].transform.position);
            if (minDistance>NextDistance)
            {
                min = allEnemy[i];
                NextDistance = minDistance;
            }
        }
        return min;
    }

}
