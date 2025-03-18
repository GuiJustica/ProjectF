using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
   
    
    void Start(){
        
       
    }

    public static void changeScene(string nameScene){
        SceneManager.LoadScene(nameScene);
    }

    void Update(){
        
    }
}
