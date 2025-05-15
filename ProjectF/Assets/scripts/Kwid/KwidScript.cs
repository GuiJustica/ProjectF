using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
public class KwidScript : MonoBehaviour, IInteractable
{
    //achievements
    public GameObject achievements; // Referência ao objeto de interação

    public bool achAtivo = false;


    //Achievement Especifico do Kwid

    public int ach01Code;





   public bool TaLevantada { get; private set; }
   public string KwidID {get; private set ; }
   public Sprite levantadoSprite;
   public SpriteRenderer initialImage;
   private bool cancelInteraction = false;

   public static int antennasRaised = 0;





    // Start is called before the first frame update
    void Start()
    {

        // Desativa o objeto de interação no início

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
        ach01Code = PlayerPrefs.GetInt("AchveCodigoMudado");
        Debug.Log("Codigo" + ach01Code);
        Debug.Log("Antenas" + antennasRaised);
        if (antennasRaised == 10 && ach01Code != 12345){
            Debug.Log("ENTROU AQUI");


            StartCoroutine(ShowAchievement());
            //achievements.SetActive(true);
            //Invoke("DesabilitarAchievements", 4f);
            //achievementConquistado = true;


        }
    }

    IEnumerator ShowAchievement()
    {

        achAtivo = true;
        ach01Code = 12345;
        Debug.Log("ENTROU AQUI SHOWACHIEVE");
        PlayerPrefs.SetInt("AchveCodigoMudado", ach01Code);


        achievements.SetActive(true);

        yield return new WaitForSeconds(7);
        //resetar

        achievements.SetActive(false);


        achAtivo = false;


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
    public void LevantaAntena(){
        if (!cancelInteraction){
            SetLevantada(true);
            antennasRaised++;
            PlayerPrefs.SetInt(KwidID, 1); // Salva que essa antena foi levantada
            PlayerPrefs.SetInt("antenasRaised", antennasRaised); // Salva o número total de antenas levantadas
            Debug.Log("Numero de Antenas levantadas!" + antennasRaised);
        }

    }

    public void SetLevantada(bool levantada){

        if (TaLevantada = levantada){
            GetComponent<SpriteRenderer>().sprite = levantadoSprite;
            cancelInteraction = true;

        }
    }
}
