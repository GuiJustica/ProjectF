using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selecao : MonoBehaviour{

    GameManager gameManager;
    void Start(){
        gameManager = GameManager.Instance;

        gameManager.BuyFeathers = false;
        gameManager.PassouGinasio = false;
        gameManager.PassouPredioK = false;
        gameManager.PassouCastelinho = false;
        gameManager.Lifes = 10;
        gameManager.Money = 0;
        
    }
    public void Reiniciar(){
        Debug.Log("Botão clicado");
        Debug.Log("Passou Ginasio" + gameManager.PassouGinasio);
        Debug.Log("Passou Predio K" + gameManager.PassouPredioK);
        Debug.Log("Passou Castelinho" + gameManager.PassouCastelinho);
        Debug.Log("Lifes" + gameManager.Lifes);
        Debug.Log("Money" + gameManager.Money);

        SceneManager.LoadScene("MainMenu");

    }
}