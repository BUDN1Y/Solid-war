using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class VectorToLineMouse
{
    public float GetRotationToLineMouse(Vector3 startPosition)
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 0;

        mouseScreenPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 dir = (Vector2)mouseScreenPos - (Vector2)startPosition;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }

    public Vector2 GetVectorToLineMouse(Vector3 startPosition)
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 0;

        mouseScreenPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 dir = (Vector2)mouseScreenPos - (Vector2)startPosition;
      
        return dir;
    }
}
