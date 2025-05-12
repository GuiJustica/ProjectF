using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI DescricaoTxt;

    GameManager gameManager;

    void Start(){
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        DescricaoTxt.text = gameManager.Lifes + "/?";
        
    }
}
