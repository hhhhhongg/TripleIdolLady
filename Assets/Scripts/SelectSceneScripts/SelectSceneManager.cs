using UnityEngine;

public class SelectSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private GameObject _playerView;
    [SerializeField] private GameObject _enemy;
    GameObject _playerPrefebs;
    public GameObject MainCam;

    private void Awake()
    {
        Time.timeScale = 1f;
        Instantiate(_menu);
        Instantiate(_spawn);
        Instantiate(_enemy);
        _playerPrefebs = Instantiate(_playerView);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _playerPrefebs.transform.childCount; i++)
        {
            MainCam.GetComponent<RayCastTest>().gameObjects[i] = _playerPrefebs.transform.GetChild(i).gameObject;
        }
    }

}
