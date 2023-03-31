using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{

    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;
    [SerializeField] private Player _player;
    [SerializeField] private Score _score;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;

        _level1Button.onClick.AddListener(OnRestartLevelBeach);
        _level2Button.onClick.AddListener(OnRestartLevelDesert);
        _level3Button.onClick.AddListener(OnRestartLevelWinter);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Died += OnDied;
        _level1Button.onClick.RemoveListener(OnRestartLevelBeach);
        _level2Button.onClick.RemoveListener(OnRestartLevelDesert);
        _level3Button.onClick.RemoveListener(OnRestartLevelWinter);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.blocksRaycasts = false;
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        _gameOverGroup.blocksRaycasts = true;
        Time.timeScale = 0;
        _score.ChangePlaying(false);
    }

    private void OnRestartLevelBeach()
    {
        InteractableButton(false);
        ChangeLevel(1);
    }

    private void OnRestartLevelDesert()
    {
        InteractableButton(false);
        ChangeLevel(2);
    }

    private void OnRestartLevelWinter()
    {
        InteractableButton(false);
        ChangeLevel(3);
    }

    private void InteractableButton(bool flag)
    {
        _menuButton.interactable = flag;
        _level1Button.interactable= flag;
        _level2Button.interactable= flag;
        _level3Button.interactable= flag;
    }

    private void ChangeLevel(int number)
    {
        InteractableButton(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(number);
        _score.ChangePlaying(true);
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
