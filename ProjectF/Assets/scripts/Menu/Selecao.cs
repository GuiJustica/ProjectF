using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selecao : MonoBehaviour{
    public void Reiniciar(){
        Debug.Log("Botão clicado");
        SceneManager.LoadScene("MainMenu");
    }
}