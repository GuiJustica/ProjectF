using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour{
   public KeyCode rigthArrow = KeyCode.RightArrow;      // direita
    public KeyCode leftArrow = KeyCode.LeftArrow;    // esquerda
    public KeyCode upArrow = KeyCode.UpArrow;    // subir
    public KeyCode downArrow = KeyCode.DownArrow;    // descer
    public float speed = 40.0f;             // Define a velocidade 
    public float boundRigth = 5.65f;            // Define os limites na direita
    public float boundLeft = -6.081f;            // Define os limites na esquerda
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
       
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Colisão detectada com: " + collision.gameObject.name);
        
        if (collision.CompareTag("NextScene")){
            Debug.Log("Próxima cena!");
            GameManager.changeScene("Caminho_Capela_Ginasio FEI");
        }

        else if(collision.CompareTag("PreviousScene")){
            Debug.Log("Voltou para a cena anterior!");
            GameManager.changeScene("Entrada FEI");
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

//-2.95 -> x 
//40.92-> y