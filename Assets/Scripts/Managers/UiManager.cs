using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiManager : MonoBehaviour {

    [Inject(Id = "StartButton")]
    private Button _startButton;
    [Inject(Id = "ColorsButton")]
    private Button _colorsButton;
    [Inject(Id = "ScoreText")]
    private Text _scoreText;
    [Inject(Id = "HighscoreText")]
    private Text _highscoreText;
    [Inject(Id = "ColorsWindow")]
    private RectTransform _colorsWindow;
    [Inject] private TennisManager _tennisManager;

    public void SetScore(int score) {
        _scoreText.text = score.ToString();
    }

    public void SetHighScore(int highscore) {
        _highscoreText.text = "Highscore: " + highscore;
    }

    void Awake() {
        _tennisManager.OnGameStarted += OnGameStarted;
        _tennisManager.OnGameStopped += OnGameFinished;
        _startButton.onClick.AddListener(_tennisManager.StartGame);
        _colorsButton.onClick.AddListener(() => _colorsWindow.gameObject.SetActive(true));
    }

    void OnGameStarted() {
        SetObjectsActive(false);
    }

    void OnGameFinished() {
        SetObjectsActive(true);
    }

    void SetObjectsActive(bool isActive) {
        _startButton.gameObject.SetActive(isActive);
        _colorsButton.gameObject.SetActive(isActive);
    }
}
