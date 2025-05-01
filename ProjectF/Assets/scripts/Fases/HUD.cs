using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI qtdMoney;

    public TextMeshProUGUI qtdlife;

    private GameManager gameManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        qtdlife.text = "X " + gameManager.Lifes;
        qtdMoney.text = "X " + gameManager.Money;
        
    }
}
