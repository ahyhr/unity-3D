using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class chaZhao : MonoBehaviour
{
    public float speed=10;

    private void Update()
    {
        //this.transform.Rotate(0, speed*Time.unscaledDeltaTime, 0);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("暂停"))
        {
            Time.timeScale = 0;
        }
        if (GUILayout.Button("继续"))
        {
            Time.timeScale = 1;
        }


        if (GUILayout.Button("查找最少血量"))
        {
            Enemy[] diRen =GameObject.FindObjectsOfType<Enemy>();
            Enemy min =ChaZhaoXueLiang(diRen);
            min.GetComponent<MeshRenderer>().material.color = Color.yellow;
            
        }

        if (GUILayout.Button("查找子/孙物体"))
        {
            var cube=TransformHelper.GetChild(this.transform,"Cube4");
            Debug.Log(cube);
            cube.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        if (GUILayout.Button("查找距离最近物体"))
        {
            Enemy[] enemy=GameObject.FindObjectsOfType<Enemy>();
            Enemy dis=FindEnemyMinBuyDistance(enemy);
            dis.GetComponent<MeshRenderer>().material.color = Color.black;

        }

    }







    private Enemy ChaZhaoXueLiang(Enemy[] diRen)
    {
        Enemy min = diRen[0];
        for (int i = 1; i < diRen.Length; i++)
        {
            if (min.HP>diRen[i].HP)
            {
                min = diRen[i];
            }
        }
        return min;
    }

    private Enemy FindEnemyMinBuyDistance(Enemy[] allEnemy)
    {
        Enemy min = allEnemy[0];
        float minDistance = Vector3.Distance(this.transform.position, min.transform.position);
        for (int i = 1; i < allEnemy.Length; i++)
        {
            float NextDistance = Vector3.Distance(this.transform.position, allEnemy[i].transform.position);
            if (minDistance > NextDistance)
            {
                min = allEnemy[i];
                minDistance = NextDistance;
            }
        }
        return min;
    }


}
