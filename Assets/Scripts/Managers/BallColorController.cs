using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallColorController : MonoBehaviour {

    [Inject] private SaveManager _saveManager;
    [Inject] private PhysicalBall _ball;

    private int _color = 0;

    public void SetColor(int newColor) {
        _color = newColor;
    }

    public void CloseWindow() {
        _saveManager.SaveColor(_color);
        _ball.SetColor(_color);
    }

    void Start() {
        _ball.SetColor(_saveManager.BallColorId);
    }
}
