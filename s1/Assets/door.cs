using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class door : MonoBehaviour
{
    private bool doorState = false;
    private Animation anim;
    private string animationName = "door";
    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }
    private void OnMouseDown()
    {
        if (doorState)//如果门是开启状态
        {
            //播放关门动画
            if (anim.isPlaying==false)
            {
                anim[animationName].time = anim[animationName].length;
            }
            anim[animationName].speed = -1;
        }
        else
        {
            //播放开门动画
            anim[animationName].speed = 1;
        }
        anim.Play();
        doorState = !doorState;

    }
}