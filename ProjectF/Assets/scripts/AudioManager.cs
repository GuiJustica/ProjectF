using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource backgroundMusic;  // Áudio padrão
         // Áudio para a cena "GinasioFase"
    GameManager gameManager;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Mantém o AudioManager entre as cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GinasioFase" || scene.name == "CastelinhoFase" || scene.name == "FasePredioK" || scene.name == "TerracoFase" || scene.name == "MainMenu")
        {
            // Se estiver na cena "GinasioFase", para a música padrão e toca o bossBackground.
            if (backgroundMusic.isPlaying)
            backgroundMusic.Stop();
            
            if (scene.name == "GinasioFase" && gameManager.PassouGinasio == true){
                if (!backgroundMusic.isPlaying)
                backgroundMusic.Play();
            }
        }
        else
        {        
            // Se a música padrão não estiver tocando, inicia-a.
            if (!backgroundMusic.isPlaying)
                backgroundMusic.Play();
        }
    }
}
