using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed = 3.0f;
    public float rotateSpeed = 200.0f;
    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");

    private float r => Input.GetAxis("Mouse X");



    /// <summary>
    /// 초기화 이벤트
    /// Scene Load시 호출( Game Object가 활성화 되어있을때 호출)
    /// 현재 monobehavior가 비활성화 되어있어도 호출
    /// 일반 클래스의 생성자 대용으로 주로 사용 ( 멤버변수 초기화 등)
    /// </summary>
    private void Awake()
    {
        
    }

    /// <summary>
    /// 초기화 이벤트
    /// Game Object가 활성화 될 때 마다 호출
    /// </summary>
    private void OnEnable()
    {
        
    }

    /// <summary>
    /// 에디터 상에서 초기화 이벤트
    /// Game Object에 이 MonoBehavior 를 추가했을때 호출 (임의 호출도 가능)
    /// </summary>
    private void Reset()
    {
        
    }

    /// <summary>
    /// 매 프레임마다 호출되는 이벤트
    /// </summary>
    private void Update()
    {
        
    }

    /// <summary>
    /// Fixed 프레임마다 호출되는 이벤트
    /// 물리연산이 적용되는 연산을 처리할때 사용 (기기 성능에 영향을 받으면 안되는 연산들)
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(h, 0.0f, v).normalized;
        Vector3 deltaMove = dir * movespeed * Time.deltaTime;
        //transform.position += deltaMove;
        transform.Translate(deltaMove);

        Vector3 deltaRotate = Vector3.up * r * rotateSpeed * Time.deltaTime;
        transform.Rotate(deltaRotate);
    }

    /// <summary>
    /// 매 프레임 마다 호출되는 이벤트
    /// Update() 이후에 호출됨
    /// 특히 Camera 이동연산 등에 사용
    /// </summary>
    private void LateUpdate()
    {
        
    }

    /// <summary>
    /// Gizmos : 디버깅 등을 위해서 화면상에 그려지는 모든 그래픽적 요소
    /// Gizmos 에 렌더링 할 내용을 연산할떄마다 호출되는 함수
    /// </summary>
    private void OnDrawGizmos()
    {
        
    }

    /// <summary>
    /// 이 MonoBehavior 를 컴포넌트로 가지는 게임오브젝트가 선택되었을때만 호출되는 함수
    /// </summary>
    private void OnDrawGizmosSelected()
    {

    }

    /// <summary>
    /// GUI : Graphical User interface
    /// GUI의 이벤트들을 핸들링하는 함수
    /// </summary>
    private void OnGUI()
    {
        
    }

    /// <summary>
    /// 어플 일시정지/ 일시정지 해제시 호출
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// 현재 선택된 어플이 변경될때 호출 ( 지금 어플 선택되면 true, 딴거 선택하면 false)
    /// </summary>
    /// <param name="focus"></param>
    private void OnApplicationFocus(bool focus)
    {
        
    }

    /// <summary>
    /// 이 monobehavior 를 컴포넌트로 가지는 게임 오브젝트가 비활성화 될 때 호출
    /// </summary>
    private void OnDisable()
    {
        
    }

    /// <summary>
    /// 이 monobehavior 를 컴포넌트로 가지는 게임오브젝트가 파괴될 때 호출
    /// </summary>
    private void OnDestroy()
    {
        //다른 게임 오브젝트를 생성하는 로직을 쓰면 안됨.
    }
}
