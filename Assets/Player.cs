using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5;
    [SerializeField]
    private float _gravity = 1;
    [SerializeField]
    private float _jumpHeight;
    private float _yVelocity;
    private bool _doubleJump;

    private int _coins;
    [SerializeField]
    private UIManager uIManager;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var dir = new Vector3(horizontal, 0, 0);
        var velocity = dir * _speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _doubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _doubleJump == true)
            {        
                    _yVelocity += _jumpHeight ;
                    _doubleJump = false;   
            }
            _yVelocity -= _gravity;

        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        _coins++;
        uIManager.UpdateCoinDisplay(_coins);
    }

}