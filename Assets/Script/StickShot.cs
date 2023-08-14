using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StickShot : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer leftLineRenderer;
    public LineRenderer rightLineRenderer;

    public Transform leftPoint;
    public Transform rightPoint;
    public Transform centerPoint;

    private Transform bird;

    private bool isDraw;

    void Start()
    {
        //bird = GameObject.FindGameObjectWithTag("Player").transform;
        isDraw = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraw)
        {
            DrawLine();
        }
            
    }
    public void StopDrawLine()
    {
        isDraw = false;
        leftLineRenderer.enabled = false;
        rightLineRenderer.enabled = false;
    }
    public void StartDrawLine()
    {
        isDraw = true;
        leftLineRenderer.enabled = true;
        rightLineRenderer.enabled = true;
    }
    void DrawLine()
    {
        //给对应Index的坐标赋值连线
        leftLineRenderer.SetPosition(0, leftPoint.position);
        leftLineRenderer.SetPosition(1, bird.position);
        rightLineRenderer.SetPosition(0, bird.position);
        rightLineRenderer.SetPosition(1, rightPoint.position);
    }

    public void SetBird(Bird bird)
    {
        this.bird = bird.transform;
        bird.transform.position = centerPoint.position;
        StartDrawLine();
    }
}
