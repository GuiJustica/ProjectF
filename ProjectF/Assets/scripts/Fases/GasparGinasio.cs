using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasparGinasio : MonoBehaviour
{
    public GameObject projectilPrefab;
    public float intervaloDeTiro = 2.0f;
    private float contadorDeTempo;
    private int lifes = 10;
    GameManager gameManager;

    public float distanciaMovimento = 5f; // Distância que o fantasma se move para cima e para baixo
    public float velocidadeMovimento = 5f; // Velocidade do movimento vertical
    private Vector3 posicaoInicial; // Guarda a posição inicial

    void Start()
    {
        gameManager = GameManager.Instance;
        posicaoInicial = transform.position; // Define a posição inicial
        StartCoroutine(MovimentoLoop());
    }

    IEnumerator MovimentoLoop()
    {
        while (true)
        {
            // Atira na posição inicial
            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            // Move para cima
            yield return MoverPara(posicaoInicial + Vector3.up * distanciaMovimento);

            // Para e atira
            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            // Volta para posição inicial
            yield return MoverPara(posicaoInicial);

            // Para e atira
            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);

            // Move para baixo
            yield return MoverPara(posicaoInicial + Vector3.down * distanciaMovimento);

            // Para e atira
            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro);
        }
    }

    IEnumerator MoverPara(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidadeMovimento * Time.deltaTime);
            yield return null; // Espera um frame antes de continuar
        }
    }


    void Atirar()
    {
        Instantiate(projectilPrefab, transform.position, transform.rotation);
    }
}
