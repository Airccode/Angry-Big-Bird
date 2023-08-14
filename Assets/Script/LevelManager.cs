using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    管理小鸟的生成，切换
    小鸟自身销毁由自身管理
 */
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    static readonly object padlock = new object();

    public List<GameObject> birdList;
    private GameObject[] pigList;
    private int pigCount;
    private int pigMaxCount;
    public StickShot stickShot;
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {

            return instance;
        }
    }
    public Bird currentBird;

    public UIGameOver uiGameOver;

    public Text text;
    private void Awake()
    {
        instance = this;
    }
    private LevelManager()
    {

    }
    /*
        这个gameObject用于加载小鸟，加载脚本的时候List确定了加载小鸟的顺序
        Start()的时候开始加载第一个小鸟
     */
    private void Start()
    {
        StopSimulated();
        LoadANewBird();
        pigList = GameObject.FindGameObjectsWithTag("Pig");
        pigCount = pigList.Length;
        pigMaxCount = pigList.Length;
        //text.text = pigCount.ToString();
    }
    private void Update()
    {
        //text.text = pigCount.ToString();
    }
    /*
        用于加载新小鸟
        return true;则加载成功
        return false;无新小鸟加载
     */
    public void LoadANewBird()
    {
        if(birdList != null && birdList.Count > 0)
        {
            Bird firstBird = birdList[0].GetComponent<Bird>();
            currentBird = firstBird;
            StartSimulated(firstBird);
            stickShot.SetBird(firstBird);
            birdList.RemoveAt(0);
        }else
        {
            currentBird = null;
            GameOver();
        }
    }
    public void RemovePig(GameObject obj)
    {
        if (obj.tag == "Pig")
        {
            //Debug.Log(obj.gameObject);
            pigCount--;
        }
        else
        {
            return;
        }
        
        
        if(pigCount <= 0)
        {
            // todo
            GameOver();
        }

    }
    private void StopSimulated()
    {
        foreach (GameObject obj in birdList)
        {
            obj.GetComponent<Bird>().StopStimulated();
        }
    }
    private void StartSimulated(Bird bird)
    {
        bird.StartStimulated();
    }

    void GameOver()
    {
        int starCount = 1;
        if (1.0f - (float)pigCount / pigMaxCount > 0.3333f)
            starCount = 1;
        if (1.0f - (float)pigCount / pigMaxCount > 0.6666f)
            starCount = 2;
        if (pigCount == 0)
            starCount = 3;
        uiGameOver.ShowUIGameOver(starCount);

    }
}
