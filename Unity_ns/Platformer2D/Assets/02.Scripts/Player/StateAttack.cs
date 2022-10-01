public class StateAttack : StateBase
{
    private GroundDetector _groundDetector;
    public StateAttack(StateMachine.StateType machineType, StateMachine machine) : base(machineType, machine)
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override bool IsExecuteOK { get; }

    public override void Execute()
    {
        
    }

    public override void FixedUpdate()
    {
        
    }

    public override void ForceStop()
    {
        
    }

    public override void MoveNext()
    {
        
    }

    public override StateMachine.StateType Update()
    {
        return MachineType;
    }
}