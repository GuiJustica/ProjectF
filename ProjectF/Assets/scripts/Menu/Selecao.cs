using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour{
    public void inicio (){
        SceneManager.LoadScene("CenaT");
    }
    public void reset(){
        SceneManager.LoadScene("Menu");
    }
    public void instr(){
        SceneManager.LoadScene("Instrucoes");
    }
    public void sair(){
        Debug.Log("Sair!");
        Application.Quit();
    }
}
