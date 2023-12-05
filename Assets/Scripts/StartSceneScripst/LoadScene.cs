using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    string _sceneName;

    public void loadScene()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        if (_sceneName == "StartScene")
        {
            Invoke("LoadSelectScene", 0.5f);
            
        }
        else if (_sceneName == "SelectPlayerScene")
        {
            Invoke("LoadMainScene", 0.5f);
            
        }

    }
    private void LoadSelectScene() 
    {
        SceneManager.LoadScene("SelectPlayerScene");
    }
    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
