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
    private Vector2 lastInputDirection = Vector2.left; //guarda a ultima tecla usada (D ou A)
    GameManager gameManager;

    private bool grounded;
    public float jumpForce = 0;
    private bool esqui;

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


        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded){ // Verifica se a tecla de pulo foi pressionada e se está no chão
            jump();
        }

        if((Input.GetKeyDown(KeyCode.Q)) && grounded){
            if(moveX > 0){
                esquivaD();
            }else if(moveX < 0){
                esquivaE();
            }else if(moveX == 0){
                print("Parado");
            }
        }

        if (scene.name == "GinasioFase" || scene.name == "GinasioDentro" || scene.name == "GinasioReconquistado" || scene.name == "Castelinho" || scene.name == "CastelinhoPermissao" || scene.name == "Capela" || scene.name == "TerracoFase" || scene.name == "CastelinhoRecuperado"){
            //Virar para o lado que está andando
            if(moveX>0.01f){
                transform.localScale = new Vector3(10, 10, 1);
            }else if(moveX<-0.01f){
                transform.localScale = new Vector3(-10, 10, 1);
            }else{
                transform.localScale = transform.localScale;
            }
        }

        else{
            //Virar para o lado que está andando
            if(moveX>0.01f){
                transform.localScale = new Vector3(15, 15, 1);
            }else if(moveX<-0.01f){
                transform.localScale = new Vector3(-15, 15, 1);
            }else{
                transform.localScale = transform.localScale;
            }
        }


        // atualiza ultima tecla pressionada
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            lastInputDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastInputDirection = Vector2.left;
        }

        if(Input.GetKeyDown(KeyCode.Space) && atirar){
            StartCoroutine(CooldownShot());
        }


        IEnumerator CooldownShot(){
            Debug.Log("entrou");
            atirar = false; // Impede novos tiros

            Quaternion shootRotation;
            if (lastInputDirection == Vector2.right)
            {
                // se a ultima tecla foi "D" o projétil vai para a direita.
                shootRotation = Quaternion.Euler(0f, 0f, 180f);
                Debug.Log("Direita");
            }
            else
            {
                // se a ultima tecla foi "A"
                shootRotation = Quaternion.identity;
                Debug.Log("Esquerda");
            }

            if(gameManager.BuyFeathers){
                Instantiate(projectilPrefabPenasDuplas , firePoint.position , shootRotation);
                Debug.Log("ProjetilDuploPenas criado em: " + firePoint.position);
                yield return new WaitForSeconds(1f); // Espera antes de permitir novo tiro
                atirar = true;
            }
            else{
                Instantiate(projectilPrefab , firePoint.position , shootRotation);
                Debug.Log("Projetil criado em: " + firePoint.position);
                yield return new WaitForSeconds(1f); // Espera antes de permitir novo tiro
                atirar = true;
            }
        }



        if (PauseController.JogoPausado){
            rb2d.velocity = Vector2.zero;
            moveSpeed = 0;
            animator.SetBool("Movi", false);
            return;
        }
        // moveSpeed = 10f;
        // rb2d.velocity = moveDirection * moveSpeed;
    }

    IEnumerator espera(bool a){
        yield return new WaitForSeconds(1f);
        a = true;
        //Debug.Log("Disparo após 1 segundo");
    }

    private void jump(){
        rb2d.velocity = Vector2.up * jumpForce;
        grounded = false;
        //espera(grounded);
    }

    private void esquivaD(){
        rb2d.velocity = Vector2.right * jumpForce;
        esqui = false;
        //espera(esqui);
    }

    private void esquivaE(){
        rb2d.velocity = Vector2.left * jumpForce;
        esqui = false;
        //espera(esqui);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        Scene scene = SceneManager.GetActiveScene();
        if(collision.CompareTag("NextScene")){


            if(scene.name == "Elevador"){
                GameManager.changeScene("FasePredioK");
            }
            else if (scene.name == "CastelinhoPermissao")
            {
                GameManager.changeScene("CastelinhoFase");
            }
            else if (scene.name == "CastelinhoRecuperado")
            {
                GameManager.changeScene("CastelinhoResolvido");
            }

        }









        if (collision.CompareTag("PreviousScene"))
        {


            if (scene.name == "CastelinhoFase")
            {
                GameManager.changeScene("CastelinhoRecuperado");
            }
            else if(scene.name == "CastelinhoRecuperado")
            {
                GameManager.changeScene("Entrada FEI");
            }



        }

    }

}
