using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    private void Update()
    {
        
    }
    public void raycost() 
    {
        Debug.Log(hit.transform.gameObject);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "player") 
            {
                //애니메이션
            }
        }
    }
}
