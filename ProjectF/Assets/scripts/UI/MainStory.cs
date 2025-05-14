using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainStory : MonoBehaviour
{

    void OnEnable(){

        SceneManager.LoadScene("Entrada FEI", LoadScene.Single);
        Invoke("Tempo",44f);
    }

    void Tempo(){
         GameManager.changeScene("Entrada FEI");


    }
}


