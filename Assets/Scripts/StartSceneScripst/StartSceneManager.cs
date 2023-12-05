using UnityEngine;

public class StartSceneManager : MonoBehaviour
{

    [SerializeField] private GameObject _startObject;
    [SerializeField] private GameObject _playerView;
    [SerializeField] private GameObject _musicObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_startObject);
        Instantiate(_playerView);
        Instantiate(_musicObject);
    }

}
