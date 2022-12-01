using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : StateMachineBehaviour
{
    private BossCom Boss;
    private Rigidbody2D Rb_Boss;
    [SerializeField] private float Speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.GetComponent<BossCom>();
        Rb_Boss = Boss.Rb;

        Boss.LookPlayer();

        animator.SetInteger("Ramdom2", Random.Range(0, 2));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Rb_Boss.velocity = new Vector2(Speed,Rb_Boss.velocity.y) * animator.transform.right;
        if(Boss.Boss_Pos.position.x<Boss.Pl_Pos.position.x)
        {
            Rb_Boss.velocity = new Vector2(Speed, Rb_Boss.velocity.y);
        }
        else
        {
            Rb_Boss.velocity = new Vector2(-Speed, Rb_Boss.velocity.y);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rb_Boss.velocity = new Vector2(0, Rb_Boss.velocity.y);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
