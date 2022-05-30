using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleVarNPC : StateMachineBehaviour
{
    [SerializeField] 
    private float _timeUntilVar;

    [SerializeField]
    private int _numOfVarIdle;

    private bool _isBored;
    private float _idleTime;
    private int _boredAnim;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_isBored == false)
        {
            _idleTime += Time.deltaTime;

            if (_idleTime > _timeUntilVar && stateInfo.normalizedTime % 1 < 0.02f)
            {
                _isBored = true;
                _boredAnim = Random.Range(1, _numOfVarIdle + 1);
                _boredAnim = _boredAnim * 2 - 1;

                animator.SetFloat("IdleVar", _boredAnim - 1);
            }
        }
        else if(stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle();
        }

        animator.SetFloat("IdleVar", _boredAnim, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        if (_isBored)
        {
            _boredAnim--;
        }

        _isBored = false;
        _idleTime = 0;
    }
}
