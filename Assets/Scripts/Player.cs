using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private int _lives = 3;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        uIManager.UpdateLivesDisplay(_lives);
      
    }


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

    public void Damage()
    {
        _lives--;
        uIManager.UpdateLivesDisplay(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public int coinCount()
    {
        return _coins;

    }

}
