using UnityEngine;

[RequireComponent(typeof(Animator))]

//������ ������
public class PlayerDeathBandit : MonoBehaviour
{
    //�������� �������
    private string _boolDeathAnimation = "Death";   // �������� ��� ���������
    private bool _isDeath = false;                  // ��������� ������
    private Animator _animator;                     // ���������

    private void Awake()
    {
        //�������� ���������
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Death();
    }

    //����� ������
    private void Death()
    {
        //�������� ��������� �� ������������� ������
        _isDeath = PlayerBandit.Instance.GetIsDeath();

        //���������� �����
        if (_isDeath)        
            _animator.SetBool(_boolDeathAnimation, true);
        
        else        
            _animator.SetBool(_boolDeathAnimation, false);        
    }
}
