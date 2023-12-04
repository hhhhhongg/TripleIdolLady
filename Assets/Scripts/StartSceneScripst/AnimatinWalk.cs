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
        //씬 넘어가면 false로 변하나? 확인해보기 
    }
}
