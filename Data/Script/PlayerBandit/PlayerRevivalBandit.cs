using UnityEngine;

[RequireComponent(typeof(Animator))]

//������ �����������
public class PlayerRevivalBandit : MonoBehaviour
{
    private string _boolRevivalAnimation = "Revival";   // �������� ��� ���������
    private bool _isRevival = false;                    // ��������� ������
    private bool _isDeath = false;                      // ��������� �����������
    private Animator _animator;                         // ���������

    private void Awake()
    {
        //�������� ��������
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Revival();
    }

    //����� �����������
    private void Revival()
    {
        //�������� ��������� �� ������������� ������
        _isRevival = PlayerBandit.Instance.GetIsRevival();
        _isDeath = PlayerBandit.Instance.GetIsDeath();

        //���������� �����������
        if (_isRevival && !_isDeath)        
            _animator.SetBool(_boolRevivalAnimation, true);        
        else        
            _animator.SetBool(_boolRevivalAnimation, false);        
    }
}
