using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBgButton : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objList;
    private Image imgComponent;
    void Start()
    {
        imgComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick()
    {
        foreach(GameObject obj in objList)
        {
            obj.SetActive(true);
        }
    }
}
