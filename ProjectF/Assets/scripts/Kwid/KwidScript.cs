using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.InputSystem;
public class KwidScript : MonoBehaviour, IInteractable
{
   public bool TaLevantada { get; private set; }
   public string KwidID {get; private set ; }
   public Sprite levantadoSprite;
   public Sprite initialImage;
   private bool cancelInteraction = false;

    // Start is called before the first frame update
    void Start()
    {
        KwidID ??= GlobalHelper.GenerateUniqueID(gameObject); 
        if (PlayerPrefs.GetInt(KwidID, 0) == 1){ // Verifica se a antena já foi levantada
            initialImage = levantadoSprite;
            cancelInteraction = true;
            TaLevantada = true;
        }
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
    }

    public void SetLevantada(bool levantada)
    {
        
        if (TaLevantada = levantada)
        {
            GetComponent<SpriteRenderer>().sprite = levantadoSprite;
        }
    }
}
