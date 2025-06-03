using UnityEngine;

[RequireComponent(typeof(Animator))]

//������ ������
public class PlayerJumpBandit : MonoBehaviour
{
    //�������� �������
    private string _boolJumpAnimation = "Jump"; // �������� ��� ���������
    private bool _isJump = false;               // ��������� ������
    private Animator _animator;                 // ���������

    private void Awake()
    {
        //�������� ���������
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Jump();
    }

    //����� ������
    private void Jump()
    {
        //�������� ��������� �� ������������� ������
        _isJump = PlayerBandit.Instance.GetIsJump();

        //���������� ������
        if (_isJump)        
            _animator.SetBool(_boolJumpAnimation, true);        
        else        
            _animator.SetBool(_boolJumpAnimation, false);        
    }
}
