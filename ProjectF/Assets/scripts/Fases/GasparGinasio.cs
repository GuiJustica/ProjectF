using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasparGinasio : MonoBehaviour
{
    public GameObject projectilPrefab;

    public GameObject iniciarDialogo;
    public float intervaloDeTiro = 2.0f;
    private int lifes = 10;
    GameManager gameManager;

    // Variáveis para o padrão do Ginasio (TerracoFase)
    public float distanciaMovimento = 5f; // Distância que o fantasma se move para cima/baixo
    public float velocidadeMovimento = 5f;  // Velocidade do movimento
    private Vector3 posicaoInicial;       // Guarda a posição inicial

    public GameObject paredebool;

    // Variáveis para o padrão CastelinhoFase
    private Vector3 targetPosition1 = new Vector3(-24f, -22f, 0f);
    private Vector3 targetPosition2 = new Vector3(-6f, -16f, 0f);
    private Vector3 targetPosition3 = new Vector3(10f, -22f, 0f);
    private Vector3 targetPosition4 = new Vector3(-6f, -21f, 0f);

    private Coroutine movimentoCoroutine;

    private bool ganhouDinheiro = false;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        // Ajusta as vidas conforme a cena
        if (scene.name == "TerracoFase")
        {
            lifes = 15;
        }
        if (scene.name == "CastelinhoFase")
        {
            lifes = 20;
        }

        gameManager = GameManager.Instance;
        posicaoInicial = transform.position; // Registra a posição inicial

        // Escolhe qual padrão de movimento iniciar com base na cena
        if (scene.name == "CastelinhoFase")
        {
            // No CastelinhoFase, definimos uma posição inicial e iniciamos o loop com os 3 alvos
            transform.position = new Vector3(-6f, -16f, 0f);
            movimentoCoroutine = StartCoroutine(MovimentoLoopCastelinho());
        }
        else if (scene.name == "GinasioFase")
        {
            movimentoCoroutine = StartCoroutine(MovimentoLoopGinasio());
        }

        iniciarDialogo.SetActive(false);
        paredebool.SetActive(true);
    }

    // Movimento para a cena GinasioFase
    IEnumerator MovimentoLoopGinasio()
    {
        while (true)
        {
            // Atira na posição atual
            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            // Move para cima do ponto inicial
            yield return StartCoroutine(MoverPara(posicaoInicial + Vector3.up * distanciaMovimento));

            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            // Volta para a posição inicial
            yield return StartCoroutine(MoverPara(posicaoInicial));

            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            // Move para abaixo do ponto inicial
            yield return StartCoroutine(MoverPara(posicaoInicial + Vector3.down * distanciaMovimento));

            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);
        }
    }

    // Movimento para a cena CastelinhoFase
    IEnumerator MovimentoLoopCastelinho()
    {
        while (true)
        {
            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);
            
            yield return StartCoroutine(MoverPara(targetPosition1));

            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            yield return StartCoroutine(MoverPara(targetPosition2));

            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            yield return StartCoroutine(MoverPara(targetPosition3));

            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            yield return StartCoroutine(MoverPara(targetPosition4));
        }
    }

    // Coroutine que movimenta o fantasma suavemente até o destino definido
    IEnumerator MoverPara(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidadeMovimento * Time.deltaTime);
            yield return null; 
        }
        transform.position = destino;
    }

    void Atirar()
    {
        Instantiate(projectilPrefab, transform.position, transform.rotation);
    }

    public void TakeDamage(int damage)
    {
        Scene scene = SceneManager.GetActiveScene();

        lifes -= damage;
        Debug.Log("Gaspar Lifes = " + lifes);

        if (lifes <= 0)
        {
            gameManager.PassouGinasio = true;
            iniciarDialogo.SetActive(true);
            paredebool.SetActive(false);

            if (movimentoCoroutine != null)
            {
                StopCoroutine(movimentoCoroutine);

                if (scene.name == "TerracoFase")
                {
                    gameManager.PassouPredioK = true;
                    Debug.Log("Passou do Prédio K = " + gameManager.PassouPredioK);
                    Vector2 gasparPositon = transform.position;
                    gasparPositon.x = 10.79f;
                    gasparPositon.y = -1.91f;
                    transform.position = gasparPositon;
                }

                if (scene.name == "CastelinhoFase")
                {
                    gameManager.PassouCastelinho = true;
                    Debug.Log("Passou do Castelinho = " + gameManager.PassouCastelinho);
                }

                if (!ganhouDinheiro)
                {
                    gameManager.Money += 500;
                    ganhouDinheiro = true;
                }
            }
        }
    }
}
