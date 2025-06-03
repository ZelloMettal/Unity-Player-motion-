using UnityEditor.Tilemaps;
using UnityEngine;

//Подвязываем компоненты к скрипту 
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

//Глобальныый скрипт персонажа
public class PlayerBandit : MonoBehaviour
{   
    //Глобальный доступ к классу типа синглтон
    public static PlayerBandit Instance { get; private set; }

    //Определения клавиши управления
    private const int MouseLeftClick = 0;       // Левый клик мыши
    private KeyCode KeyJump = KeyCode.Space;    // Клавиша пробел
    private KeyCode KeyDeath = KeyCode.K;       // Клавиша К
    private KeyCode KeyRevival = KeyCode.R;     // Клавиша R

    //Свойства скрипта
    private Rigidbody2D _rigidbody; // Компоненнт персонажа
    private Vector2 _moveVector;    // Направление движения персонажа
   
    private bool _isRuning = false;     //Свойство состояния передвижения
    private bool _isAttack = false;     //Свойство состояния атаки
    private bool _isJump = false;       //Свойство состояния прыжка
    private bool _isDeath = false;      //Свойство состояния прыжка
    private bool _isRevival = false;    //Свойство состояния прыжка

    void Start()
    {
        //Создали объект синглтона
        Instance = this;

        //Получаем компоненты
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Run();
        Jump();
        Hit();        
        Death();
        Revival();
    }

    //Метод проверки переещения персонажа
    private void Run()
    {       
        if (_rigidbody.velocity.x != 0 || _rigidbody.velocity.y != 0)        
            _isRuning = true;        
        else
            _isRuning = false;        
    }

    //Метод проверки удара персонажа
    private void Hit()
    {        
        if (Input.GetMouseButton(MouseLeftClick))        
            _isAttack = true;        
        else         
            _isAttack = false;        
    }

    //Метод проверки прыжка персонажа
    private void Jump()
    {
        if (Input.GetKeyDown(KeyJump))        
            _isJump = true;        
        else        
            _isJump = false;        
    }

    //Метод проверки смерти персонажа
    private void Death()
    {
        if (Input.GetKeyDown(KeyDeath))        
            _isDeath = true;        
        else        
            _isDeath = false;        
    }

    //Метод проверки воскрешения персонажа
    private void Revival()
    {
        //Проверяем был ли совершон прыжок
        if (Input.GetKeyDown(KeyRevival))        
            _isRevival = true;        
        else        
            _isRevival = false;        
    }

    //Геттор состояния бега
    public bool GetIsRuning()
    {
        return _isRuning;
    }

    //Геттор состояния атаки
    public bool GetIsAttack()
    { 
        return _isAttack;
    }

    //Геттор состояния прыжка
    public bool GetIsJump()
    {
        return _isJump;
    }

    //Геттор состояния смерти
    public bool GetIsDeath()
    {
        return _isDeath;
    }

    //Геттор состояния воскрешения
    public bool GetIsRevival()
    {
        return _isRevival;
    }
}
