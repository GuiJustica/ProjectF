using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selecao : MonoBehaviour{
    public void inicio (){
        SceneManager.LoadScene("CenaT");
    }
    public void reset(){
        SceneManager.LoadScene("Menu");
    }
    public void instr(){
        SceneManager.LoadScene("Instrucoes");
    }
    public void intro(){
        SceneManager.LoadScene("Introducao");
    }
    public void sair(){
        Debug.Log("Sair!");
        Application.Quit();
    }
}