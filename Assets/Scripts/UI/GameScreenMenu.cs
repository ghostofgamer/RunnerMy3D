using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameScreenMenu : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;
    [SerializeField] private Player _player;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private Score _score;

    private CanvasGroup _gameMenuGroup;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _level1Button.onClick.AddListener(OnBeachLevelButtonClick);
        _level2Button.onClick.AddListener(OnDesertLevelButtonClick);
        _level3Button.onClick.AddListener(OnWinterButtonClick);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _level1Button.onClick.RemoveListener(OnBeachLevelButtonClick);
        _level2Button.onClick.RemoveListener(OnDesertLevelButtonClick);
        _level3Button.onClick.RemoveListener(OnWinterButtonClick);
    }

    private void Start()
    {
        _gameMenuGroup = GetComponent<CanvasGroup>();
        _gameMenuGroup.alpha = 1;
        InteractableButton(true);
        Time.timeScale = 0;
        _score.ChangePlaying(false);
    }

    private void OnPlayButtonClick()
    {
        InteractableButton(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        _score.ChangePlaying(true);
    }

    private void OnSettingsButtonClick()
    {
        _settingsScreen.OpenSettingsScreen();
        _gameMenuGroup.alpha = 0;
        _gameMenuGroup.blocksRaycasts = false;
        InteractableButton(false);
    }

    public void OpenScreen()
    {
        _gameMenuGroup.alpha = 1;
        InteractableButton(true);
        _gameMenuGroup.blocksRaycasts = true;
    }

    private void OnBeachLevelButtonClick()
    {
        InteractableButton(false);
        ChangeLevel(1);
    }

    private void OnDesertLevelButtonClick()
    {
        InteractableButton(false);
        ChangeLevel(2);
    }

    private void OnWinterButtonClick()
    {
        InteractableButton(false);
        ChangeLevel(3);
    }

    private void InteractableButton(bool flag)
    {
        _settingsButton.interactable = flag;
        _level1Button.interactable = flag;
        _level2Button.interactable = flag;
        _level3Button.interactable = flag;
    }

    private void ChangeLevel(int number)
    {
        InteractableButton(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(number);
        _score.ChangePlaying(true);
    }
}
