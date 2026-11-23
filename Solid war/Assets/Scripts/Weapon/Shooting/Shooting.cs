using Assets.Scripts.Weapon.Shooting.Interface;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Shooting : MonoBehaviour, IWeapon
{
    [SerializeField] private int _damage;
    [SerializeField] private int _attackSpeed;
    [SerializeField] private int _linesFire;
    [SerializeField] private int _storeÑartridges;
    [SerializeField] private int _totalNumberÑartridges;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private WeaponRotation _weaponRotation;


    private LineRenderer _lineRenderer;
    private VectorDirectionToMouse _vectorToLineMouse;
    private PlayerActionsInput _inputActions;
    
    public void Initialize()
    {
        _inputActions = new PlayerActionsInput();
        _inputActions.Enable();
        _inputActions.Combat.Shoot.performed += Shoot_performed;

        _lineRenderer = GetComponent<LineRenderer>();
        _vectorToLineMouse = new VectorDirectionToMouse();
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Âûñòðåë");
        if (_lineRenderer.positionCount != 0)
        {
            _lineRenderer.positionCount = 0;
        }
        Vector2 direction = _weaponRotation.GetVectorDirectionToMouse();
        ShootingReg(direction);
    }
        
    public void ShootingReg(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);
        ShootingVisual(direction, hit);
    }
    public void ShootingVisual(Vector2 direction, RaycastHit2D hit)
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, transform.position);

        if (hit.collider != null)
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, (Vector2)transform.position + direction * 50f);
        }

    }
}
