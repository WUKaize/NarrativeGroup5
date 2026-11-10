using UnityEngine;
using UnityEngine.SceneManagement;

// 统一管理主菜单所有按钮逻辑
public class MainMenuManager : MonoBehaviour
{
    [Header("跳转设置")]
    [SerializeField] private string gameSceneName = "Attic";

    // 点击"翻开档案"
    public void StartGame()
    {
        // 调用淡入淡出工具，跳转游戏场景
        SceneFader.Instance.LoadScene(gameSceneName);
    }

    // 点击"读取存档"（占位）
    public void LoadGame()
    {
        Debug.Log("存档功能开发中");
    }

    // 点击"设置"（占位）
    public void OpenSettings()
    {
        Debug.Log("设置面板开发中");
    }

    // 点击"退出游戏"
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
