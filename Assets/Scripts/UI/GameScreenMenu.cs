using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameScreenMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Player _player;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private Score _score;

    private CanvasGroup _gameMenuGroup;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
    }

    private void Start()
    {
        _gameMenuGroup = GetComponent<CanvasGroup>();
        _gameMenuGroup.alpha = 1;
        _playButton.interactable = true;
        _settingsButton.interactable = true;
        Time.timeScale = 0;
        _score.ChangePlaying(false);
    }

    private void OnPlayButtonClick()
    {
        _gameMenuGroup.alpha = 0;
        _playButton.interactable = false;
        _settingsButton.interactable = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        _score.ChangePlaying(true);
    }

    private void OnSettingsButtonClick()
    {
        _settingsScreen.OpenSettingsScreen();
        _gameMenuGroup.alpha = 0;
        _gameMenuGroup.blocksRaycasts = false;
        _playButton.interactable = false;
        _settingsButton.interactable = false;
    }

    public void OpenScreen()
    {
        _gameMenuGroup.alpha = 1;
        _playButton.interactable = true;
        _settingsButton.interactable = true;
        _gameMenuGroup.blocksRaycasts = true;
        //Time.timeScale = 0;
    }
}
