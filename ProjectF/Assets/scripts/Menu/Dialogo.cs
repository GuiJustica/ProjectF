using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Dialogo : MonoBehaviour{
    public TextMeshProUGUI textComponent;
    [TextArea(3,10)]
    public string[] lines;
    public float textSpeed;
    private int index;

    void Start(){
        textComponent.text = string.Empty;
        StartDialog();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialog(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines [index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if (index < lines.Length -1 ){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }else{
            gameObject.SetActive(false);
        }
    }

}