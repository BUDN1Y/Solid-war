using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponRotation : MonoBehaviour
{
    private void Update()
    {
        RotationSprite();
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
}

