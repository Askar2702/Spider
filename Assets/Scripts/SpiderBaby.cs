using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBaby : MonoBehaviour, ISpider
{
    [SerializeField] private GameObject _deadBody;
    private UiManager _uiManager;
    private bool isDead = false;
    private SpawnSpider _spawnSpider;
    private void Awake()
    {
        _spawnSpider = FindObjectOfType<SpawnSpider>();
        _uiManager = FindObjectOfType<UiManager>();
    }
    public void TakeDamage()
    {
        if (isDead) return;
        _uiManager.ScoreChange();
        _spawnSpider.RemoveSpider(gameObject);
        Instantiate(_deadBody, transform.position, Quaternion.identity);
        Destroy(gameObject);
        isDead = true;
    }
}
