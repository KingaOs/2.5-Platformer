using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _dir;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpHeight = 10.0f;
    [SerializeField]
    private float _gravity = 1.0f;

    Animator _anim;

    private bool _jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller.isGrounded)
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            _anim.SetFloat("Speed", Mathf.Abs(horizontal));
            _dir = new Vector3(horizontal, 0, 0) * _speed;

            if(_jumping == true)
            {
                _jumping = false;
                _anim.SetBool("Jumping", _jumping);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _dir.y += _jumpHeight;
                _jumping = true;
                _anim.SetBool("Jumping",_jumping);
            }
        }

        _dir.y -= _gravity * Time.deltaTime;

        _controller.Move(_dir * Time.deltaTime);


    }
}

