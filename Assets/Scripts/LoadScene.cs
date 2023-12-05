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
            SceneManager.LoadScene("SelectPlayerScene");
        }
        else if (_sceneName == "SelectPlayerScene")
        {
            SceneManager.LoadScene("MainScene");
        }

    }
}
