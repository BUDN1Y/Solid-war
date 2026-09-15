using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private int _fireSpide;
    [SerializeField] private int _damageWeapon;
    [SerializeField] private int _countAmmo;
    [SerializeField] private int _timeReloding;

    private int _currentCountAmmo;
    private PlayerActionsInput _inputActions;
    private void Awake()
    {
        _inputActions = new PlayerActionsInput();
        _inputActions.Enable();
        _inputActions.Combat.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("выстрел");
    }

    private void Fare()
    {

    }
}
