using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinDisplay;


    public void UpdateCoinDisplay(int coins)
    {
        _coinDisplay.text = "Coins: " + coins;
    }


}
