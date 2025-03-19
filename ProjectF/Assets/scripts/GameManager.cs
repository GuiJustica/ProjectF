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

    public static void collisionVerticallyLeftWall(){
        var player = GameObject.Find("Player");
        Vector3 newPosition = player.transform.position;
        newPosition.x = player.transform.position.x + 0.5f; // Ajusta o player para a posição da parede
        player.transform.position = newPosition;
    }

    public static void collisionHorizontallyLeftWall(){
        var player = GameObject.Find("Player");
        Vector3 newPosition = player.transform.position;
        newPosition.y = player.transform.position.y + 0.5f; // Ajusta a posição y do player
        player.transform.position = newPosition;
    }

    public static void collisionVerticallyRigthWall(){
        var player = GameObject.Find("Player");
        Vector3 newPosition = player.transform.position;
        newPosition.x = player.transform.position.x - 0.5f; // Ajusta a posição y do player
        player.transform.position = newPosition;
    }

    public static void collisionHorizontallyRigthWall(){
        var player = GameObject.Find("Player");
        Vector3 newPosition = player.transform.position;
        newPosition.y = player.transform.position.y - 0.5f; // Ajusta a posição y do player
        player.transform.position = newPosition;
    }

    void Update(){
        
    }
}
