using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour
{
    [SerializeField] private GameObject _spider;
    [SerializeField] private Transform[] _targets;
    [SerializeField] private int _countSpider;
    public int CountSpider => _countSpider;

    public List<GameObject> _spiders { get; private set; }

    void Start()
    {
        _spiders = new List<GameObject>();
        StartCoroutine(DelaySpawn());
    }

    private void Spawn()
    {
        var spider = Instantiate(_spider, _targets[0].position, Quaternion.identity);
        spider.GetComponent<SpiderMove>().SetTargets(_targets);
        spider.transform.parent = transform;
        _countSpider--;
        _spiders.Add(spider);
    }
    public void RemoveSpider(GameObject spider)
    {
        _spiders.Remove(spider);
    }
    IEnumerator DelaySpawn()
    {
        while (_countSpider != 0)
        {
            Spawn();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
