using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlunoMauaGinasio : MonoBehaviour
{

    public GameObject projectilPrefab;
    public float intervaloDeTiro = 2.0f;
    private float contadorDeTempo;

    private int lifes = 1;
    public float tempoMinEntreTiros = 2f;  // Tempo mínimo entre tiros
    public float tempoMaxEntreTiros = 5f;  // Tempo máximo entre tiros
    public Transform player;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start(){

        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "FasePredioK"){
            lifes = 2;
        }

        if(scene.name == "CastelinhoFase"){
            lifes = 3;
        }

        if (scene.name == "Maua")
        {
            lifes = 4;
        }

        gameManager = GameManager.Instance;

        StartCoroutine(AtirarRandomicamente());

        IEnumerator AtirarRandomicamente()
        {
            while (true) // Loop infinito para manter o inimigo atirando
            {
                float espera = Random.Range(tempoMinEntreTiros, tempoMaxEntreTiros); // Tempo aleatório entre tiros
                yield return new WaitForSeconds(espera); // Espera antes de atirar
                if (GameObject.FindGameObjectsWithTag("Bola").Length >= 7)
                continue;
                else Atirar();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Atirar()
    {
        Quaternion shootRotation;
        // Se o player estiver na esquerda do inimigo
        if (player.position.x < transform.position.x)
        {
            // tiro vai para a esquerda
            shootRotation = Quaternion.Euler(0, 0, 180f);
        }
        else
        {
            // Caso contrario tiro vai para a direita
            shootRotation = Quaternion.Euler(0, 0, 0f);
        }
        Instantiate(projectilPrefab, transform.position, shootRotation);
    }

    public void TakeDamage(int damage){
        lifes -= damage;

        if(lifes <= 0){
            Destroy(gameObject);
            gameManager.Money += 20;
        }

    }
}
