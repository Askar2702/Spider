using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hit;
    
    void Start()
    {
        Destroy(gameObject,2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var spider = collision.gameObject.GetComponent<ISpider>();
        if (spider is ISpider)
        {
            _hit.Play();
            spider.TakeDamage();
            Destroy(gameObject,1f);
        }
    }
}
