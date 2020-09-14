using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicalBall : BaseBall, IMoving {

    [SerializeField] private float _baseSpeed = 10f;

    [Inject] private ScoresController _scoresController;
    private Rigidbody2D _attachedRigidbody = null;
    private float _actualSpeed = 0f;
    private float _timeOfLastPoint = 0f;
    private Rigidbody2D _rigidbody {
        get {
            if (_attachedRigidbody == null) {
                _attachedRigidbody = GetComponent<Rigidbody2D>();
            }
            return _attachedRigidbody;
        }
    }

    public override void ToInitialState() {
        base.ToInitialState();
        transform.position = _startPosition;
    }

    public override void Activate() {
        base.Activate();
        StartCoroutine(WaitForActivate());

        IEnumerator WaitForActivate() {
            yield return new WaitForSeconds(0.2f);
            _rigidbody.velocity = Random.insideUnitCircle.normalized * GetRandomSpeed();
        }
    }

    public override void Stop() {
        base.Stop();
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0f;
    }

    float GetRandomSpeed() {
        _actualSpeed = Random.Range(_baseSpeed * 0.5f, _baseSpeed * 1.5f);
        return _actualSpeed;
    }

    void OnCollisionExit2D(Collision2D collision) {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _actualSpeed;
        if (collision.gameObject.tag == "Racket" && Time.time > _timeOfLastPoint + 0.5f) {
            _scoresController.AddPoint();
            _timeOfLastPoint = Time.time;
        }
    }
}
