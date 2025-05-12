using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public TextMeshProUGUI DescricaoTxt;
    GameManager gameManager;
    public static int antennasRaised = 0;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);

        gameManager = GameManager.Instance;
        
        antennasRaised = PlayerPrefs.GetInt("antenasRaised");
        
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
        DescricaoTxt.text = antennasRaised.ToString() + "/?";
    }
}
