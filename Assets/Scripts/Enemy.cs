using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _maxSpeed;
    [SerializeField] float _mediumSpeed;
    [SerializeField] float _lowSpeed;

    float _maxDistance = 20f;
    float _mediumDistance = 13f;
    //float _lowDistance = 5f;
    float _delay = 1.5f;
    Transform _target;


    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (_target == null)
            Debug.LogError("The Player is NULL.");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Chasing());
    }

    private IEnumerator Chasing()
    {
        yield return new WaitForSeconds(_delay);

        var distance = Vector3.Distance(_target.position, transform.position);

        if (distance >= _maxDistance)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _maxSpeed * Time.deltaTime);

        if (distance < _maxDistance && distance >= _mediumDistance)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _mediumSpeed * Time.deltaTime);

        else
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _lowSpeed * Time.deltaTime);
    }
}