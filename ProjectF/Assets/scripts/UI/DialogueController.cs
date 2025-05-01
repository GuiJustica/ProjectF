using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance {get ; private set ;}
    public GameObject dialoguePanel;
    public TMP_Text dialogText, nameText;
    public Image retratoImage;
    public Transform escolhasContainer;
    public GameObject escolhaButtonPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
    }
 
    public void ShowDialogueUI (bool show)
    {
        dialoguePanel.SetActive(show);

    }

    public void SetNPCInfo(string npcNome, Sprite retrato)
    {
        nameText.text = npcNome;
        retratoImage.sprite = retrato;
    }

    public void SetDialogueText(string text)
    {
        dialogText.text = text;
    }

    public void ClearChoices()
    {
        foreach (Transform child in escolhasContainer) Destroy(child.gameObject);
    }

    public GameObject CreateButton(string choiceText, UnityEngine.Events.UnityAction onClick)
    {
        GameObject escolhaBotao = Instantiate(escolhaButtonPrefab, escolhasContainer);
        escolhaBotao.GetComponentInChildren<TMP_Text>().text = choiceText;
        escolhaBotao.GetComponent<Button>().onClick.AddListener(onClick);
        return escolhaBotao;
    }
}
