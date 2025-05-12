using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    void OnEnable() {
        Invoke("startGame", 45f);
    }

    void startGame(){
        GameManager.changeScene("Entrada FEI");
    }
}
