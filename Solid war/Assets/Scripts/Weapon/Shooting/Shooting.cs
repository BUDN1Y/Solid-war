using System;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int _damege;
    [SerializeField] private int _ataceSped;
    [SerializeField] private int _linesFire;
    [SerializeField] private int _storeÑartridges;
    [SerializeField] private int _totalNumberÑartridges;
    [SerializeField] private WeaponVisual _weaponVisual;


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
        if(_lineRenderer.positionCount != 0)
        {
            _lineRenderer.positionCount = 0;
        }
        ShootingVisual();
    }

    private void ShootingVisual()
    {
        Vector2 startShoot = _vectorToLineMouse.GetVectorToLineMouse(transform.position);

        _lineRenderer.positionCount++;
        Vector2 posShoot = new Vector2() { x = _weaponVisual.GetAimPosition(), y = 0 }; 
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, posShoot);

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, startShoot);
    }
}
