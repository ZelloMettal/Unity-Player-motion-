using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

//����������� ���������� � �������
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

//������ �����������
public class PlayerRunBandit : MonoBehaviour
{
    //����������� ����������� �������� ���������
    private const string Horizontal = "Horizontal"; //����������� �� �����������
    private const string Vertical = "Vertical";     //����������� �� ���������

    //�������� �������
    private Rigidbody2D _rigidbody;                 //
    private Animator _animator;                     // ����������
    private SpriteRenderer _spriteRenderer;         //
    private Vector2 _moveVector;                    // ����������� �������� ���������
    private string _boolMoveAnimation = "Move";     // �������� ��� ���������
    private bool _isRuning = false;                 // ��������� ����

    //������� ��� ����������
    [SerializeField] private float _speed;  //�������� ���������

    private void Awake()
    {
        //�������� ����������
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
    }
    //����� ����������� ���������
    private void Move()
    {
        //�������� ��������� �� ������������� ������
        _isRuning = PlayerBandit.Instance.GetIsRuning();

        // �������� ������ ������� ������
        _moveVector.x = Input.GetAxis(Horizontal);
        _moveVector.y = Input.GetAxis(Vertical);

        // ���������� �������� ���������
        if (_isRuning)
        {
            //���� ������������
            _animator.SetBool(_boolMoveAnimation, true);
            _rigidbody.velocity = new Vector2(_moveVector.x * _speed * Time.deltaTime, _moveVector.y * _speed * Time.deltaTime);
            FlipX();
        }
        else 
        {
            //���� �� ������������
            _animator.SetBool(_boolMoveAnimation,false);
            _rigidbody.velocity = new Vector2(_moveVector.x, _moveVector.y);
        }
    }
    //����� �������� ��������� � ������� �����������
    private void FlipX()
    {
        // ���������� ����������� ���������. �������������� � ������������ �� ��������� ���������
        if (_moveVector.x < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_moveVector.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y);
        }
    }
}
