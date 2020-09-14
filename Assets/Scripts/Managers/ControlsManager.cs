using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour {

    public delegate void TouchHandler(int fingerId, Vector2 touchPosition);
    public event TouchHandler OnTouched;

    private Touch _activeTouch;
    private Vector2 _touchStartPosition;
    private Vector2 _touchPosition;
    private int _inputId = -1;
    private int _touchId = -1;
    private bool _isTouched = false;
    private Camera _cameraMain = null;
    private Camera _mainCamera {
        get {
            if (_cameraMain == null) {
                _cameraMain = Camera.main;
            }
            return _cameraMain;
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {
            _isTouched = true;
            _inputId++;
            _touchStartPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0)) {
            _isTouched = false;
        }
        if (Input.GetMouseButton(0)) {
            _touchPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        
#else
        if (_isTouched) {
            _isTouched = false;
            for (int i = 0; i < Input.touchCount; i++) {
                if (Input.GetTouch(i).fingerId == _touchId) {
                    _activeTouch = Input.GetTouch(i);
                    _isTouched = true;
                    break;
                }
            }
        } 
        if (!_isTouched) {
            if (Input.touchCount > 0) {
                _activeTouch = Input.GetTouch(0);
                _touchStartPosition = _mainCamera.ScreenToWorldPoint(_activeTouch.position);
                _touchId = _activeTouch.fingerId;
                _inputId++;
                _isTouched = true;
            }
        }
#endif
        if (_isTouched) {
#if !UNITY_EDITOR
            _touchPosition = _mainCamera.ScreenToWorldPoint(_activeTouch.position);
#endif
            OnTouched?.Invoke(_inputId, _touchPosition);
        }
    }
}
