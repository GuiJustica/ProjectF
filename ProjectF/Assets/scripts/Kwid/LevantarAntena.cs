using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevantarAntena : MonoBehaviour{

    public Sprite imageWithRaiseAntenna; 
    public SpriteRenderer initialImage;
    private bool changeImage = false;

    private bool cancelInteraction = false; // Variável para controlar a interação cancelada
    public GameObject interactionE; // Referência ao objeto de interação

    void Start(){
        interactionE.SetActive(false); // Desativa o objeto de interação no início
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && changeImage){
            initialImage.sprite = imageWithRaiseAntenna;
            Debug.Log("Antena levantada!");
            cancelInteraction = true; // Define a interação como cancelada
        }

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
