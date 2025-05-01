using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
        
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
    }
}
