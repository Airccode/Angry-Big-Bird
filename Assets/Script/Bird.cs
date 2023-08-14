using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isMouseDown = false;
    public bool IsMouseDown
    {
        get { return isMouseDown; }
    }
    public float maxDistance = 2;
    private Transform stickCenterPoint;
    private StickShot stickShot;
    public GameObject stick;

    //速度
    public float flySpeed = 20;

    private Rigidbody2D rd;

    public float maxHP = 100;
    private float currentHP;
    private SpriteRenderer spriteRenderer;
    public Sprite SpriteWounded1;
    public Sprite SpriteWounded2;
    public GameObject explosionPrefab;


    void Start()
    {
        stickCenterPoint = stick.GetComponent<StickShot>().centerPoint;
        stickShot = stick.GetComponent<StickShot>();
        rd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            Debug.Log("MouseDown");
            FollowCursor();
        }
    }
    private void FollowCursor()
    {
        //鼠标的屏幕坐标转世界坐标
        //注意由于是2D视角，但是是3D坐标，点击的时候小鸟Z会和Camera对应Z相等
        //这个时候是看不到小鸟的，因此要小鸟的Z保持不变

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;

        //计算鼠标到中心点的距离，如果超过最大距离则进行向量计算让小鸟在圆内
        //如果没超出最大距离，则直接将当前鼠标对应坐标点赋值给小鸟
        float distance = (pos - stickCenterPoint.position).magnitude;
        if(distance > maxDistance)
        {   //超出距离
            //当前点 = 起始点(中心点) + 鼠标相对起始点的方向 * 最大距离
            pos = (pos - stickCenterPoint.position).normalized * maxDistance +
                stickCenterPoint.position;
        }
        transform.position = pos;


    }
    private void OnMouseDown()
    {
        isMouseDown = true;
        stickShot.StartDrawLine();
        //Destroy(GameObject.FindObjectOfType("Chair"));
        Debug.Log("MouseDown");
    }
    private void OnMouseUp()
    {
        isMouseDown = false;
        stickShot.StopDrawLine();
        Shot();
        
    }
    void Shot()
    {
        rd.bodyType = RigidbodyType2D.Dynamic;
        Vector3 dir = stickCenterPoint.position - transform.position;
        //dir不进行单位化，自带了大小，方向，更符合皮筋物理效果
        //dir = dir.normalized;
        rd.velocity = dir * flySpeed;
        Invoke("Dead", 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float mass = 1;
        if (collision.otherRigidbody != null)
        {
            mass = collision.otherRigidbody.mass;
        }
        float damage = collision.relativeVelocity.magnitude * mass;
        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
        if (currentHP / maxHP < 2.0f / 3.0f)
        {
            if (SpriteWounded1 != null)
                spriteRenderer.sprite = SpriteWounded1;
        }
        if (currentHP / maxHP < 1.0f / 3.0f)
        {
            if (SpriteWounded2 != null)
                spriteRenderer.sprite = SpriteWounded2;
        }

    }
    void Dead()
    {   //小鸟死了，实例化explosion
        GameObject explosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //Destroy(explosion);
        //Destroy(explosion);
        Destroy(gameObject);
        LevelManager.Instance.LoadANewBird();
    }
    public void StartStimulated()
    {
        rd.simulated = true;
    }
    public void StopStimulated()
    {
        //if(rd == null)
            //rd = GetComponent<Rigidbody2D>();

        rd.simulated = false;
    }


}
