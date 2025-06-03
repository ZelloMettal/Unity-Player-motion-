using UnityEngine;

[RequireComponent(typeof(Animator))]

//Скрипт прыжка
public class PlayerJumpBandit : MonoBehaviour
{
    //Свойства скрипта 
    private string _boolJumpAnimation = "Jump"; // Параметр для аниматора
    private bool _isJump = false;               // Состояние прыжка
    private Animator _animator;                 // Компонент

    private void Awake()
    {
        //Получаем компонент
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Jump();
    }

    //Метод прыжка
    private void Jump()
    {
        //Получаем состояние из родительского класса
        _isJump = PlayerBandit.Instance.GetIsJump();

        //Производим прыжок
        if (_isJump)        
            _animator.SetBool(_boolJumpAnimation, true);        
        else        
            _animator.SetBool(_boolJumpAnimation, false);        
    }
}
