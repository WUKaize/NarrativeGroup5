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
    public List<Sprite> images = new List<Sprite>();
    /// <summary>
    /// 角色名字对应图片的字典
    /// </summary>
    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    /// <summary>
    /// 当前对话的索引值
    /// </summary>
    public int dialogIndex;
    /// <summary>
    /// 对话文本，按行分割
    /// </summary>
    public string[] dialogRows;
    /// <summary>
    /// 对话继续按钮
    /// </summary>
    public Button nextButton;

    private void Awake()
    {
        imageDic["林书予"] = images[0];
        imageDic["林慧宜"] = images[1];
    }
    // Start is called before the first frame update
    void Start()
    {
        ReadText(dialogDataFile);
        ShowDialogRow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    public void UpdateImage(string _name, string _position)
    {
        if (_position == "左")
        {
            spriteLeft.sprite = imageDic[_name];
        }
        else if (_position == "右")
        {
            spriteRight.sprite = imageDic[_name];
        }
    }

    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
        foreach (var row in dialogRows) 
        {
            string[] cell = row.Split(',');        
        }
        Debug.Log("读取成功");
    }
    public void ShowDialogRow()
    {
        foreach (var row in dialogRows)
        {
            string[] cells = row.Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

                dialogIndex = int.Parse(cells[5]);
                break;
            }
        }
    }
    public void OnClickNext()
    {
        ShowDialogRow();
    }
}
