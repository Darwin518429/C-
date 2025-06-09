using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamnarBoss : StateMachineBehaviour
{
    private Boss boss;
    private Rigidbody2D rb2D;

    [SerializeField] private float velocidadMovimiento;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        rb2D = boss.rb2D;
        boss.MirarJugador();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.fullPathHash != Animator.StringToHash("Base Layer.Distancia") &&
            stateInfo.fullPathHash != Animator.StringToHash("Base Layer.Cuerpo"))
        {
            rb2D.velocity = new Vector2(velocidadMovimiento, rb2D.velocity.y) * animator.transform.right;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
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
