using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public float floowSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        //Debug.Log(target.position);
        if (LevelManager.Instance.currentBird == null)
        {
            transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(0,transform.position.y,transform.position.z),
            floowSpeed * Time.deltaTime);
            return;
        }
        target = LevelManager.Instance.currentBird.transform;
        Follow();
    }
    void Follow()
    {
        float x = target.position.x;
        Vector3 pos = transform.position;
        //限制Camera在x轴的移动
        pos.x = Mathf.Clamp(x,0,15);
        //缓慢变化
        transform.position = Vector3.Lerp(
            transform.position,
            pos,
            floowSpeed * Time.deltaTime);
    }
}
