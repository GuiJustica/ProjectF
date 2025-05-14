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

        if (scene.name == "GinasioFase" || scene.name == "CastelinhoFase" || scene.name == "FasePredioK" || scene.name == "TerracoFase" || scene.name == "Maua")
        {
            Debug.Log("Começa musica de fase");
            bossBackground.Play();

        }
    }
    

    void Update(){
        Scene scene = SceneManager.GetActiveScene();
        if (gameManager.PassouGinasio == true && scene.name == "GinasioFase"){
            bossBackground.Stop();
        }
        else if (gameManager.PassouPredioK == true && scene.name == "TerracoFase"){
            bossBackground.Stop();
        }
        else if (gameManager.PassouCastelinho == true && scene.name == "CastelinhoFase"){
            bossBackground.Stop();
        }
        else if (gameManager.PassouMaua == true && scene.name == "Maua"){
            bossBackground.Stop();
        }
    }
    
}
