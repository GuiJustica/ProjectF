using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayerElevador : MonoBehaviour{
    public float moveSpeed = 10f; // Velocidade de movimenta��o
    private Rigidbody2D rb; // Refer�ncia para o Rigidbody2D
    private Vector2 moveDirection; // Dire��o do movimento
    private Rigidbody2D rb2d;

    public GameObject projectilPrefab;

    public Transform firePoint;


    void Start(){
        rb2d = GetComponent<Rigidbody2D>();

        firePoint.parent = transform;

    }

    void Update(){
        // Obtendo a entrada do usu�rio para movimenta��o
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)
        // Calculando a dire��o do movimento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal

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
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "Ginasio FEI"){
                GameManager.changeScene("GinasioDentro");
            }

            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("Estacionamento FEI");
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

            else if (scene.name == "Estacionamento FEI"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "RefeitorioDentro"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "GinasioDentro"){
                GameManager.changeScene("Ginasio FEI");
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
