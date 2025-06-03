using UnityEngine;

[RequireComponent(typeof(Animator))]

//Скрипт атаки
public class PlayerAttackBandit : MonoBehaviour
{
    //Свойства скрипта
    private string _boolHitAnimation = "Hit";   // Параметр для аниматора
    private bool _isHit = false;                // Состояние удара
    private Animator _animator;                 // Компонент

    private void Awake()
    {
        //Получаем компонент
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Hit();
    }

    //Метод удара
    private void Hit()
    {
        //Получаем состояние из родительского класса
        _isHit = PlayerBandit.Instance.GetIsAttack();

        //Производим удар
        if (_isHit)        
            _animator.SetBool(_boolHitAnimation, true);        
        else        
            _animator.SetBool(_boolHitAnimation, false);
    }
}
