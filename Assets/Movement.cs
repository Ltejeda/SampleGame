using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Animator _animator;
    private float _speed = 0.01f;
    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", _speed);
        _animator.SetBool("Jumping", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            _animator.SetBool("Jumping", true);
            _speed = 0.01f;
            _animator.SetFloat("Speed", _speed);
        }
        else if (Input.GetKey("2"))
        {
            _animator.SetBool("Jumping", false);
            _speed = 0.5f;
            _animator.SetFloat("Speed", _speed);
        }
        else if (Input.GetKey("3"))
        {
            _animator.SetBool("Jumping", false);
            _speed = 0.01f;
            _animator.SetFloat("Speed", _speed);
        }
    }
}
