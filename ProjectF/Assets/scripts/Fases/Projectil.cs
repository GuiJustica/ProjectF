using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectil : MonoBehaviour
{
    public float speed = 5f;
    
    private int damage = 1;

    GameManager gameManager;
    void Start(){
        Scene scene = SceneManager.GetActiveScene();
        gameManager = GameManager.Instance;

        if(scene.name == "GinasioFase"){
            damage = 1;
        }

        if(scene.name == "Maua"){
            damage = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision){
        AlunoMauaGinasio enemy = collision.GetComponent<AlunoMauaGinasio>();
        GasparGinasio gaspar = collision.GetComponent<GasparGinasio>();

        

        if (collision.CompareTag("AlunoMaua")){
            int auxDamage = damage;

            if(gameManager.BuyFeathers){
                auxDamage += 1;
                Debug.Log("Acertou AlunoMaua com dano: " + auxDamage);
                enemy.TakeDamage(auxDamage);
                //Debug.Log("Dado " + auxDamage);
                Destroy(gameObject);
            }
            else{
                Debug.Log("Acertou AlunoMaua com dano: " + damage);
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        else if(collision.CompareTag("DestruirPena")){
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Gaspar")){
            int auxDamage = damage;

            if(gameManager.BuyFeathers){
                auxDamage += 1;
                gaspar.TakeDamage(auxDamage);
                //Debug.Log("Dado " + auxDamage);
                Destroy(gameObject);
            }
            else{
                gaspar.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}