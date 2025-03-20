using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayer : MonoBehaviour{
   public KeyCode rigthArrow = KeyCode.RightArrow;      // direita
    public KeyCode leftArrow = KeyCode.LeftArrow;    // esquerda
    public KeyCode upArrow = KeyCode.UpArrow;    // subir
    public KeyCode downArrow = KeyCode.DownArrow;    // descer
    public float speed = 40.0f;             // Define a velocidade 
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete

    
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
       
    }

    void OnTriggerEnter2D(Collider2D collision){
        Scene scene = SceneManager.GetActiveScene();
        if (collision.CompareTag("NextScene")){

            if(scene.name == "Subida FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Entrada FEI"){
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "Caminho_Capela_Ginasio FEI"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }
        }

        else if (collision.CompareTag("GinasioScene")){
            GameManager.changeScene("Ginasio FEI");
        }

        // else if (collision.CompareTag("CapelaScene")){
        //     GameManager.changeScene("Capela FEI");
        // }

        else if(collision.CompareTag("PreviousScene")){
            
            if(scene.name == "Subida FEI"){
                GameManager.changeScene("Entrada FEI");
            }

            else if(scene.name == "Caminho_Capela_Ginasio FEI"){
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }
        }

        else if (collision.CompareTag("LeftVerticallyWall")){
            GameManager.collisionVerticallyLeftWall();
        }

        else if (collision.CompareTag("LeftHorizontallyWall")){
            GameManager.collisionHorizontallyLeftWall();
        }

        else if (collision.CompareTag("RigthVerticallyWall")){
            GameManager.collisionVerticallyRigthWall();
        }

        else if (collision.CompareTag("RigthHorizontallyWall")){
            GameManager.collisionHorizontallyRigthWall();
        }
    }


    void Update(){
        var vel = rb2d.velocity;
        var pos = transform.position;
        
        //Deslocar objeto
        if (Input.GetKey(leftArrow)){
            vel.x = - speed;
        }
        else if (Input.GetKey(rigthArrow)){
            vel.x = speed;
        }
        else if (Input.GetKey(upArrow)){
            vel.y = speed;
        }
        else if (Input.GetKey(downArrow)){
            vel.y = -speed;
        }

        else {
            vel.x = 0;
            vel.y = 0;
        }
        rb2d.velocity = vel;

        transform.position = pos;
    }
}
