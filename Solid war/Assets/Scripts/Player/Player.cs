using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 2f;
    private Rigidbody2D _rigidbody2D;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public Vector2 GetPositionPlayer()
    {
        return transform.position;
    }
    private void Move()
    {
        if (GameInput.Instance == null)
        {
            Debug.Log("GameInput Отсутствует");
            return;
        }

        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;

        _rigidbody2D.MovePosition(_rigidbody2D.position + inputVector * (_playerSpeed * Time.fixedDeltaTime));

    }
}
