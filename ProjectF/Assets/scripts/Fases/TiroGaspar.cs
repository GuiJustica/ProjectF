using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroGaspar : MonoBehaviour
{
    public float speed = 5f;  // velocidade do projétil
    public float speedY = 2f; 
    private int damage = 1;

    private Transform jogador;


    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (jogador != null)
        {
            // Mantém a posição X e Z do projétil, mas ajusta a posição Y para seguir o jogador
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            float novaPosicaoY = Mathf.MoveTowards(transform.position.y, jogador.position.y, speedY * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, novaPosicaoY, transform.position.z);
        }
    }


    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("DestruirObjeto")){
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Player")){
            gameManager.Lifes -= damage;
            Destroy(gameObject);
        }
    }
}
