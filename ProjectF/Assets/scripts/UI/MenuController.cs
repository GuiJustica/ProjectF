using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public TextMeshProUGUI DescricaoTxt;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
        gameManager = GameManager.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuCanvas.activeSelf && PauseController.JogoPausado)
            {
                return;
            }
            menuCanvas.SetActive(!menuCanvas.activeSelf);
            PauseController.SetPause(menuCanvas.activeSelf);

        }
        DescricaoTxt.text = LevantarAntena.antennasRaised.ToString() + "/?";
    }
}
