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
        Instantiate(projectilPrefab, transform.position, transform.rotation);
    }

    public void TakeDamage(int damage){
        lifes -= damage;

        if(lifes <= 0){
            Destroy(gameObject);
            gameManager.Money += 20;
        }

    }
}
