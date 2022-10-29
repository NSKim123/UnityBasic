using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDie : StateBase
{
    public StateDie(StateMachine.StateType machineType, StateMachine machine) : base(machineType, machine)
    {
    }

    public override bool IsExecuteOK => Machine.Current != StateMachine.StateType.Attack;

    public override void Execute()
    {
        Machine.IsMovable = false;
        Machine.IsDirectionChangable = false;
        Current = IState.Commands.Prepare;
    }

    public override void FixedUpdate()
    {

    }

    public override void ForceStop()
    {
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
                    AnimationManager.Play("Die");
                    Machine.StopMove();
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
