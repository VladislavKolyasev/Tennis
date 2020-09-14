using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicalRacket : BaseRacket {

    [Inject] private ControlsManager _controlsManager;
    private Vector2 _startRacketPosition;
    private Vector2 _startInputPosition;
    private int _fingerId = -2; 
    private Rigidbody2D _attachedRigidbody = null;
    private Rigidbody2D _rigidbody {
        get {
            if (_attachedRigidbody == null) {
                _attachedRigidbody = GetComponent<Rigidbody2D>();
            }
            return _attachedRigidbody;
        }
    }

    public override void Activate() {
        _controlsManager.OnTouched += OnInput;
    }

    public override void ToInitialState() {
        Stop();
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    }

    public override void Stop() {
        _controlsManager.OnTouched -= OnInput;
    }

    protected virtual void OnInput(int fingerId, Vector2 inputPosition) {
        if(_fingerId == fingerId) {
            var newPosition = new Vector2(_startRacketPosition.x + (inputPosition.x - _startInputPosition.x), transform.position.y);
            newPosition.x = Mathf.Clamp(newPosition.x, -_borderX, _borderX);
            _rigidbody.MovePosition(newPosition);
        }
        else {
            _startRacketPosition = transform.position;
            _startInputPosition = inputPosition;
            _fingerId = fingerId;
        }
    }
    void OnCollisionExit2D(Collision2D collision) {
        _rigidbody.velocity = Vector2.zero;
    }
}
