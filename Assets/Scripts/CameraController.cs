using System.Collections.Generic;
using UnityEngine;

// nuzhno buget potom menyat' polozhenie camerbl ot platformbl
public class CameraController : MonoBehaviour 
{
    private Camera _camera;
    [SerializeField] private Transform _cameraAnchor;
    [SerializeField] private List<Vector3> _cameraPoses = new List<Vector3>(); // in inspector
    [SerializeField] private Vector3 _cameraOffset = new Vector3(0, 10, 40);

    private int _currentPos = 0;

    private void SwitchCameraPos(int step)
    {
        _currentPos += step;
        if (_currentPos >= _cameraPoses.Count)
            _currentPos = 0;

        else if (_currentPos < 0)
            _currentPos = _cameraPoses.Count - 1;

        _cameraAnchor.LookAt(_cameraPoses[_currentPos]);
    }

    private void Start()
    {
        _camera = Camera.main;

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
    }
}
