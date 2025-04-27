using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlunoMauaGinasio : MonoBehaviour
{

    public GameObject projectilPrefab;
    public float intervaloDeTiro = 2.0f;
    private float contadorDeTempo;

    // Start is called before the first frame update
    void Start()
    {
        
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
}