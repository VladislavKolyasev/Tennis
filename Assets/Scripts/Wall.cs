using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    
    [SerializeField] private bool _isRight = true;
    private const float _offset = 0.51f;

    void Start() {
        var screenRatio = (float)Screen.width / Screen.height;
        var positionX = screenRatio * 5f + _offset;
        if (!_isRight) {
            positionX *= -1f;
        }
        transform.position = new Vector3(positionX, transform.position.y);
    }
}
