using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class BaseBall : MonoBehaviour, IMoving {

    protected const float _minSize = 0.28f;
    protected const float _maxSize = 0.42f;
    protected readonly Color[] _ballColors = new Color[] {
        Color.white,
        Color.cyan,
        Color.green,
        Color.yellow,
        Color.blue,
        Color.red
    };
    protected readonly Vector3 _startPosition = Vector3.zero;
    
    public void SetColor(int colorId) {
        if (colorId < 0 || colorId > _ballColors.Length) {
            return;
        }
        GetComponent<SpriteRenderer>().color = _ballColors[colorId];
    }

    public virtual void ToInitialState() {
        Stop();
        var size = Random.Range(_minSize, _maxSize);
        transform.localScale = new Vector3(size, size, 1f);
    }

    public virtual void Activate() { }
    public virtual void Stop() { }

}
