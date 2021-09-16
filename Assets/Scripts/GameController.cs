using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   public Text scoreText;
    public Text moneda1Text;
    public Text moneda2Text;
    public Text moneda3Text;
    
    
    private int _score = 0;
    private int _moneda1 = 0;
    private int _moneda2 = 0;
    private int _moneda3 = 0;
    

    private void Start()
    {
        scoreText.text = "Score: " + _score;
        moneda1Text.text = "Moneda 1: " + _moneda1;
        moneda2Text.text = "Moneda 2: " + _moneda2;
        moneda3Text.text = "Moneda 3: " + _moneda2;
    }


    public void PlusScore(int score)
    {
        _score += score;
        scoreText.text = "Score: " + _score;
    }

    public void PlusMoneda1(int moneda1)
    {
        _moneda1 += moneda1;
        moneda1Text.text = "Moneda 1: " + _moneda1;
    }


    public void PlusMoneda2(int moneda2)
    {
        _moneda2 += moneda2;
        moneda2Text.text = "Moneda 2: " + _moneda2;
    }


    public void PlusMoneda3(int moneda3)
    {
        _moneda3 += moneda3;
        moneda3Text.text = "Moneda 3: " + _moneda2;
    }


    
}