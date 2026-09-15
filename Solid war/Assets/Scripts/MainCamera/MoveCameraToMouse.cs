using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MoveCameraToMouse : MonoBehaviour
{
    [Header("По оси X")]
    [SerializeField] private float _edgeDistanceX = 300f;
    [SerializeField] private float _targetOffsetX = 3f;
    [SerializeField] private float _smoothSpeedX = 5f;

    [Header("По оси Y")]
    [SerializeField] private float _edgeDistanceY = 300f;
    [SerializeField] private float _targetOffsetY = 3f;
    [SerializeField] private float _smoothSpeedY = 5f;

    private CinemachinePositionComposer _cameraPos;

    private float _currentOffsetX = 0f;
    private float _currentOffsetY = 0f;
    private void Awake()
    {
        _cameraPos = GetComponent<CinemachinePositionComposer>();
    }
    private void Update()
    {       
        GetMouseToCameraMovement();
    }

    private void GetMouseToCameraMovement()
    {
        Vector2 mousePos = Mouse.current.position.value;
        var widthGame = Screen.width;
        var heightGame = Screen.height;

        float targetX;

        if (mousePos.x > widthGame - _edgeDistanceX)
        {
            targetX = _targetOffsetX;
        }
        else if(mousePos.x < _edgeDistanceX)
        {
            targetX = -_targetOffsetX;
        }
        else
        {
            targetX = 0f;
        }

        _currentOffsetX = Mathf.Lerp(_currentOffsetX, targetX, _smoothSpeedX * Time.deltaTime);

        float targetY;

        if (mousePos.y > heightGame - _edgeDistanceY)
        {
            targetY = _targetOffsetY;
        }
        else if (mousePos.y < _edgeDistanceY)
        {
            targetY = -_targetOffsetY;
        }
        else
        {
            targetY = 0;
        }

        _currentOffsetY = Mathf.Lerp(_currentOffsetY, targetY, _smoothSpeedY * Time.deltaTime);

        var offset = _cameraPos.TargetOffset;
        offset.x = _currentOffsetX;
        offset.y = _currentOffsetY;
        _cameraPos.TargetOffset = offset;

    }
    
}
