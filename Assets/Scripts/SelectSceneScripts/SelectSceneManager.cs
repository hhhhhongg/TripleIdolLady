using UnityEngine;

public class SelectSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private GameObject _playerView;
    GameObject _playerPrefebs;
    public GameObject MainCam;

    private void Awake()
    {
        Instantiate(_menu);
        Instantiate(_spawn);
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
