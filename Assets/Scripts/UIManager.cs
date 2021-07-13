using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinDisplay;    
    [SerializeField]
    private Text _livesDisplay;


    public void UpdateCoinDisplay(int coins)
    {
        _coinDisplay.text = "Coins: " + coins.ToString();
    }
        
    public void UpdateLivesDisplay(int lives)
    {
        _livesDisplay.text = "Lives: " + lives.ToString();
    }


}
