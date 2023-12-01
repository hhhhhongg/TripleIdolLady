using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    private GameObject _startObject;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_startObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SceneLode() 
    {
        SceneManager.LoadScene("SelectPlayerScene");
    } 
}
