using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayer : MonoBehaviour{
    public float moveSpeed = 10f; // Velocidade de movimenta��o
    private Vector2 moveDirection; // Dire��o do movimento

    private Rigidbody2D rb2d;
    private Animator animator;


    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        // Obtendo a entrada do usu�rio para movimenta��o
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)
        // Calculando a dire��o do movimento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal

        animator.SetBool("MovDir",moveX > 0);
        animator.SetBool("MovEsq", moveX < 0);
        animator.SetBool("MovFrente",moveY < 0);
        animator.SetBool("MovTras", moveY > 0);

        //rb2d.velocity = vel;
    }

    void FixedUpdate(){
        // Aplicando a movimenta��o no Rigidbody2D
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
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
                GameManager.changeScene("Capela");
            }

            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("RefeitorioDentro");
            }

            else if (scene.name == "RefeitorioDentro"){
                GameManager.changeScene("RefeitorioDentro");
            }

            else if (scene.name == "Estacionamento FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Ginasio FEI"){
                GameManager.changeScene("GinasioDentro");
            }

            else if (scene.name == "GinasioDentro"){
                GameManager.changeScene("Ginasio FEI");
            }

            else if (scene.name == "Capela"){

                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Elevador")
            {
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "PredioK")
            {
                GameManager.changeScene("Elevador");
            }


            else if (scene.name == "Caminho_Capela_Ginasio FEI"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "Ginasio FEI"){
                GameManager.changeScene("GinasioDentro");
            }

            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("Estacionamento FEI");
            }
        }

        else if (collision.CompareTag("PredioK")){
            GameManager.changeScene("PredioK");
        }

        else if (collision.CompareTag("GinasioScene")){
            GameManager.changeScene("Ginasio FEI");
        }

        else if(collision.CompareTag("PreviousScene")){

            if(scene.name == "Subida FEI"){
                GameManager.changeScene("Entrada FEI");
            }

            else if(scene.name == "Caminho_Capela_Ginasio FEI"){
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "Caminho_Capela_Ginasio FEI")
            {
                GameManager.changeScene("Subida FEI");
            }
            else if (scene.name == "PredioK")
            {
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "Elevador")
            {
                GameManager.changeScene("PredioK");
            }

            else if (scene.name == "Caminho_Capela_Ginasio FEI"){
                GameManager.changeScene("Subida FEI");
            }
            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Ginasio FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Estacionamento FEI"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "RefeitorioDentro"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "GinasioDentro"){
                GameManager.changeScene("Ginasio FEI");
            }

            else if (scene.name == "Capela"){
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

        else if (collision.CompareTag("Refeitorio FEI")){
            GameManager.changeScene("RefeitorioDentro");
        }

    }
}
