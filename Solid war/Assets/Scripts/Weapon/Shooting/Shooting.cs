using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int _damege;
    [SerializeField] private int _ataceSped;
    [SerializeField] private int _linesFire;
    [SerializeField] private int _storeÑartridges;
    [SerializeField] private int _totalNumberÑartridges;
    [SerializeField] private WeaponVisual _weaponVisual;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private WeaponRotation _weaponRotation;


    private LineRenderer _lineRenderer;
    private VectorToLineMouse _vectorToLineMouse;

    public void Initialize()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _vectorToLineMouse = new VectorToLineMouse();
    }

    public void RegistShoting()
    {
        Debug.Log("Âûñòðåë");
        if (_lineRenderer.positionCount != 0)
        {
            _lineRenderer.positionCount = 0;
        }
        ShootingVisual();
    }

    private void ShootingVisual()
    {
        Vector2 origin = new Vector2()
        {
            x = transform.position.x,
            y = transform.position.y
        };

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        
        Vector2 direction = _weaponRotation.GetVectorDirectionToMouse();
             
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity);

        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, origin);

        if (hit.collider != null)
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, origin + direction * 50f);
        }

    }
}
