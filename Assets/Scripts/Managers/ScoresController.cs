using UnityEngine;
using Zenject;

public class ScoresController : MonoBehaviour {

    [Inject] private TennisManager _tennisManager;
    [Inject] private SaveManager _saveManager;
    [Inject] private UiManager _uiManager;

    private int _activeScore = 0;
    private int _highscore = 0;

    public void AddPoint() {
        _activeScore++;
        _uiManager.SetScore(_activeScore);
    }

    void Start() {
        _uiManager.SetScore(0);
        _highscore = _saveManager.Highscore;
        _uiManager.SetHighScore(_highscore);
        _tennisManager.OnGameStopped += OnGameStopped;
        _tennisManager.OnGameStarted += OnGameStarted;
    }

    void OnGameStarted() {
        _activeScore = 0;
        _uiManager.SetScore(_activeScore);
    }

    void OnGameStopped() {
        if (_activeScore > _highscore) {
            _highscore = _activeScore;
            _uiManager.SetHighScore(_highscore);
            _saveManager.SaveHighscore(_highscore);
        }
    }
}
