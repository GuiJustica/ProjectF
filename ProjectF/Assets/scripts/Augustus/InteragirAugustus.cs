using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteragirAugustus : MonoBehaviour{

    public GameObject interactionE;

    public GameObject imgMoney;

    public GameObject imgLife;

    public GameObject shoppingMenu;

    public GameObject buttonBack;

    public TextMeshProUGUI qtdMoney;

    public TextMeshProUGUI qtdlife;

    private bool playerInRange = false;


    void Start(){
        interactionE.SetActive(false);
        imgMoney.SetActive(false);
        imgLife.SetActive(false);
        shoppingMenu.SetActive(false);
        buttonBack.SetActive(false);
        qtdlife.gameObject.SetActive(false);
        qtdMoney.gameObject.SetActive(false);

        
    }

    void Update(){
        GameManager gameManager = new GameManager();
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            shoppingMenu.SetActive(true);
            imgMoney.SetActive(true);
            imgLife.SetActive(true);
            buttonBack.SetActive(true);
            qtdlife.gameObject.SetActive(true);
            qtdMoney.gameObject.SetActive(true);
            interactionE.SetActive(false);
            qtdlife.text = "X " + gameManager.Lifes;
            qtdMoney.text = "X " + gameManager.Money;
        }

    }

    public void CloseShoppingMenu(){
        shoppingMenu.SetActive(false);
        imgMoney.SetActive(false);
        imgLife.SetActive(false);
        buttonBack.SetActive(false);
        qtdlife.gameObject.SetActive(false);
        qtdMoney.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            interactionE.SetActive(true);
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            interactionE.SetActive(false);
            playerInRange = false;
        }
    }
}
