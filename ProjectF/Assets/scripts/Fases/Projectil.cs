using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectil : MonoBehaviour
{
    public float speed = 5f;
    
    private int damage = 1;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GinasioFase"){

            if (collision.CompareTag("AlunoMaua")){
                AlunoMauaGinasio enemy = collision.GetComponent<AlunoMauaGinasio>();
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }

            else if(collision.CompareTag("DestruirPena")){
                Destroy(gameObject);
            }
        }

        
    }
}