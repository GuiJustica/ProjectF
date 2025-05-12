using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovLevel : MonoBehaviour{
    public float moveSpeed = 10f; // Velocidade de movimenta��o
    private Vector2 moveDirection; // Dire��o do movimento

    private Rigidbody2D rb2d;
    private Animator animator;

    public GameObject projectilPrefab;
    public GameObject projectilPrefabPenasDuplas;

    public Transform firePoint;

    public AudioSource audioSourceDano;

    private bool atirar = true;

    GameManager gameManager;

    private bool grounded;
    public float jumpForce = 0;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = GameManager.Instance;
    }

    void Update(){
        Scene scene = SceneManager.GetActiveScene();
        // Obtendo a entrada do usu�rio para movimenta��o
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        //float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)
        Vector3 direc = new Vector3(moveX, 0, 0);
        transform.Translate(direc * 5 * Time.deltaTime);
        animator.SetBool("Movi",moveX != 0);
        print("Grounded "+ grounded);

        if(Input.GetKeyDown(KeyCode.Space) && atirar){
            StartCoroutine(CooldownShot());
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded){ // Verifica se a tecla de pulo foi pressionada e se está no chão
            jump();
        }

        IEnumerator CooldownShot(){
            atirar = false; // Impede novos tiros

            if(gameManager.BuyFeathers){
                Instantiate(projectilPrefabPenasDuplas , firePoint.position , firePoint.rotation);
                Debug.Log("ProjetilDuploPenas criado em: " + firePoint.position);
                yield return new WaitForSeconds(1f); // Espera antes de permitir novo tiro
                atirar = true;
            }
            else{
                Instantiate(projectilPrefab , firePoint.position , firePoint.rotation);
                Debug.Log("Projetil criado em: " + firePoint.position);
                yield return new WaitForSeconds(1f); // Espera antes de permitir novo tiro
                atirar = true;
            }
        }

        /*if (scene.name == "GinasioFase" || scene.name == "GinasioDentro" || scene.name == "GinasioReconquistado" || scene.name == "Castelinho"  || scene.name == "Capela" || scene.name == "TerracoFase" || scene.name == "CastelinhoRecuperado"){
            //Virar para o lado que está andando
            if(moveX>0.01f){
                transform.localScale = new Vector3(10, 10, 1);
            }else if(moveX<-0.01f){
                transform.localScale = new Vector3(-10, 10, 1);
            }else{
                transform.localScale = transform.localScale;
            }
        }*/

            //Virar para o lado que está andando
            if(moveX>0.01f){
                transform.localScale = new Vector3(15, 15, 1);
            }else if(moveX<-0.01f){
                transform.localScale = new Vector3(-15, 15, 1);
            }else{
                transform.localScale = transform.localScale;
            }

        if (PauseController.JogoPausado){
            rb2d.velocity = Vector2.zero;
            moveSpeed = 0;
            animator.SetBool("Movi", false);
            return;
        }
        moveSpeed = 10f;
        rb2d.velocity = moveDirection * moveSpeed;
    }

        private void jump(){
            rb2d.velocity = Vector2.up * jumpForce;
            grounded = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        }
    }

}
