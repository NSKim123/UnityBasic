using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateBase : IState
{
    protected GameObject owner;
    protected Func<bool> condition;
    protected AnimationWrapper animator;
    protected Movement movement;
        
    public int current { get; set; }
    public int id { get; set; }
    public bool canExecute => condition.Invoke() &&
                              animator.isPreviousStateFinished &&
                              animator.isPreviousMachineFinished;

    public List<KeyValuePair<Func<bool>, int>> transitions { get; set; }

    public CharacterStateBase(int id, GameObject owner, Func<bool> executeCondition, List<KeyValuePair<Func<bool>, int>> transitions)
    {
        this.id = id;
        this.owner = owner;
        this.condition = executeCondition;
        animator = owner.GetComponent<AnimationWrapper>();
        this.transitions = transitions;
        movement = owner.GetComponent<Movement>();

    }

    public virtual void Execute()
    {
        current= 0;
    }
    public virtual void Stop()
    {
        
    }
        
    public void MoveNext()
    {
        current++;
    }

    public virtual int Update()
    {
        int nextid = id;

        foreach (var transition in transitions)
        {
            if(transition.Key.Invoke())
            {
                nextid = transition.Value;
                break;
            }
        }

        return nextid;
    }

    
}
