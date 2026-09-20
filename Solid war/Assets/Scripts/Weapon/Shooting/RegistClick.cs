using Unity.VisualScripting;
using UnityEngine;

public sealed class RegistClick : MonoBehaviour
{
    [SerializeField] Shooting _shooting;
    public static RegistClick Instance { get; private set; }  

    private PlayerActionsInput _inputActions;
    public void Initialize()
    {
        Instance = this;
        _inputActions = new PlayerActionsInput();
        _inputActions.Enable();
        _inputActions.Combat.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _shooting.RegistShoting();
    }
}
