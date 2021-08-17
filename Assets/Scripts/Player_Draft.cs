using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Draft : MonoBehaviour
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
    private Vector3 _dir, _velocity;

    private bool _canWallJump;
    private Vector3 _wallSurfaceNormal;

    private float _pushPower = 2f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        uIManager.UpdateLivesDisplay(_lives);

    }


    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");


        if (_controller.isGrounded)
        {
            _canWallJump = false;
            _dir = new Vector3(horizontal, 0, 0);
            _velocity = _dir * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _doubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _doubleJump == true && _canWallJump == false)
            {        
                    _yVelocity += _jumpHeight ;
                    _doubleJump = false;   
            }
            if (Input.GetKeyDown(KeyCode.Space) &&  _canWallJump == true)
            {
                _yVelocity = _jumpHeight;
                _velocity = _wallSurfaceNormal * _speed;
            }


                _yVelocity -= _gravity;

        }

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Moving Box")
        {
            Rigidbody body = hit.collider.GetComponent<Rigidbody>();

            if (body != null)
            {
                Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0);

                body.velocity = pushDir * _pushPower;
            }

        }


        if(_controller.isGrounded == false && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallSurfaceNormal = hit.normal;
            _canWallJump = true;
        }
    }


}
