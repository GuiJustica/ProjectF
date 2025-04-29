using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayerFases : MonoBehaviour{
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

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilPrefab , firePoint.position , firePoint.rotation);
            Debug.Log("Projetil criado em: " + firePoint.position);

        }

    }

    void FixedUpdate(){
        // Aplicando a movimenta��o no Rigidbody2D
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision){
        Scene scene = SceneManager.GetActiveScene();

        if (collision.CompareTag("GinasioScene")){
            GameManager.changeScene("Ginasio FEI");
        }

        // else if (collision.CompareTag("CapelaScene")){
        //     GameManager.changeScene("Capela FEI");
        // }

        else if(collision.CompareTag("PreviousScene")){
            
            if (scene.name == "GinasioDentro"){
                GameManager.changeScene("Ginasio FEI");
            }
        }

        else if (collision.CompareTag("Refeitorio FEI")){
            GameManager.changeScene("RefeitorioDentro");
        }

    }
}