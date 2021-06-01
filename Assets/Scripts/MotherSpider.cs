using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MotherSpider : MonoBehaviour, ISpider
{
    private int _health = 100;
    private UiManager _uiManager;
    [SerializeField] private Transform _bone;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _uiManager = FindObjectOfType<UiManager>();
    }
    public void TakeDamage()
    {
        if (_health <= 0) return;
        _health-=5;
        _uiManager.ScoreChange();
        _bone.DOPunchScale(new Vector3(0.03f, 0.03f, 0.03f), 0.2f, 1, 0.02f);
     
        if (_health <= 0)
        {
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().mass = 50; 
            _animator.SetBool("IsDead", true);
            _bone.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
