using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    Scene scene = SceneManager.GetActiveScene();
    public void loadScene() 
    {
        if (scene.name == "StartScene")
        {
            SceneManager.LoadScene("SelectPlayerScene");
        }
        else if (scene.name == "SelectPlayerScene")
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (scene.name == "MainScene")
        {
            //SceneManager.LoadScene("EndScene");
        }
        
    }

}
