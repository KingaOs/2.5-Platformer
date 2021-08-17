using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _button;
    [SerializeField]
    private int _requiredCoins = 8;

    private Elevator _elevator;
    private bool _elevatorCalled = false;


    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        
        if(_elevator == null)
        {
            Debug.LogError("The Elevator is null!!");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player_Draft>().coinCount() >= _requiredCoins)
            {
                if (_elevatorCalled == true)
                {
                    _button.material.color = Color.red;
                }
                else
                {
                    _button.material.color = Color.green;
                _elevatorCalled = true;
                }

                _elevator.CallElevator();
            }
        }
    }

}
