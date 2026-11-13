using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    /// <summary>
    /// 对话文本文件
    /// </summary>
    public TextAsset dialogDataFile;
    /// <summary>
    /// 左侧角色图像
    /// </summary>
    public Image spriteLeft;
    /// <summary>
    /// 右侧角色图像
    /// </summary>
    public Image spriteRight;
    /// <summary>
    /// 角色名字文本
    /// </summary>
    public TMP_Text nameText;
    /// <summary>
    /// 对话内容文本
    /// </summary>
    public TMP_Text dialogText;
    /// <summary>
    /// 角色图片列表
    /// </summary>
    public List<Image> images = new List<Image>();
    /// <summary>
    /// 角色名字对应图片的字典
    /// </summary>
    Dictionary<string, Image> imageDic = new Dictionary<string, Image>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText("cc", "hi");
    }

    public void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }
}
