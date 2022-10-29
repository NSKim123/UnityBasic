using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHurt : StateBase
{
    private Player _player;
    public StateHurt(StateMachine.StateType machineType, StateMachine machine) : base(machineType, machine)
    {
        _player = Machine.GetComponent<Player>();
    }

    public override bool IsExecuteOK => Machine.Current != StateMachine.StateType.Attack;

    public override void Execute()
    {
        _player.invinciable = false;
        Machine.IsMovable = false;
        Machine.IsDirectionChangable = false;
        Current = IState.Commands.Prepare;
    }

    public override void FixedUpdate()
    {
        
    }

    public override void ForceStop()
    {
        _player.invinciable = false;
        Current = IState.Commands.Idle;
    }

    public override StateMachine.StateType Update()
    {
        StateMachine.StateType next = MachineType;

        switch (Current)
        {
            case IState.Commands.Idle:
                break;
            case IState.Commands.Prepare:
                {
                    AnimationManager.Play("Hurt");
                    MoveNext();
                }
                break;
            case IState.Commands.Casting:
                {
                    MoveNext();
                }
                break;
            case IState.Commands.OnAction:
                {
                    if (AnimationManager.GetNormalizedTime() > 1.0f)
                        MoveNext();
                }
                break;
            case IState.Commands.Finish:
                {
                    next = StateMachine.StateType.Idle;
                }
                break;
            default:
                break;
                
        }
        return next;
    }

    
}
