using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

//Подвязываем компоненты к скрипту
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

//Скрипт перемещения 
public class PlayerRunBandit : MonoBehaviour
{
    //Определение направления движения персонажа
    private const string Horizontal = "Horizontal"; //Перемещение по горизонтали
    private const string Vertical = "Vertical";     //Перемещение по вертикали

    //Свойства скрипта
    private Rigidbody2D _rigidbody;                 //
    private Animator _animator;                     // Компоненты
    private SpriteRenderer _spriteRenderer;         //
    private Vector2 _moveVector;                    // Направление движения персонажа
    private string _boolMoveAnimation = "Move";     // Параметр для аниматора
    private bool _isRuning = false;                 // Состояние бега

    //Свойсво для Инспектора
    [SerializeField] private float _speed;  //Скорость персонажа

    private void Awake()
    {
        //Получаем компоненты
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
    }
    //Метод перемещения персонажа
    private void Move()
    {
        //Получаем состояние из родительского класса
        _isRuning = PlayerBandit.Instance.GetIsRuning();

        // Получаем данные нажатия кнопок
        _moveVector.x = Input.GetAxis(Horizontal);
        _moveVector.y = Input.GetAxis(Vertical);

        // Производим смещение персонажа
        if (_isRuning)
        {
            //Если перемещается
            _animator.SetBool(_boolMoveAnimation, true);
            _rigidbody.velocity = new Vector2(_moveVector.x * _speed * Time.deltaTime, _moveVector.y * _speed * Time.deltaTime);
            FlipX();
        }
        else 
        {
            //Если не перемещается
            _animator.SetBool(_boolMoveAnimation,false);
            _rigidbody.velocity = new Vector2(_moveVector.x, _moveVector.y);
        }
    }
    //Метод поворота персонажа в сторону перемещения
    private void FlipX()
    {
        // Определяем направление персонажа. Переворачиваем в зависимоости от изменения координат
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
