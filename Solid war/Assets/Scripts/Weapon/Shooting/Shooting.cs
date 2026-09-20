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
        ShootingVisual();
    }

    private void ShootingVisual()
    {
        Vector2 startShoot = _vectorToLineMouse.GetVectorToLineMouse(transform.position);

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, transform.position);

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, startShoot);
    }
}
