using UnityEngine;

public class AnimatinWalk : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }
    private void Start()
    {
        animator.SetBool("Iswalk", true);
        //�� �Ѿ�� false�� ���ϳ�? Ȯ���غ��� 
    }
}
