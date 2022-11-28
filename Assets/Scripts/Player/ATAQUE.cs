using UnityEngine;

public class ATAQUE : StateMachineBehaviour
{
    PLMovement MOV;
    public float speed1, speed2;
    Rigidbody2D mrig;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(MOV==null)
        {
              MOV=animator.transform.parent.GetComponent<PLMovement>();
              mrig=animator.transform.parent.GetComponent<Rigidbody2D>(); 
        }
        mrig.Sleep();
        speed1 = MOV.NorSpeed;
        speed2 = MOV.RunSpeed;
        MOV.NorSpeed = 0.25f;
        MOV.RunSpeed = 0.25f;
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MOV.NorSpeed = 0.25f;
        MOV.RunSpeed = 0.25f;
    }

  
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MOV.NorSpeed = speed1;
        MOV.RunSpeed = speed2;
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
