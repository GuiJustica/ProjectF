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

    // Start is called before the first frame update
    void Start()
    {
        KwidID ??= GlobalHelper.GenerateUniqueID(gameObject); 
        if(PlayerPrefs.GetInt(KwidID , 0) == 1){
            initialImage.sprite = levantadoSprite;
        }

        //PlayerPrefs.DeleteAll();
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
        SetLevantada(true);
        PlayerPrefs.SetInt(KwidID, 1); // Salva que essa antena foi levantada
    }

    public void SetLevantada(bool levantada)
    {
        
        if (TaLevantada = levantada)
        {
            GetComponent<SpriteRenderer>().sprite = levantadoSprite;
        }
    }
}
