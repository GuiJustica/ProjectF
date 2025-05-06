using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public RectTransform arrow; // Referência para a seta
    public TextMeshProUGUI[] options; // Lista das opções de texto
    private int currentIndex = 0; // Índice da opção atual

    void Start()
    {
        UpdateArrowPosition();
        instructionsPanel.SetActive(false);
    }
    public GameObject instructionsPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex = (currentIndex - 1 + options.Length) % options.Length;
            UpdateArrowPosition();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex = (currentIndex + 1) % options.Length;
            UpdateArrowPosition();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectOption();
        }
    }

    public void PlayGame(){
        SceneManager.LoadSceneAsync("Entrada FEI");
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        instructionsPanel.SetActive(false);
    }


    void UpdateArrowPosition()
    {
        // Ajusta a posição da seta para a esquerda da opção selecionada
        arrow.position = new Vector3(270, options[currentIndex].transform.position.y, 0);
    }

    void SelectOption()
    {
        Debug.Log("Selecionou: " + options[currentIndex].text);
        switch (options[currentIndex].text)
        {
            case "JOGAR":
                PlayGame();
                break;
            case "INSTRUÇÕES":
                instructionsPanel.SetActive(true);
                break;
            case "SAIR":
                QuitGame();
                break;
        }
    }
}
