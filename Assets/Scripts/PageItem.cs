using UnityEngine;
using System.Collections.Generic;

// 【关键】序列化，让 Unity 面板识别
[System.Serializable]
public class DialogueLine
{
    public string speaker;
    [TextArea(2,5)]
    public string content;
}

public class PageItem : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public List<DialogueLine> dialogueLines;

    public void OnClickPage()
    {
        var list = new List<(string speaker, string content)>();
        foreach(var line in dialogueLines)
        {
            list.Add( (line.speaker, line.content) );
        }
        dialogueManager.StartDialogue(list);
    }
}
