using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum StateType
    {
        Idle,
        Move,
        Jump,
        Fall,
        Attack,
        Crouch,
        EdgeGrab,
        LadderUp,
        LadderDown,
        Hurt,
        Die,
        EOF
    }
    public StateType Current;
    private Dictionary<StateType, StateBase> _states = new Dictionary<StateType, StateBase>();
    private StateBase _currentState;
    private bool _isStateChanged;
    private CharacterBase _character;
    private Rigidbody _rb;

    private float _h => Input.GetAxis("Horizontal");
    private float _v => Input.GetAxis("Vertical");
    private Vector2 _move;
    public bool IsMovable { get; set; }
    public bool IsDirectionChangable { get; set; }
    //-1 : left, 1 : right
    private int _direction;
    public int Direction
    {
        get 
        {
            return _direction; 
        }
        set
        {
            if(value<0)
            {
                _direction = -1;
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
            else
            {
                _direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
    }
    [SerializeField] private int _directionInit;

    public void ForceChangeState(StateType newStateType)
    {
        _currentState.ForceStop(); // 기존상태 중단
        _currentState = _states[newStateType]; //상태 갱신
        _currentState.Execute(); // 갱신된 상태 실행
        Current = newStateType;
    }
    public void StopMove()
    {
        _move.x = 0.0f;
    }

    public void SetMove(Vector2 move)
    {
        _move = move;
    }
    
    private void Awake()
    {
        _character= GetComponent<CharacterBase>();
        _rb=GetComponent<Rigidbody>();
        Init();
    }
    private void Init()
    {
        for (StateType stateType = StateType.Idle;  stateType < StateType.EOF ; stateType++)
        {
            AddState(stateType);
        }
        _currentState = _states[StateType.Idle];
        Current = StateType.Idle;

        IsDirectionChangable = true;
        IsMovable = true;

        RegisterShortCuts();
    }

    private void RegisterShortCuts()
    {
        InputHandler.RegisterKeyDownAction(KeyCode.DownArrow, () => ChangeState(StateType.LadderDown));
        InputHandler.RegisterKeyDownAction(KeyCode.UpArrow, () => ChangeState(StateType.LadderUp));

        InputHandler.RegisterKeyPressedAction(KeyCode.LeftAlt, () => ChangeState(StateType.Jump));        
        InputHandler.RegisterKeyPressedAction(KeyCode.DownArrow, () => ChangeState(StateType.Crouch));
        InputHandler.RegisterKeyPressedAction(KeyCode.A, () => ChangeState(StateType.Attack));
        InputHandler.RegisterKeyPressedAction(KeyCode.UpArrow, () => ChangeState(StateType.EdgeGrab));

    }

    private void AddState(StateType stateType)
    {
        //이미 상태가 등록 되었다면
        if (_states.ContainsKey(stateType))
            return;

        string stateName = Convert.ToString(stateType);
        string typeName = "State" + stateName;
        Debug.Log($"[StateMachine] : Adding state ...{stateName}");

        Type type = Type.GetType(typeName);

        if (type != null)
        {
            
            ConstructorInfo constructor = type.GetConstructor(new Type[]
            {
                typeof(StateType),
                typeof(StateMachine)
            });


            StateBase state
                = constructor.Invoke(new object[2]
                {
                    stateType, this
                })
                as StateBase;

            _states.Add(stateType, state);
            Debug.Log($"[StateMachine] : {stateName} state is successfully added");
        }
    }
    private void Update()
    {
        _isStateChanged = false;
        if (IsDirectionChangable)
        {
            if(_h<0.0f)
                Direction = Constants.DIRECTION_LEFT;
            else if(_h>0.0f)
                Direction = Constants.DIRECTION_RIGHT;
        }

        if (IsMovable)
        {
            _move.x = _h;

            if (Mathf.Abs(_move.x) > 0.0f)
                ChangeState(StateType.Move);
            else
                ChangeState(StateType.Idle);
        }          
        ChangeState(_currentState.Update());
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdate();
        transform.position += new Vector3(_move.x * _character.MoveSpeed, _move.y, 0.0f) * Time.fixedDeltaTime;
    }
    public bool ChangeState(StateType newStateType)
    {
        //이미 상태가 해당 프레임에서 한번 바뀌었다면
        if (_isStateChanged)
            return false;
        //상태가 바꾸지 않았으면
        if (Current == newStateType)
            return false;
        //바꾸려는 상태가 실행가능하지 않으면
        if (_states[newStateType].IsExecuteOK == false)
            return false ;

        
        _currentState.ForceStop(); // 기존상태 중단
        _currentState = _states[newStateType]; //상태 갱신
        _currentState.Execute(); // 갱신된 상태 실행
        Current = newStateType;
        _isStateChanged = true;
        return true;
    }
}
