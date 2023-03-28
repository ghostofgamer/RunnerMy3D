using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;
    [SerializeField] private Score _score;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _player.Died += OnDied;
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.blocksRaycasts = false;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        _restartButton.interactable = true;
        _exitButton.interactable = true;
        _gameOverGroup.blocksRaycasts = true;
        Time.timeScale = 0;
        _score.ChangePlaying(false);
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        _gameOverGroup.blocksRaycasts = false;
        SceneManager.LoadScene(1);
        _score.ChangePlaying(true);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
