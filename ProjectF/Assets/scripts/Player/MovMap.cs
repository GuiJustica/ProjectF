using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovePlayer : MonoBehaviour{
    public float moveSpeed = 10f; // Velocidade de movimenta��o
    private Vector2 moveDirection; // Dire��o do movimento

    private Rigidbody2D rb2d;
    private Animator animator;

    public GameObject projectilPrefab;
    public GameObject projectilPrefabPenasDuplas;

    public Transform firePoint;

    private bool atirar = true;

    GameManager gameManager;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameManager = GameManager.Instance;
    }

    

    

    void Update(){
        //Scene scene = SceneManager.GetActiveScene();
        // Obtendo a entrada do usu�rio para movimenta��o
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)
        // Calculando a dire��o do movimento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal

        
        if(Input.GetKeyDown(KeyCode.Space) && atirar){
            StartCoroutine(CooldownShot());
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
        

        // if(scene.name == "PredioK"){
        //     //moveY = 0;
        //     Debug.Log("MoveY " + moveY);
        // }
        

        /*Virar para o lado que está andando*/
        if(moveX>0.01f){
            transform.localScale = new Vector3(15, 15, 1);
        }else if(moveX<-0.01f){
            transform.localScale = new Vector3(-15, 15, 1);
        }else{
            transform.localScale = transform.localScale;
        }

        animator.SetBool("Movi",moveX != 0);
        animator.SetBool("MovFrente",moveY < 0);
        animator.SetBool("MovTras", moveY > 0);

        if (PauseController.JogoPausado)
        {
            rb2d.velocity = Vector2.zero;
            moveSpeed = 0;
            animator.SetBool("MovDir", false);
            animator.SetBool("MovFrente", false);
            animator.SetBool("MovTras", false);
            return;
        }
        moveSpeed = 10f;
        rb2d.velocity = moveDirection * moveSpeed;
    }

    void FixedUpdate(){
        // Aplicando a movimenta��o no Rigidbody2D
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision){
        Scene scene = SceneManager.GetActiveScene();

        if (collision.CompareTag("GinasioScene")){
            GameManager.changeScene("Ginasio FEI");
        }

        // else if (collision.CompareTag("CapelaScene")){
        //     GameManager.changeScene("Capela FEI");
        // }

        else if(collision.CompareTag("PreviousScene")){
            //Debug.Log("Passou Ginasio = " + gameManager.PassouGinasio);

            if (scene.name == "GinasioDentro"){
                GameManager.changeScene("Ginasio FEI");
            }

            else if (scene.name == "GinasioFase"){
                GameManager.changeScene("Ginasio FEI");
            }

            else if (scene.name == "GinasioReconquistado"){
                GameManager.changeScene("Ginasio FEI");
            }
        }

        else if (collision.CompareTag("Refeitorio FEI")){
            GameManager.changeScene("RefeitorioDentro");
        }

        else if (collision.CompareTag("TerracoScene")){
        GameManager.changeScene("TerracoFase");
        }

        if (scene.name == "Caminho_Capela_Ginasio FEI"){
            if (collision.CompareTag("RefeitorioScene")){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }
            else if (collision.CompareTag("CapelaScene")){
                GameManager.changeScene("Capela");
            }
            else if (collision.CompareTag("GinasioScene")){
                GameManager.changeScene("Ginasio FEI");
            }

        }

        else if (scene.name == "Entrada FEI"){
            if(collision.CompareTag("CastelinhoScene")){
                GameManager.changeScene("Castelinho");
            }
        }

        if (collision.CompareTag("NextScene")){

            if(scene.name == "Subida FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Entrada FEI"){
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("Estacionamento FEI");
            }

            if(scene.name == "Ginasio FEI" && gameManager.PassouGinasio) {
                GameManager.changeScene("GinasioReconquistado");
            }
            
            else if (scene.name == "Ginasio FEI") {
                GameManager.changeScene("GinasioDentro");
            }

            else if (scene.name == "PredioK")
            {
                GameManager.changeScene("Elevador");
            }

            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("Estacionamento FEI");
            }
        }


        else if (collision.CompareTag("PredioK")){
            GameManager.changeScene("PredioK");
        }


        else if (collision.CompareTag("GinasioScene")){
            GameManager.changeScene("Ginasio FEI");
        }

        else if(collision.CompareTag("PreviousScene")){

            if(scene.name == "Subida FEI"){
                GameManager.changeScene("Entrada FEI");
            }

            else if(scene.name == "Caminho_Capela_Ginasio FEI"){
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "PredioK"){
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "Elevador"){
                GameManager.changeScene("PredioK");
            }


            else if (scene.name == "Caminho_Refeitorio FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Ginasio FEI"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }

            else if (scene.name == "Estacionamento FEI"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "RefeitorioDentro"){
                GameManager.changeScene("Caminho_Refeitorio FEI");
            }

            else if (scene.name == "GinasioDentro"){
                GameManager.changeScene("Ginasio FEI");
            }

            else if (scene.name == "Capela"){
                GameManager.changeScene("Caminho_Capela_Ginasio FEI");
            }
        }

        else if (collision.CompareTag("Refeitorio FEI")){
            GameManager.changeScene("RefeitorioDentro");
        }

    }
}
