using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Transform _targetIcon;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private RectTransform[] _panelWin;
    [SerializeField] private TextMeshProUGUI _record;
    [SerializeField] private Ease _ease;
    public event Action finishing;
    private SpawnSpider _spawnSpider;
    private int _score;

    private void Awake()
    {
        _spawnSpider = FindObjectOfType<SpawnSpider>();
    }
    public void ScoreChange()
    {
        _score++;
        var score = 27 * _score;
        _scoreText.text = "Score :" + " " + score.ToString();
        
        if (_spawnSpider._spiders.Count<=1) FinishGame();
    }
    void Update()
    {
        _targetIcon.Rotate(0f, 0f, 1f);
    }
    public void FinishGame()
    {
        for (int i = 0; i < _panelWin.Length; i++)
        {
            _panelWin[i].DOAnchorPos(new Vector3(0f, 0f), 3f).SetEase(_ease);
        }
        finishing?.Invoke(); 
        var score = 27 * _score;
        _record.text = "Score" + "\n " + score.ToString();
    }
}
