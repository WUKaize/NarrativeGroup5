using UnityEngine;
using System.Collections.Generic;

// 序列化对话行，可以放在类外面，没问题
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
    
    // ✅ 移到类内部
    public GameObject DimOverlay;

    public void OnClickPage()
    {
        var list = new List<(string speaker, string content)>();
        foreach(var line in dialogueLines)
        {
            list.Add( (line.speaker, line.content) );
        }
        dialogueManager.StartDialogue(list);

        // ✅ 增加判空，防止忘记拖物体报错
        if(DimOverlay != null)
        {
            DimOverlay.SetActive(true);
        }
    }
}
