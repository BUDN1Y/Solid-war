using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void Update()
    {
        RotationSprite();
        FlipWeapon();
    }

    private void RotationSprite()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 0;

        mouseScreenPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 dir = (Vector2)mouseScreenPos - (Vector2)transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
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

