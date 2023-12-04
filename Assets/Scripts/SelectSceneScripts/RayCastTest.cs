using UnityEngine;


public class RayCastTest : MonoBehaviour
{
    Camera cam;
    private Animator animator;
    int playerNum;
    int[] playerNumList =new int[] {1,2,3,4,5};
    public GameObject[] gameObjects;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        SelectPlayer();
    }
    public void SelectPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                playerNum = hit.transform.GetComponent<PlayerNum>().SelectNum;
                foreach (var p in playerNumList)
                {
                    animator = gameObjects[p - 1].GetComponent<Animator>();
                    playerNum = int.Parse(hit.transform.name.Substring(hit.transform.name.Length - 1));
                    animator.SetBool("Iswalk", playerNum == p);

                    if (playerNum == p)
                    {
                        PlayerPrefs.SetInt("PlayerSelect", p);
                        int a = PlayerPrefs.GetInt("PlayerSelect");
                    }
                }
            }
        }
    }
}
