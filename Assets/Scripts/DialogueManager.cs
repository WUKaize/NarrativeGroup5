using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("引用拖拽")]
    public GameObject dialoguePanel;
    public GameObject DimOverlay;
    public TMP_Text paperText;      // 羊皮纸残页文字
    public TMP_Text bottomText;     // 底部对话框文字
    public GameObject btnNext;

    [Header("打字设置")]
    public float typeSpeed = 0.05f;

    private List<(string speaker, string content)> dialogueList;
    private int currentIndex;
    private bool isTyping;
    private string fullText;

    void Start()
    {
        dialoguePanel.SetActive(false);
        if (btnNext != null) btnNext.SetActive(false);
    }

    public void StartDialogue(List<(string speaker, string content)> list)
    {
        dialogueList = list;
        currentIndex = 0;
        dialoguePanel.SetActive(true);
        ShowLine();
    }

    void ShowLine()
    {
        if (currentIndex >= dialogueList.Count)
        {
            CloseDialogue();
            return;
        }

        var line = dialogueList[currentIndex];
        string content = line.content;

        // 先清空两个文本
        paperText.text = "";
        bottomText.text = "";

        if (content.StartsWith("[PAGE]"))
        {
            fullText = content.Replace("[PAGE]", "").Trim();
            StartCoroutine(TypeText(paperText));
        }
        else if (content.StartsWith("[DIALOG]"))
        {
            fullText = content.Replace("[DIALOG]", "").Trim();
            StartCoroutine(TypeText(bottomText));
        }
        else
        {
            // 默认放到底部对话框
            fullText = content;
            StartCoroutine(TypeText(bottomText));
        }
    }

    System.Collections.IEnumerator TypeText(TMP_Text targetText)
    {
        isTyping = true;
        targetText.text = "";
        for (int i = 0; i < fullText.Length; i++)
        {
            targetText.text += fullText[i];
            yield return new WaitForSeconds(typeSpeed);
        }
        isTyping = false;
        if (btnNext != null) btnNext.SetActive(true);
    }

    // 【继续按钮绑定这个函数】
    public void OnClickNext()
    {
        if (isTyping)
        {
            // 如果还在打字，一键显示全部文字
            if (fullText.StartsWith("[PAGE]"))
                paperText.text = fullText.Replace("[PAGE]", "").Trim();
            else
                bottomText.text = fullText.Replace("[DIALOG]", "").Trim();
            isTyping = false;
            if (btnNext != null) btnNext.SetActive(true);
            return;
        }

        currentIndex++;
        if (btnNext != null) btnNext.SetActive(false);
        ShowLine();
    }

    void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        if (DimOverlay != null)
        {
            DimOverlay.SetActive(false);
        }
        paperText.text = "";
        bottomText.text = "";
    }
}
