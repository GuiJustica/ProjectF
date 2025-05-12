using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
//using UnityEngine.InputSystem;
public class KwidScript : MonoBehaviour, IInteractable
{
   public bool TaLevantada { get; private set; }
   public string KwidID {get; private set ; }
   public Sprite levantadoSprite;
   public SpriteRenderer initialImage;
   private bool cancelInteraction = false;

    public static int antennasRaised = 0;

    public GameObject achievements; // Referência ao objeto de interação

    private bool achievementConquistado = false;

    // Start is called before the first frame update
    void Start()
    {
        achievements.SetActive(false); // Desativa o objeto de interação no início

        KwidID ??= GlobalHelper.GenerateUniqueID(gameObject);
        if(PlayerPrefs.GetInt(KwidID , 0) == 1){
            initialImage.sprite = levantadoSprite;
        }

        //carregue o número de antenas levantadas
        antennasRaised = PlayerPrefs.GetInt("antenasRaised");
        //Resetar antenasRaised
        //PlayerPrefs.DeleteAll();

    }

    void Update(){
        if (antennasRaised == 10 && !achievementConquistado)
        {
            achievements.SetActive(true);
            Invoke("DesabilitarAchievements", 4f);
            achievementConquistado = true;


        }
    }
    public void DesabilitarAchievements(){
        achievements.SetActive(false);
    }

    public void Interact()
    {
        if (!PodeInteract()) return;
        LevantaAntena();
    }

    public bool PodeInteract()
    {
        return !TaLevantada;
    }
    public void LevantaAntena()
    {
        if (cancelInteraction == false)
        {
            SetLevantada(true);
            antennasRaised++;
            PlayerPrefs.SetInt(KwidID, 1); // Salva que essa antena foi levantada
            PlayerPrefs.SetInt("antenasRaised", antennasRaised); // Salva o número total de antenas levantadas
            Debug.Log("Numero de Antenas levantadas!" + antennasRaised);
        } 
        
    }

    public void SetLevantada(bool levantada)
    {

        if (TaLevantada = levantada)
        {
            GetComponent<SpriteRenderer>().sprite = levantadoSprite;
            cancelInteraction = true;

        }
    }
}
