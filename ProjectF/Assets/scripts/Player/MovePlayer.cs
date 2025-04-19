using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayer : MonoBehaviour{
   public KeyCode rigthArrow = KeyCode.RightArrow;     
    public KeyCode leftArrow = KeyCode.LeftArrow;    
    public KeyCode upArrow = KeyCode.UpArrow;    
    public KeyCode downArrow = KeyCode.DownArrow;    
    public float speed = 40.0f;            
    private Rigidbody2D rb2d;               




    
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();     
       
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

            else if (scene.name == "Ginasio FEI"){
                GameManager.changeScene("GinasioDentro");
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

            else if (scene.name == "Ginasio FEI"){
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
        var vel = Vector2.zero;

        // Prioriza o movimento horizontal
        if (Input.GetKey(leftArrow)) {
            vel.x = -speed;
        }
        else if (Input.GetKey(rigthArrow)) {
            vel.x = speed;
        }
        else if (Input.GetKey(upArrow)) {
            vel.y = speed;
        }
        else if (Input.GetKey(downArrow)) {
            vel.y = -speed;
        }

        rb2d.velocity = vel;
    }
}
