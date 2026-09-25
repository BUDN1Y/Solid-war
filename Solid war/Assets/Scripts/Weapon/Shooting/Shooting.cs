using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int _damege;
    [SerializeField] private int _ataceSped;
    [SerializeField] private int _linesFire;
    [SerializeField] private int _storeСartridges;
    [SerializeField] private int _totalNumberСartridges;
    [SerializeField] private WeaponVisual _weaponVisual;
    [SerializeField] private Camera mainCamera;


    private LineRenderer _lineRenderer;
    private VectorToLineMouse _vectorToLineMouse;

    public void Initialize()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _vectorToLineMouse = new VectorToLineMouse();
    }  

    public void RegistShoting()
    {
        Debug.Log("Выстрел");
        if(_lineRenderer.positionCount != 0)
        {
            _lineRenderer.positionCount = 0;
        }
        ShootingVisual();
    }

    private void ShootingVisual()
    {
        //Сам 100%
        //var x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x;
        //var y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y;

        //Debug.Log($"Позиция курсора по X мыши {x}, y {y}");

        //_lineRenderer.positionCount++;

        //Vector2 startShoot = new Vector2()
        //{
        //    x = transform.position.x,
        //    y = transform.position.y
        //};
        //_lineRenderer.SetPosition(_lineRenderer.positionCount - 1, startShoot);

        //Debug.Log($"начало огня {startShoot}");


        //_lineRenderer.positionCount++;

        //Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        //Vector3 posShoot = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0));
        //_lineRenderer.SetPosition(_lineRenderer.positionCount - 1, posShoot);

        //Debug.Log($"конец стрельбы {posShoot}");



        //Дипсик + 20% сам
        Vector2 origin = new Vector2()
        {
            x = transform.position.x,
            y = transform.position.y
        };

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 posShoot = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0));
        Vector2 direction = ((Vector2)posShoot - origin).normalized;

     
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
//Player                                  ? корневой объект игрока
//??? SpriteRenderer                      ? тело игрока
//??? Rigidbody2D
//??? Collider2D
//??? PlayerController (script)           ? движение
//?
//??? WeaponHolder                        ? пустой объект, «рука» (точка вращения оружия)
//    ?
//    ??? Weapon                          ? объект оружия (то, что вращается за курсором)
//        ??? SpriteRenderer              ? спрайт оружия (пистолет/автомат)
//        ??? WeaponAim (script)          ? поворот оружия за мышью
//        ??? WeaponStats (script)        ? урон, скорострельность, дальность
//        ??? WeaponSpread (script)       ? числа разброса, рост/спад
//        ??? Shooting (script)           ? рейкаст, линия, выстрел
//        ??? RegistClick (script)        ? обработка ввода
//        ?
//        ??? FirePoint                   ? пустой Transform, точка вылета (дуло)
//        ?   ??? MuzzleFlash             ? ParticleSystem, вспышка выстрела
//        ?   ??? SpreadCone              ? ВИЗУАЛЬНЫЙ КОНУС РАЗБРОСА
//        ?   ??? BulletSpawn (опц.)      ? пустой Transform, если пули — объекты
//        ?
//        ??? (опц.) Magazine             ? пустой объект для логики перезарядки