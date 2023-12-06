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
            Invoke("LodeSelect", 0.7f);
        }
        else if (_sceneName == "SelectPlayerScene")
        {
            Invoke("LodeMain", 0.7f);
        }
        else if (_sceneName == "MainScene") 
        {
            Invoke("LodeSelect",0);
        }

    }

    private void LodeSelect() 
    {
        SceneManager.LoadScene("SelectPlayerScene");
    }
    private void LodeMain()
    {
        SceneManager.LoadScene("MainScene");
    }


}
