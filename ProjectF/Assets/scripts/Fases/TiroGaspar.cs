using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiroGaspar : MonoBehaviour
{
    public float speed = 5f;  // velocidade do projétil (para o modo homing)
    public float speedY = 2f; // usado no outro modo (GinasioFase)
    private int damage = 1;

    private Transform jogador;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        GameObject jogadorObj = GameObject.FindGameObjectWithTag("Player");
        if (jogadorObj != null)
            jogador = jogadorObj.transform;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "CastelinhoFase")
        {
            if (jogador != null)
            {
                // O projétil se move inteiramente na direção do jogador,
                transform.position = Vector3.MoveTowards(transform.position, jogador.position, speed * Time.deltaTime);

            }
        }

        else if(scene.name == "TerracoFase"){
            if (jogador != null)
            {
                // O projétil se move inteiramente na direção do jogador,
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                float novaPosicaoY = Mathf.MoveTowards(transform.position.y, jogador.position.y, speedY * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, novaPosicaoY, transform.position.z);

            }
        }



        else if (scene.name == "GinasioFase" || scene.name == "Maua")
        {
            if (jogador != null)
            {
                // Nesse modo, o projétil segue horizontalmente mantendo a posição X
                // e ajusta somente o valor Y para seguir o jogador
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                float novaPosicaoY = Mathf.MoveTowards(transform.position.y, jogador.position.y, speedY * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, novaPosicaoY, transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestruirObjeto"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            gameManager.Lifes -= damage;
            Destroy(gameObject);
        }
    }
}
