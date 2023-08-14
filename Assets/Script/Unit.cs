using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float maxHP;
    public float currentHP;
    private SpriteRenderer spriteRenderer;
    public Sprite SpriteWounded1;
    public Sprite SpriteWounded2;
    public GameObject explosionPrefab;
    public GameObject Score;
    private bool isDestory = false;

    void Start()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDestory = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        float mass = 1;
        if(collision.otherRigidbody != null)
        {
            mass = collision.otherRigidbody.mass;
        }
        //获取碰撞物体速度向量
        float damage = collision.relativeVelocity.magnitude * mass;
        currentHP = currentHP - damage;
        //根据当前生命值，选择适合的Sprite
        if(currentHP / maxHP < 2.0f / 3.0f)
        {
            if(SpriteWounded1 != null)
                spriteRenderer.sprite = SpriteWounded1;
        }
        if(currentHP / maxHP < 1.0f / 3.0f)
        {
            if(SpriteWounded2 != null)
                spriteRenderer.sprite = SpriteWounded2;
        }
        //obj的Hp过低，进行销毁,利用isDestory防止二次碰撞调用两次Dead()从而导致计数失败
        if (currentHP <= 0 && !isDestory)
        {
            isDestory = true;
            Dead();
            Destroy(gameObject);
        }
    }
    private void Dead()
    {   //实例化explosion和score进行播放
        GameObject explosion = GameObject.Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity
            );
        //Destroy(explosion);
        //Destroy(explosion);
        
        GameObject score = GameObject.Instantiate(
            Score,
            transform.position + Vector3.up,
            Quaternion.identity);
        
        LevelManager.Instance.RemovePig(gameObject);
        
    }

}
