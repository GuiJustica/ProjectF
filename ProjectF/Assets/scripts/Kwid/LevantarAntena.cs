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

    public string antennaID; // ID da antena, usado para salvar o estado no PlayerPrefs

    void Start(){
        interactionE.SetActive(false); // Desativa o objeto de interação no início
        text.gameObject.SetActive(false);


        if (PlayerPrefs.GetInt(antennaID, 0) == 1){ // Verifica se a antena já foi levantada
            initialImage.sprite = imageWithRaiseAntenna;
            cancelInteraction = true;
            antennaAleradyRaised = true;
        }

        PlayerPrefs.DeleteAll();

        //carregue o número de antenas levantadas
        antennasRaised = PlayerPrefs.GetInt("antenasRaised");
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
                PlayerPrefs.SetInt(antennaID, 1); // Salva que essa antena foi levantada
                PlayerPrefs.SetInt("antenasRaised", antennasRaised); // Salva o número total de antenas levantadas
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
