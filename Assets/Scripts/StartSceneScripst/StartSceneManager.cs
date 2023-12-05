using UnityEngine;

public class StartSceneManager : MonoBehaviour
{

    [SerializeField] private GameObject _startObject;
    [SerializeField] private GameObject _PlayerView;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_startObject);
        Instantiate(_PlayerView);
    }

}
