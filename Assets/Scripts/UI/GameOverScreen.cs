using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreUI;
    [SerializeField] private TMP_Text _coinUI;

    private Player _player;
    private CanvasGroup _gameOverGroup;
    private int _scores;
    private int _coins;

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
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.blocksRaycasts = false;
        InteractableButton(false);
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        _gameOverGroup.blocksRaycasts = true;
        Time.timeScale = 0;
        InteractableButton(true);
        GetStatistics();
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

    private void GetStatistics()
    {
        _scores = PlayerPrefs.GetInt("score");
        _coins = PlayerPrefs.GetInt("coin");
        _scoreUI.text = _scores.ToString();
        _coinUI.text = _coins.ToString();
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
