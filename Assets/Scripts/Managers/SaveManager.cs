using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SaveManager : MonoBehaviour
{
    [Inject] private TennisManager _tennisManager;

    public int Highscore {
        get {
            if(!_isLoaded) {
                Load();
            }
            return _highscore;
        }
    }
    public int BallColorId {
        get {
            if(!_isLoaded) {
                Load();
            }
            return _ballColorId;
        }
    }

    private int _highscore = 0;
    private int _ballColorId = 0;
    private bool _isLoaded = false;

    public void SaveHighscore(int highscore) {
        PlayerPrefs.SetInt("Highscore", highscore);
        PlayerPrefs.Save();
        _highscore = highscore;
    }

    public void SaveColor(int colorId) {
        PlayerPrefs.SetInt("BallColorId", colorId);
        PlayerPrefs.Save();
        _ballColorId = colorId;
    }

    void Load() {
        if (PlayerPrefs.HasKey("Highscore")) {
            _highscore = PlayerPrefs.GetInt("Highscore");
        }
        if (PlayerPrefs.HasKey("BallColorId")) {
            _ballColorId = PlayerPrefs.GetInt("BallColorId");
        }
        _isLoaded = true;
    }
}
