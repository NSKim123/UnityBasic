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
    /// �ʱ�ȭ �̺�Ʈ
    /// Scene Load�� ȣ��( Game Object�� Ȱ��ȭ �Ǿ������� ȣ��)
    /// ���� monobehavior�� ��Ȱ��ȭ �Ǿ��־ ȣ��
    /// �Ϲ� Ŭ������ ������ ������� �ַ� ��� ( ������� �ʱ�ȭ ��)
    /// </summary>
    private void Awake()
    {
        
    }

    /// <summary>
    /// �ʱ�ȭ �̺�Ʈ
    /// Game Object�� Ȱ��ȭ �� �� ���� ȣ��
    /// </summary>
    private void OnEnable()
    {
        
    }

    /// <summary>
    /// ������ �󿡼� �ʱ�ȭ �̺�Ʈ
    /// Game Object�� �� MonoBehavior �� �߰������� ȣ�� (���� ȣ�⵵ ����)
    /// </summary>
    private void Reset()
    {
        
    }

    /// <summary>
    /// �� �����Ӹ��� ȣ��Ǵ� �̺�Ʈ
    /// </summary>
    private void Update()
    {
        
    }

    /// <summary>
    /// Fixed �����Ӹ��� ȣ��Ǵ� �̺�Ʈ
    /// ���������� ����Ǵ� ������ ó���Ҷ� ��� (��� ���ɿ� ������ ������ �ȵǴ� �����)
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
    /// �� ������ ���� ȣ��Ǵ� �̺�Ʈ
    /// Update() ���Ŀ� ȣ���
    /// Ư�� Camera �̵����� � ���
    /// </summary>
    private void LateUpdate()
    {
        
    }

    /// <summary>
    /// Gizmos : ����� ���� ���ؼ� ȭ��� �׷����� ��� �׷����� ���
    /// Gizmos �� ������ �� ������ �����ҋ����� ȣ��Ǵ� �Լ�
    /// </summary>
    private void OnDrawGizmos()
    {
        
    }

    /// <summary>
    /// �� MonoBehavior �� ������Ʈ�� ������ ���ӿ�����Ʈ�� ���õǾ������� ȣ��Ǵ� �Լ�
    /// </summary>
    private void OnDrawGizmosSelected()
    {

    }

    /// <summary>
    /// GUI : Graphical User interface
    /// GUI�� �̺�Ʈ���� �ڵ鸵�ϴ� �Լ�
    /// </summary>
    private void OnGUI()
    {
        
    }

    /// <summary>
    /// ���� �Ͻ�����/ �Ͻ����� ������ ȣ��
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// ���� ���õ� ������ ����ɶ� ȣ�� ( ���� ���� ���õǸ� true, ���� �����ϸ� false)
    /// </summary>
    /// <param name="focus"></param>
    private void OnApplicationFocus(bool focus)
    {
        
    }

    /// <summary>
    /// �� monobehavior �� ������Ʈ�� ������ ���� ������Ʈ�� ��Ȱ��ȭ �� �� ȣ��
    /// </summary>
    private void OnDisable()
    {
        
    }

    /// <summary>
    /// �� monobehavior �� ������Ʈ�� ������ ���ӿ�����Ʈ�� �ı��� �� ȣ��
    /// </summary>
    private void OnDestroy()
    {
        //�ٸ� ���� ������Ʈ�� �����ϴ� ������ ���� �ȵ�.
    }
}
