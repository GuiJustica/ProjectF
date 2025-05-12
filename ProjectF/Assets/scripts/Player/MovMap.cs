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
    public AudioSource audioSourceDano;
    private Vector2 lastInputDirection = Vector2.left; //guarda a ultima tecla usada (D ou A)
    private bool atirar = true;

    GameManager gameManager;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameManager = GameManager.Instance;
    }

    void Update(){
        Scene scene = SceneManager.GetActiveScene();
        // Obtendo a entrada do usu�rio para movimenta��o
        float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
        float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)


        if(scene.name == "Elevador" || scene.name == "FasePredioK" || scene.name == "TerracoFase"|| scene.name == "CastelinhoFase" || scene.name == "CastelinhoRecuperado"){
            if(moveY > 0 ) { //Bloqueia a movimentação para cima do personagem
                moveY = 0;

                Debug.Log("PARA CIMA BLOQUEADO");
            }
        }

        // Calculando a dire��o do movimento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal

        // atualiza ultima tecla pressionada
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInputDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInputDirection = Vector2.left;
        }

        if(Input.GetKeyDown(KeyCode.Space) && atirar){
            StartCoroutine(CooldownShot());
        }

        IEnumerator CooldownShot(){
            atirar = false; // Impede novos tiros

            Quaternion shootRotation;
            if (lastInputDirection == Vector2.right)
            {
                // se a ultima tecla foi "D" o projétil vai para a direita.
                shootRotation = Quaternion.Euler(0f, 0f, 180f);
            }
            else
            {
                // se a ultima tecla foi "A"
                shootRotation = Quaternion.identity;
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


        if(scene.name == "Teste"){
            //moveY = 0;
            Debug.Log("MoveY " + moveY);
        }

        if (scene.name == "GinasioFase" || scene.name == "GinasioDentro" || scene.name == "GinasioReconquistado" || scene.name == "Castelinho"  || scene.name == "Capela" || scene.name == "TerracoFase" || scene.name == "CastelinhoRecuperado"){
            /*Virar para o lado que está andando*/
            if(moveX>0.01f){
                transform.localScale = new Vector3(10, 10, 1);
            }else if(moveX<-0.01f){
                transform.localScale = new Vector3(-10, 10, 1);
            }else{
                transform.localScale = transform.localScale;
            }
        }


        else {
            /*Virar para o lado que está andando*/
            if(moveX>0.01f){
                transform.localScale = new Vector3(15, 15, 1);
            }else if(moveX<-0.01f){
                transform.localScale = new Vector3(-15, 15, 1);
            }else{
                transform.localScale = transform.localScale;
            }
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

            else if (scene.name == "CastelinhoFaseReconquistado")
            {
                GameManager.changeScene("CastelinhoRecuperado");
            }


            else if (scene.name == "GinasioReconquistado"){
                GameManager.changeScene("Ginasio FEI");
            }

            else if (scene.name == "FasePredioK"){
                GameManager.changeScene("Elevador");
            }

            else if (scene.name == "TerracoFase"){
                GameManager.changeScene("Subida FEI");
            }

            else if(scene.name == "PredioKReconquistado"){
                GameManager.changeScene("Subida FEI");
            }

            else if (scene.name == "Castelinho"){
                GameManager.changeScene("Entrada FEI");
            }

            else if (scene.name == "CastelinhoFase"){
                GameManager.changeScene("Entrada FEI");
            }

            else if (scene.name == "CastelinhoRecuperado"){
                GameManager.changeScene("Entrada FEI");
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

        if (scene.name == "Entrada FEI"){
            if (collision.CompareTag("CastelinhoScene"))
            {
                GameManager.changeScene("Castelinho");
            }
            if (collision.CompareTag("CastelinhoScene") && gameManager.PassouCastelinho){
                GameManager.changeScene("CastelinhoRecuperado");
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

            else if (scene.name == "Castelinho"){
                GameManager.changeScene("CastelinhoFase");
            }
        }

        // if(scene.name == "Ginasio FEI" && gameManager.PassouGinasio) {
        //         GameManager.changeScene("GinasioReconquistado");
        //     }

        //     else if (scene.name == "Ginasio FEI") {
        //         GameManager.changeScene("GinasioDentro");
        //     }

        if(collision.CompareTag("PredioK") && gameManager.PassouPredioK){
            GameManager.changeScene("PredioKReconquistado");
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

        if (collision.CompareTag("Bola")){
                AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
            }
    }
}
