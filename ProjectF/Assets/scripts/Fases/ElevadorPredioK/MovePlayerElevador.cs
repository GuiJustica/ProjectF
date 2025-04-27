using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayerElevador : MonoBehaviour{
    public float moveSpeed = 10f; // Velocidade de movimenta��o
    private Rigidbody2D rb; // Refer�ncia para o Rigidbody2D
    private Vector2 moveDirection; // Dire��o do movimento
    private Rigidbody2D rb2d;



    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update(){
        // Obtendo a entrada do usu�rio para movimenta��o
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)
        // Calculando a dire��o do movimento

        //rb2d.velocity = vel;

        if(moveY > 0 ) { //Bloqueia a movimentação para cima do personagem
            moveY = 0;
        }
        

        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal

    }

    void FixedUpdate(){
        // Aplicando a movimenta��o no Rigidbody2D
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision){
        Scene scene = SceneManager.GetActiveScene();
        if (collision.CompareTag("NextScene")){

            if(scene.name == "Elevador"){
                GameManager.changeScene("FasePredioK");
            }
        }

        else if(collision.CompareTag("PreviousScene")){

            if(scene.name == "Elevador"){
                GameManager.changeScene("PredioK");
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

        else if (collision.CompareTag("Refeitorio FEI")){
            GameManager.changeScene("RefeitorioDentro");
        }

    }
}
