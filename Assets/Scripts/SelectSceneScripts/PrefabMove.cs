using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PrefabMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    private Vector3 moveDirection;

    public void setup(Vector3 direction)
    {
        moveDirection = direction;
    }
    private void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 150f) * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.Translate(new Vector2(-0.1f, 0));
    }

}
