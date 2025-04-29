using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NovoNPCDialogo", menuName ="NPC Dialogo")]

public class NPCDialogo : ScriptableObject
{
    public string npcNome;
    public Sprite npcRetrato;
    public string[] dialogolinhas;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines;
    public float autoProgressDelay = 1.5f;
    public float speed = 0.05f;
    // public AudioClip voiceSound;
    // public float voicePitch = 1f;
    public DialogueChoice[] choices;
}

[System.Serializable]

public class DialogueChoice
{
    public int dialogueIndex;
    public string[] choices;
    public int[] nextDialogueIndexes;
}
