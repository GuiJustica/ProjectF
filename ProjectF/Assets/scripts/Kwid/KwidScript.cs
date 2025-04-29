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

    // Start is called before the first frame update
    void Start()
    {
        KwidID ??= GlobalHelper.GenerateUniqueID(gameObject); 
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
