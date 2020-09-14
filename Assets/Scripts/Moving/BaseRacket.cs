using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRacket : MonoBehaviour, IMoving {

    protected readonly Vector3 _startPositionUp = Vector3.zero;
    protected readonly Vector3 _startPositionDown = Vector3.zero;
    protected float _borderX = 6f;

    public virtual void Activate() { }
    public virtual void ToInitialState() { }
    public virtual void Stop() { }

    private void Start() {
        _borderX = 5f * Screen.width / Screen.height - 1.2f;
    }
}
