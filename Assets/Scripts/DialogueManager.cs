using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [Header("引用拖拽赋值")]
    public GameObject dialoguePanel;
    public TMP_Text speakerText;
    public TMP_Text contentText;
    public GameObject nextBtn;

    // 存一组对话：说话人 + 台词
    private Queue<(string speaker, string content)> dialogueQueue;
    private bool isDialogueActive;

    void Start()
    {
        dialogueQueue = new Queue<(string, string)>();
        dialoguePanel.SetActive(false);
    }

    // 外部调用：开启一段对话
    public void StartDialogue(List<(string speaker, string content)> lines)
    {
        dialogueQueue.Clear();
        foreach (var line in lines)
        {
            dialogueQueue.Enqueue(line);
        }
        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        ShowNextLine();
    }

    // 展示下一句
    public void ShowNextLine()
    {
        if (dialogueQueue.Count <= 0)
        {
            CloseDialogue();
            return;
        }
        var line = dialogueQueue.Dequeue();
        speakerText.text = line.speaker;
        contentText.text = line.content;
    }

    // 关闭对话框
    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }
}
