using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
///
/// <summary>
public class dazji : MonoBehaviour 
{
    private Text te;
    private string words;
    private float time;
    public float speed;
    public bool open=false;

    private void Start()
    {
        te = GetComponent<Text>();
        words = te.GetComponent<Text>().text;
    }

    private void Update()
    {
        dzj();
        //textcolor();
    }

    private  void dzj()
    {
        if (open)
        {
            time += Time.deltaTime;
            te.text = words.Substring(0, (int)(speed * time));
        }
            
    }

    public void dazhi()
    {
        open = true;
    }
    private void textcolor()
    {
        time += Time.deltaTime;
        te.text = string.Format("<color=#FF0000FF>{0}</color>{1}", words.Substring(0, (int)(speed * time)),words.Substring(words.Length- (int)(speed * time)), (int)(speed * time));

    }

}
