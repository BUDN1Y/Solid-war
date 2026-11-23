using UnityEngine;
using UnityEngine.InputSystem;

public class VectorDirectionToMouse
{
    public float GetRotation(Vector3 startPosition)
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 0;

        var mouseWorldPoint = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 dir = ((Vector2)mouseWorldPoint - (Vector2)startPosition).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }

    public Vector2 GetVectorDirection(Vector3 startPosition)
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 0;

        mouseScreenPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 dir = ((Vector2)mouseScreenPos - (Vector2)startPosition).normalized;
      
        return dir;
    }
}
