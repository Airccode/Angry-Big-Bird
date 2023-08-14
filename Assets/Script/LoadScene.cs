using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Scene0()
    {
        SceneManager.LoadScene("StartUI");

    }
    public void Scene1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Scene4()
    {
        SceneManager.LoadScene("Level1");
    }
}
