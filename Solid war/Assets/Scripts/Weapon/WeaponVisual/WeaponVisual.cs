using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] private Player _player;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        FlipWeapon();
    }

    private void FlipWeapon()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 playerPos = _player.GetPositionPlayer();

        if (playerPos.x < mousePos.x)
        {
            _spriteRenderer.flipY = false;
        }
        else
        {
            _spriteRenderer.flipY = true;
        }


    }
}
