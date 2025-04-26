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

    public GameObject buttonFood;

    public GameObject buttonDoubleShot;

    public GameObject imgFood;

    public GameObject imgDoubleShot;

    public GameObject fullLife;


    public TextMeshProUGUI qtdMoney;

    public TextMeshProUGUI qtdlife;

    public TextMeshProUGUI textFood;

    public TextMeshProUGUI descFood;

    public TextMeshProUGUI descDoubleShoot;
    

    public TextMeshProUGUI textDoubleShot;



    private bool playerInRange = false;

    GameManager gameManager = new GameManager();


    void Start(){
        interactionE.SetActive(false);
        imgMoney.SetActive(false);
        imgLife.SetActive(false);
        imgFood.SetActive(false);
        imgDoubleShot.SetActive(false);
        shoppingMenu.SetActive(false);
        buttonBack.SetActive(false);
        buttonFood.SetActive(false);
        buttonDoubleShot.SetActive(false);
        qtdlife.gameObject.SetActive(false);
        qtdMoney.gameObject.SetActive(false);
        textFood.gameObject.SetActive(false);
        textDoubleShot.gameObject.SetActive(false);
        descDoubleShoot.gameObject.SetActive(false);
        descFood.gameObject.SetActive(false);
        fullLife.SetActive(false);

        
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            shoppingMenu.SetActive(true);
            imgMoney.SetActive(true);
            imgLife.SetActive(true);
            imgFood.SetActive(true);
            imgDoubleShot.SetActive(true);
            buttonBack.SetActive(true);
            buttonFood.SetActive(true);
            buttonDoubleShot.SetActive(true);
            qtdlife.gameObject.SetActive(true);
            qtdMoney.gameObject.SetActive(true);
            textFood.gameObject.SetActive(true);
            textDoubleShot.gameObject.SetActive(true);
            descDoubleShoot.gameObject.SetActive(true);
            descFood.gameObject.SetActive(true);
            interactionE.SetActive(false);
            qtdlife.text = "X " + gameManager.Lifes;
            qtdMoney.text = "X " + gameManager.Money;
        }

    }

    public void CloseShoppingMenu(){
        shoppingMenu.SetActive(false);
        imgMoney.SetActive(false);
        imgLife.SetActive(false);
        imgFood.SetActive(false);
        imgDoubleShot.SetActive(false);
        buttonBack.SetActive(false);
        buttonFood.SetActive(false);
        buttonDoubleShot.SetActive(false);
        qtdlife.gameObject.SetActive(false);
        qtdMoney.gameObject.SetActive(false);
        textFood.gameObject.SetActive(false);
        textDoubleShot.gameObject.SetActive(false);
        descDoubleShoot.gameObject.SetActive(false);
        descFood.gameObject.SetActive(false);
        
    }

    public void BuyFood(){
        Button btn = buttonFood.GetComponent<Button>();
        
        if(gameManager.Money >= 100){
            btn.interactable = true;

            if(gameManager.Lifes == 10){
                fullLife.SetActive(true);
                Invoke("hideText" , 2f);
            }
            else{
                gameManager.Money -= 100;
                gameManager.Lifes += 1;

                qtdMoney.text = "X " + gameManager.Money.ToString();
                qtdlife.text = "X " + gameManager.Lifes.ToString();
            }
            
        }     

        btn.interactable = false;   
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


    void hideText(){
        fullLife.SetActive(false);
    }
}