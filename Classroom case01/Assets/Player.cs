using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class Player : MonoBehaviour 
{
    [HideInInspector]
    public Transform m_transform;
    // 角色控制器组件
    private CharacterController m_ch;
    // 角色移动速度
    public float m_movSpeed = 3.0f;
    // 重力
    public float m_gravity = 2.0f;
    public float jumpSpeed = 0.2f;
    private Vector3 moveDirection;
    // 生命值
    public int m_life = 5;

    // 摄像机Transform
    private Transform m_camTransform;
    // 摄像机旋转角度
    private Vector3 m_camRot;
    // 摄像机高度(即表示主角的身高)
    private float m_camHeight = 1.4f;


    // 枪口transform
    Transform m_muzzlepoint;
    // 射击时，射线能射到的碰撞层
    public LayerMask m_layer;
    // 射中目标后的粒子效果
    public Transform m_fx;
    // 射击音效
    public AudioClip m_audio;
    // 射击间隔时间计时器
    float m_shootTimer = 0;

    public GameObject light;
    private bool lightkg=false;

    private void Start()
    {
        m_transform = this.transform;
        // 获取角色控制器组件
        m_ch = this.GetComponent<CharacterController>();
        // 获取摄像机
        m_camTransform = Camera.main.transform;
        // 设置摄像机初始位置（使用TransformPoint获取Player在Y轴偏移一定高度的位置）
        m_camTransform.position = m_transform.TransformPoint(0, m_camHeight, 0);
        // 设置摄像机的旋转方向与主角一致
        m_camTransform.rotation = m_transform.rotation;
        m_camRot = m_camTransform.eulerAngles;
        //锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;

        m_muzzlepoint = m_camTransform.FindChild("M16/weapon/muzzlepoint").transform;
    }

    private void Update()
    {
        Control();

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lightkg)
            {
                light.SetActive(false);
            }
            else
            {
                light.SetActive(true);
            }
            lightkg = !lightkg;
        }

        // 更新射击间隔时间
        m_shootTimer -= Time.deltaTime;
        // 鼠标左键射击
        if (Input.GetMouseButton(0) && m_shootTimer <= 0)
        {
            m_shootTimer = 0.1f;
            //射击音效 
            this.GetComponent<AudioSource>().PlayOneShot(m_audio);
            // 减少弹药，更新弹药UI
            GameManager.Instance.SetAmmo(1);
            // RaycastHit用来保存射线的探测结果
            RaycastHit info;
            // 从muzzlepoint的位置，向摄像机面向的正方向射出一根射线
            // 射线只能与m_layer所指定的层碰撞
            bool hit = Physics.Raycast(m_muzzlepoint.position,
            m_camTransform.TransformDirection(Vector3.forward), out info, 100, m_layer);
            if (hit)
            {
                // 如果射中了Tag为enemy的游戏体
                if (info.transform.tag.CompareTo("enemy") == 0)
                {
                    Enemy enemy = info.transform.GetComponent<Enemy>();
                    // 敌人减少生命
                    enemy.OnDamage(1);
                }
                // 在射中的地方释放一个粒子效果
                Instantiate(m_fx, info.point, info.transform.rotation);
            }
        }
    }

    private void Control()
    {
        if (m_ch.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKeyDown(KeyCode.Space))
            {
               moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= m_gravity*Time.deltaTime;
        m_ch.Move(moveDirection * m_movSpeed * Time.deltaTime);
   

        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");
        // 旋转摄像机
        m_camRot.x -= rv;
        m_camRot.y += rh;
        m_camTransform.eulerAngles = m_camRot;
        // 使主角的面向方向与摄像机一致
        Vector3 camrot = m_camTransform.eulerAngles;
        camrot.x = 0; camrot.z = 0;
        m_transform.eulerAngles = camrot;
        // 使摄像机的位置与主角一致
        m_camTransform.position = m_transform.TransformPoint(0, m_camHeight, 0);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(this.transform.position, "Spawn.tif");
    }

    public void OnDamage(int damage)
    {
        m_life -= damage;
        // 更新UI
        GameManager.Instance.SetLife(m_life);
        // 如果生命为0，取消鼠标锁定
        if (m_life <= 0)
            Cursor.lockState = CursorLockMode.None;
    }


}
