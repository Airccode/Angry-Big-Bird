using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Star star;
    public void ShowUIGameOver(int count)
    {
        this.gameObject.SetActive(true);
        star.ShowStar(count);
    }


}
