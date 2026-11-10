using UnityEngine;
using System.Collections.Generic;

public class PageItem : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public List<(string speaker, string content)> dialogueLines;

    public void OnClickPage()
    {
        dialogueManager.StartDialogue(dialogueLines);
    }
}
