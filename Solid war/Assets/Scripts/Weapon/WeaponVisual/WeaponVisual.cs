using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] private Player _player;

    public float GetAimPosition()
    {
        return _player.transform.position.x + transform.position.x;
    }
}
