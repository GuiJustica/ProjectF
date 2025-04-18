using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevantarAntena : MonoBehaviour{

    public Sprite imageWithRaiseAntenna; 
    public SpriteRenderer initialImage;
    private bool changeImage = false;

    public static int antennasRaised = 0;

    private bool cancelInteraction = false; // Variável para controlar a interação cancelada
    public GameObject interactionE; // Referência ao objeto de interação

    public TextMeshProUGUI text;

    private bool antennaAleradyRaised = false;

    void Start(){
        interactionE.SetActive(false); // Desativa o objeto de interação no início
        text.gameObject.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && changeImage){
            initialImage.sprite = imageWithRaiseAntenna;
            Debug.Log("Antena levantada!");
            text.gameObject.SetActive(true);
            Invoke("hideText", 2f); // Chama a função hideText após 2 segundos
            cancelInteraction = true; // Define a interação como cancelada

            if(!antennaAleradyRaised){
                antennasRaised++;
                antennaAleradyRaised = true; // Define que a antena já foi levantada
            }
            text.text = "Antenas do kwid levantadas: " + antennasRaised.ToString() + "/15";
        }

    }

    void hideText(){
        text.gameObject.SetActive(false);
    }
    


    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player") && !cancelInteraction){
            changeImage = true;
            interactionE.SetActive(true);
        }

        if (cancelInteraction){
            interactionE.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            interactionE.SetActive(false);
        }
    }
}
