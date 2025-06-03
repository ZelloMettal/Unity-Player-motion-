using UnityEngine;

[RequireComponent(typeof(Animator))]

//Скрипт смерти
public class PlayerDeathBandit : MonoBehaviour
{
    //Свойства скрипта 
    private string _boolDeathAnimation = "Death";   // Параметр для аниматора
    private bool _isDeath = false;                  // Состояние смерти
    private Animator _animator;                     // Компонент

    private void Awake()
    {
        //Получаем компонент
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Death();
    }

    //Метод смерти
    private void Death()
    {
        //Получаем состояние из родительского класса
        _isDeath = PlayerBandit.Instance.GetIsDeath();

        //Производим смерт
        if (_isDeath)        
            _animator.SetBool(_boolDeathAnimation, true);
        
        else        
            _animator.SetBool(_boolDeathAnimation, false);        
    }
}
