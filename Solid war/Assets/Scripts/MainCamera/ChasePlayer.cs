using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _smoothTime = 0.1f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        ChasingPlayer();
    }

    private void ChasingPlayer()
    {
        Vector2 targetPos = _player.GetPositionPlayer();
        Vector2 newPos = Vector2.SmoothDamp(
            _rigidbody2D.position,
            targetPos,
            ref _velocity,
            _smoothTime
        );
        _rigidbody2D.MovePosition(newPos);
    }
}
