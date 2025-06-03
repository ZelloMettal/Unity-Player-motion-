using UnityEngine;

[RequireComponent(typeof(Animator))]

//������ �����
public class PlayerAttackBandit : MonoBehaviour
{
    //�������� �������
    private string _boolHitAnimation = "Hit";   // �������� ��� ���������
    private bool _isHit = false;                // ��������� �����
    private Animator _animator;                 // ���������

    private void Awake()
    {
        //�������� ���������
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Hit();
    }

    //����� �����
    private void Hit()
    {
        //�������� ��������� �� ������������� ������
        _isHit = PlayerBandit.Instance.GetIsAttack();

        //���������� ����
        if (_isHit)        
            _animator.SetBool(_boolHitAnimation, true);        
        else        
            _animator.SetBool(_boolHitAnimation, false);
    }
}
