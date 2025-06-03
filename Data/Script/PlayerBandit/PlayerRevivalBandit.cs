using UnityEngine;

[RequireComponent(typeof(Animator))]

//Скрипт возрождения 
public class PlayerRevivalBandit : MonoBehaviour
{
    private string _boolRevivalAnimation = "Revival";   // Параметр для аниматора
    private bool _isRevival = false;                    // Состояние смерти
    private bool _isDeath = false;                      // Состояние возрождения
    private Animator _animator;                         // Компонент

    private void Awake()
    {
        //Получаем компонен
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Revival();
    }

    //Метод возрождения
    private void Revival()
    {
        //Получаем состояние из родительского класса
        _isRevival = PlayerBandit.Instance.GetIsRevival();
        _isDeath = PlayerBandit.Instance.GetIsDeath();

        //Производим возрождение
        if (_isRevival && !_isDeath)        
            _animator.SetBool(_boolRevivalAnimation, true);        
        else        
            _animator.SetBool(_boolRevivalAnimation, false);        
    }
}
