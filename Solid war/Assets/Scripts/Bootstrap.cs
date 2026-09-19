using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] GameInput _gameInput;
    [SerializeField] Player _Player;
    //[SerializeField] MoveCameraToMouse _MoveCameraToMouse;
    [SerializeField] RegistClick _registClick;
    //[SerializeField] WeaponRotation weaponRotation;
    //[SerializeField] WeaponVisual weaponVisual;
    [SerializeField] Shooting _shooting;


    private void Awake()
    {
        _gameInput.Initialize();
        _Player.Initialize();
        _registClick.Initialize();
        _shooting.Initialize();
    }
}
