using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Score _score;

    private Player _player;
    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Died += OnDied;
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
        Debug.Log("פûגפûגפû");
        _gameOverGroup.alpha = 1;
        _gameOverGroup.blocksRaycasts = true;
        Time.timeScale = 0;
        InteractableButton(true);
        _score.ChangePlaying(false);
    }

    private void InteractableButton(bool flag)
    {
        _menuButton.interactable = flag;
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
