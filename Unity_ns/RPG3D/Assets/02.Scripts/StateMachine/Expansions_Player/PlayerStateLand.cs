using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateLand : CharacterStateBase
{
    
    public PlayerStateLand(int id, GameObject owner, Func<bool> executeCondition, List<KeyValuePair<Func<bool>, int>> transition) : base(id, owner, executeCondition, transition)
    {

    }

    public override void Execute()
    {
        base.Execute();
        movement.mode = Movement.Mode.Auto;
        animator.SetBool("doLand", true);
    }

    public override void Stop()
    {
        base.Stop();
        animator.SetBool("doLand", false);
    }

    public override int Update()
    {
        return animator.GetNormalizedTime() >= 1.0f ? base.Update() : id;
    }
}
