using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Score _score;

    private CanvasGroup _pauseGroup;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void Start()
    {
        _pauseGroup = GetComponent<CanvasGroup>();
        _pauseGroup.alpha = 0;
        _pauseGroup.blocksRaycasts = false;
        _playButton.interactable = false;
    }

    private void OnPauseButtonClick()
    {
        _score.ChangePlaying(false);
        _pauseGroup.alpha = 1;
        _pauseGroup.blocksRaycasts = true;
        _playButton.interactable = true;
        Time.timeScale = 0;
    }

    private void OnPlayButtonClick()
    {
        _pauseGroup.alpha = 0;
        Time.timeScale = 1;
        _pauseGroup.blocksRaycasts = false;
        _score.ChangePlaying(true);
    }
}
