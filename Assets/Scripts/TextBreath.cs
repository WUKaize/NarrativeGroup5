using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextBreath : MonoBehaviour
{
    [Header("呼吸速度")]
    public float breathSpeed = 1.8f;
    [Header("最小透明度")]
    [Range(0f, 1f)] public float minAlpha = 0.3f;
    [Header("最大透明度")]
    [Range(0f, 1f)] public float maxAlpha = 1f;

    private TextMeshProUGUI _tmp;

    void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Sin 平滑往复，天然柔和呼吸
        float t = (Mathf.Sin(Time.time * breathSpeed) + 1f) / 2f;
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);

        Color c = _tmp.color;
        c.a = alpha;
        _tmp.color = c;
    }
}