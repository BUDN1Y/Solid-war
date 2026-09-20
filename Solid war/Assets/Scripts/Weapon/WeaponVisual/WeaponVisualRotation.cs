using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private Player _player;

    private VectorToLineMouse _vectorToLineMouse;

    private void Awake()
    {
        _vectorToLineMouse = new VectorToLineMouse();
    }
    private void Update()
    {
        RotationSprite();
        FlipWeapon();
    }

    private void RotationSprite()
    {       
        transform.rotation = Quaternion.Euler(0, 0, _vectorToLineMouse.GetRotationToLineMouse(transform.position));
    }

    private void FlipWeapon()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 playerPos = _player.GetPositionPlayer();

        Vector3 scale = transform.localScale;
        scale.y = (mousePos.x < transform.position.x)
            ? -Mathf.Abs(scale.y)
            : Mathf.Abs(scale.y);
        transform.localScale = scale;


    }
}

