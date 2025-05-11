using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerFases : MonoBehaviour
{
    public AudioSource bossBackground;
    GameManager gameManager;


    void Start(){
        Scene scene = SceneManager.GetActiveScene();
        gameManager = GameManager.Instance;

        if (scene.name == "GinasioFase" || scene.name == "CastelinhoFase" || scene.name == "FasePredioK" || scene.name == "TerracoFase")
        {
            if (!gameManager.PassouGinasio){
                bossBackground.Play();
            }

        }
    }      

    void Update(){
        if (gameManager.PassouGinasio == true){
            bossBackground.Stop();
        }
    }
    
}
