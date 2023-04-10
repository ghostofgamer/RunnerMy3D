using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _menuButton;
    //[SerializeField] private Button _returnMenuButton;
    [SerializeField] private Score _score;
    //[SerializeField] private GameScreenMenu _gameScreenMenu;

    private CanvasGroup _pauseGroup;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        //_returnMenuButton.onClick.AddListener(OnReturnMenuButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        //_returnMenuButton.onClick.RemoveListener(OnReturnMenuButtonClick);
    }

    private void Start()
    {
        _pauseGroup = GetComponent<CanvasGroup>();
        _pauseGroup.alpha = 0;
        _pauseGroup.blocksRaycasts = false;
        InteractableButton(false);
    }

    private void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        _score.ChangePlaying(false);
        _pauseGroup.alpha = 1;
        _pauseGroup.blocksRaycasts = true;
        InteractableButton(true);
    }

    private void OnPlayButtonClick()
    {
        _pauseGroup.alpha = 0;
        Time.timeScale = 1;
        _pauseGroup.blocksRaycasts = false;
        _score.ChangePlaying(true);
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void InteractableButton(bool flag)
    {
        _playButton.interactable = flag;
        _menuButton.interactable = flag;
    }
    //private void OnReturnMenuButtonClick()
    //{
    //    _pauseGroup.alpha = 0;
    //    _pauseGroup.blocksRaycasts = false;
    //    _gameScreenMenu.OpenScreen();
    //}
}
