using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrMaua : MonoBehaviour{

    public GameObject iniciarDialogo;
    GameManager gameManager;
    void Start(){
        gameManager = GameManager.Instance;

        if(gameManager.PassouGinasio && gameManager.PassouPredioK && gameManager.PassouCastelinho){
            iniciarDialogo.SetActive(true);
        }
        else{
            iniciarDialogo.SetActive(false);
        }
    }
    
}
