using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class Enemy : MonoBehaviour 
{
    private Transform m_transform;
    // 主角
    private Player m_player;
    // 寻路组件
    private NavMeshAgent m_agent;
    //移动速度
    public float m_movSpeed = 2.5f;
    // 动画组件
    Animator m_ani;
    // 角色旋转速度
    float m_rotSpeed = 5.0f;
    //  计时器
    float m_timer = 2;
    // 生命值
    public int m_life = 5;

    void Start()
    {
        // 获取动画组件
        m_ani = this.GetComponent<Animator>();

        m_transform = this.transform;
        // 获得主角
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // 获得寻路组件
        m_agent = GetComponent<NavMeshAgent>();
        // 提定寻路器的行走速度
        m_agent.speed = m_movSpeed;
        // 设置寻路目标
        m_agent.SetDestination(m_player.m_transform.position);
    }

    // 生成点
    protected EnemySpawn m_spawn;



    private void Update()
    {


        m_timer -= Time.deltaTime;
        // 获取当前动画状态
        AnimatorStateInfo statInfo = m_ani.GetCurrentAnimatorStateInfo(0);
        //主角生命值为0
        if (m_player.m_life <= 0)
            return;

        //如果处于待机的时候
        if (statInfo.fullPathHash == Animator.StringToHash("Base Layer.idle") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("idle", false);
            // 待机一定时间
            if (m_timer > 0)
                return;
            // 如果距离主角小于1.5米，进入攻击动画状态
            if (Vector3.Distance(m_transform.position, m_player.m_transform.position) < 1.5f)
            {
                m_agent.ResetPath();
                m_ani.SetBool("attack", true);
            }
            else
            {
                // 重置定时器
                m_timer = 1;
                // 设置寻路目标点
                m_agent.SetDestination(m_player.m_transform.position);
                // 进入跑步动画状态
                m_ani.SetBool("run", true);
            }
        }

        //如果处于跑步状态
        if (statInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("run", false);
            // 每隔1秒重新定位主角的位置
            if (m_timer < 0)
            {
                m_agent.SetDestination(m_player.m_transform.position);
                m_timer = 1;
            }
            //距离主角小于1.5米，攻击主角
            if (Vector3.Distance(m_transform.position, m_player.m_transform.position) <= 1.5f)
            {
                //停止寻路
                m_agent.ResetPath();
                // 进入攻击状态
                m_ani.SetBool("attack", true);
            }
        }


        //如果处于攻击状态
        if (statInfo.fullPathHash == Animator.StringToHash("Base Layer.attack") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("attack", false);
            // 面向主角
            RotateTo();
            // 如果动画播完，重新进入待机状态
            if (statInfo.normalizedTime >= 1.0f)
            {
                m_ani.SetBool("idle", true);
                // 重置计时器
                m_timer = 2;
            }
        }

        if (statInfo.fullPathHash == Animator.StringToHash("Base Layer.death") &&
 !m_ani.IsInTransition(0))
        {
            // 当播放完成死亡动画
            if (statInfo.normalizedTime >= 1.0f)
            {
                // 加分
                GameManager.Instance.SetScore(100);
                // 销毁自身
                Destroy(this.gameObject);
            }
        }

        if (statInfo.fullPathHash == Animator.StringToHash("Base Layer.attack")
&& !m_ani.IsInTransition(0))
        {
            // 始终面向主角
            RotateTo();
            m_ani.SetBool("attack", false);
            // 当完成攻击动画
            if (statInfo.normalizedTime >= 1.0f)
            {
                // 进入待机状态
                m_ani.SetBool("idle", true);
                // 重置计时器
                m_timer = 2;
                // 更新主角的生命
                m_player.OnDamage(1);
            }
        }

        //更新敌人计数
        m_spawn.m_enemyCount--;

    }



    void RotateTo()
    {
        // 获取目标方向
        Vector3 targetdir = m_player.m_transform.position - m_transform.position;
        // 计算出新方向
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetdir, m_rotSpeed * Time.deltaTime, 0.0f);
        // 旋转至新方向
        m_transform.rotation = Quaternion.LookRotation(newDir);
    }


    public void OnDamage(int damage)
    {
        m_life -= damage;
        // 如果生命为0，进入死亡状态
        if (m_life <= 0)
        {
            m_ani.SetBool("death", true);
            //停止寻路
            m_agent.ResetPath();
        }
    }

    // 初始化敌人
    public void Init(EnemySpawn spawn)
    {
        m_spawn = spawn;
        // 该敌人的出生点增加计数
        m_spawn.m_enemyCount++;
    }



}



