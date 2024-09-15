using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("States")]
    public IdleState idleState;
    public JumpState jumpState;
    public RunState runState;

    // Referência ao PlayerController
    private PlayerController playerController;
    private State currentState;

    public void Start()
    {
        // Inicializando a referência ao PlayerController
        playerController = GetComponent<PlayerController>();
        currentState = idleState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Do();

        if (currentState.isComplete)
        {
            ChangeState(GetNextState());
        }
    }

    private State GetNextState()
    {
        if (playerController.isJumping)
        {
            return jumpState;
        }
        else if (playerController.direction.sqrMagnitude > 0)
        {
            return runState;
        }
        else
        {
            return idleState;
        }
    }

    
    private void ChangeState(State newState)
    {
        currentState.Exit();  
        currentState = newState; 
        currentState.Enter(); 
    }
}
