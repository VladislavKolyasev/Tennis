using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TennisManager : MonoBehaviour {

    public delegate void GameStateHandler();
    public event GameStateHandler OnGameStarted = null;
    public event GameStateHandler OnGameStopped = null;
    private List<IMoving> _movingObjects = new List<IMoving>();

    public void StartGame() {
        foreach (var moving in _movingObjects) {
            moving.ToInitialState();
            moving.Activate();
        }
        OnGameStarted?.Invoke();
    }

    public void StopGame() {
        foreach(var moving in _movingObjects) {
            moving.Stop();
        }
        OnGameStopped?.Invoke();
    }

    void Start() {
        _movingObjects.AddRange(FindObjectsOfType<BaseBall>());
        _movingObjects.AddRange(FindObjectsOfType<BaseRacket>());
    }
}
