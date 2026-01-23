using UnityEngine;

public class Initializer : MonoBehaviour
{
    private InputSystem_Actions _inputMap;

    [SerializeField] private CameraController _cameraController;

    private void InitCameraController()
    {
        _cameraController = GetComponent<CameraController>();

        _inputMap.Camera.Zoom.started += callback => _cameraController.OnZoomInput(callback.ReadValue<Vector2>());
        _inputMap.Camera.Zoom.performed += callback => _cameraController.OnZoomInput(callback.ReadValue<Vector2>());
        //_inputMap.Camera.Zoom.canceled += _ => _cameraController.OnZoomInput(Vector2.zero);
    }

    private void Awake()
    {
        _inputMap = new();

        InitCameraController();

        _inputMap.Enable();
    }
}
