using System.Collections.Generic;
using UnityEngine;

// nuzhno buget potom menyat' polozhenie camerbl ot platformbl
public class CameraController : MonoBehaviour 
{
    [Header("Main")]
    private Camera _camera;

    [Header("PoseSwithcer")]
    [SerializeField] private Transform _cameraAnchor;
    [SerializeField] private List<Vector3> _cameraPoses = new List<Vector3>(); // in inspector
    [SerializeField] private Vector3 _cameraOffset = new Vector3(0, 10, 40);
    private int _currentPos = 0;

    [Header("Zoom")]
    [SerializeField] private Vector2 _currentZoom_YZ;
    [SerializeField] private float _scrollSpeed;

    private void SwitchCameraPos(int step)
    {
        _currentPos += step;
        if (_currentPos >= _cameraPoses.Count)
            _currentPos = 0;

        else if (_currentPos < 0)
            _currentPos = _cameraPoses.Count - 1;

        _cameraAnchor.LookAt(_cameraPoses[_currentPos]);
    }

    public void OnZoomInput(Vector2 input)
    {
        print(input);
        _currentZoom_YZ += new Vector2(-input.y, input.x) * _scrollSpeed;

        //if (_currentZoom_YZ.x >= _zoomLimitsMax_YZ.y)
        //    _currentZoom_YZ.x = _zoomLimitsMax_YZ.y;
        //else if (_currentZoom_YZ.x <= _cameraOffset.y)
        //    _currentZoom_YZ.x = _cameraOffset.y;

        //if (_currentZoom_YZ.y <= _zoomLimitsMax_YZ.z)
        //    _currentZoom_YZ.y = _zoomLimitsMax_YZ.z;
        //else if (_currentZoom_YZ.y >= _cameraOffset.z)
        //    _currentZoom_YZ.y = -_cameraOffset.z;
        print("ajkosndoajsiodjaposd");
        _camera.orthographicSize = _currentZoom_YZ.x;
    }

    private void Start()
    {
        _camera = Camera.main;

        _camera.orthographic = true;
        _camera.orthographicSize = 10f;

        _camera.transform.localEulerAngles = Vector3.zero;
        _camera.transform.position = _cameraOffset;
        _camera.transform.LookAt(_cameraAnchor);

        _camera.transform.parent = _cameraAnchor;

        SwitchCameraPos(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCameraPos(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCameraPos(-1);
        }

        _camera.orthographicSize = _currentZoom_YZ.x;
    }
}
