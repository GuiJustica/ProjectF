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

    GameManager gameManager;

    // Start is called before the first frame update
    void Start(){
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        contadorDeTempo += Time.deltaTime;

        if (contadorDeTempo >= intervaloDeTiro)
        {
            Atirar();
            contadorDeTempo = 0;
        }
    }

    void Atirar()
    {
        Instantiate(projectilPrefab, transform.position, transform.rotation);
    }

    public void TakeDamage(int damage){
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "GinasioFase"){
            lifes -= damage;

            if(lifes == 0){
                Destroy(gameObject);
                gameManager.Money += 20;
            }
        }

        
    }
}