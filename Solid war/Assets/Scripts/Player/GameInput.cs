using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerActionsInput _inputActions;
    public void Initialize()
    {
        Instance = this;
        _inputActions = new PlayerActionsInput();
        _inputActions.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 vector = _inputActions.Player.Move.ReadValue<Vector2>();
        return vector;
    }
}
