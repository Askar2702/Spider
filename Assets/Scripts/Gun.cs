using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _pointFire;
    [SerializeField] private float _forse;
    private float fireTimer;
    private UiManager _uiManager;
    [SerializeField] private float refireRate = 0.5f;
    private bool isFire = true;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UiManager>();
        _uiManager.finishing += StopFire;
    }
    void Start()
    {
        StartCoroutine(TransformChange());
    }

    
    IEnumerator TransformChange()
    {
        while (true)
        {
            ShootRate();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void ShootRate()
    {
        if (!isFire) return;
        fireTimer += Time.deltaTime;
        if (fireTimer >= refireRate)
        {
            fireTimer = 0;
            Fire();
        }
    } 
    private void Fire()
    {
        var bullet = Instantiate(_bullet, _pointFire.position, Quaternion.Euler(90f -12f, 0f, 0f));
        bullet.GetComponent<Rigidbody>().velocity = _pointFire.forward * _forse;
    }
    private void StopFire()
    {
        isFire = false;
    }
}
