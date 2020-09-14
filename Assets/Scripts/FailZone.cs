using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FailZone : MonoBehaviour {

    [Inject] private TennisManager _tennisManager;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<BaseBall>() != null) {
            _tennisManager.StopGame();
        }
    }
}
