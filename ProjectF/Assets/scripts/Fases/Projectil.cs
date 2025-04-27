using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public float speed = 5f;
    GameManager gameManager = new GameManager();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "AlunoMaua"){
            Destroy(this.gameObject);
            Destroy(coll.gameObject);

            gameManager.Money += 20;

            Debug.Log(gameManager.Money);
        }
    }
}