using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StarLeft;
    public GameObject StarCenter;
    public GameObject StarRight;
    void Start()
    {
        //ShowStar(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowStar(int count)
    {
        StartCoroutine(Show(count));
    }
    IEnumerator Show(int count)
    {
        if(count > 0)
        {
            StarLeft.SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);
        if (count > 1)
        {
            StarCenter.SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);
        if (count > 2)
        {
            StarRight.SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);
    }
}
