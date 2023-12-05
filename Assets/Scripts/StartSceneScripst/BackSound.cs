using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackSound : MonoBehaviour
{
    string _sceneName;

    private void Update()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        if (_sceneName =="StartScene"|| _sceneName == "SelectPlayerScene")
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
