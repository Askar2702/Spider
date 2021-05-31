using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiderMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3[] _targets;
    private Animator _animator;
    private void Awake()
    {
        _animator =transform.GetChild(0).transform.GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(Move(_targets, _speed , true));
        _animator.SetBool("IsMoving", true);
    }
    
    public void SetTargets(Transform[]targets)
    {
        _targets = new Vector3[targets.Length];
        for(int i = 0; i < targets.Length; i++)
        {
            _targets[i] = targets[i].position;
        }
    }
    private IEnumerator Move(Vector3 [] path , float speed , bool infinty = false)
    {
        var index = 0;
        if (!infinty)
        {
            while (index!= path.Length - 1)
            {
                MovePlayer(path, speed, index);
                if (Vector3.Distance(transform.position , path[index]) < 1f)
                    index++;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            while (true)
            {
                MovePlayer(path, speed, index); 
                if (Vector3.Distance(transform.position, path[index]) < 1f)
                    index++;
                if (index == path.Length - 1)
                    index = 0;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    private void MovePlayer(Vector3[] path, float speed , int index)
    {
        transform.LookAt(path[index]);
        transform.position = Vector3.Lerp(transform.position, path[index], Time.deltaTime * speed);
    }
    
    

}
