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

        if (scene.name == "GinasioFase")
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
