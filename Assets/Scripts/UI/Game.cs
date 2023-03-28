using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class Game : MonoBehaviour
{
    //    [SerializeField] private Button _playButton;
    //    [SerializeField] private Button _settingsButton;
    //    [SerializeField] private Player _player;

    //    private CanvasGroup _gameOverGroup;

    //    private void OnEnable()
    //    {
    //        _playButton.onClick.AddListener(OnPlayButtonClick);
    //        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
    //    }

    //    private void OnDisable()
    //    {
    //        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    //        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
    //    }

    //    private void Start()
    //    {
    //        _gameOverGroup = GetComponent<CanvasGroup>();
    //        _gameOverGroup.alpha = 1;
    //        _playButton.interactable = true;
    //        _settingsButton.interactable = true;
    //        Time.timeScale = 0;
    //    }

    //    private void OnPlayButtonClick()
    //    {
    //        _gameOverGroup.alpha = 0;
    //        _playButton.interactable = false;
    //        _settingsButton.interactable = false;
    //        Time.timeScale = 1;
    //        SceneManager.LoadScene(1);
    //    }

    //    private void OnSettingsButtonClick()
    //    {

    //    }
}
