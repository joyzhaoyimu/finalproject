using UnityEngine;
using UnityEngine.UI;

public class LucyBarController : MonoBehaviour
{
    [Header("UI Component")]
    public Slider emotionSlider; // 绑定Slider，而不是Image

    [Range(0f, 1f)]
    public float currentValue = 0.45f;

    public float decreasePerPress = 0.05f;

    void Start()
    {
        UpdateBar();
    }

    // ✅ 外部调用的血条减少方法（例如 tableInteract.cs 调用）
    public void DecreaseEmotion()
    {
        currentValue -= decreasePerPress;
        currentValue = Mathf.Clamp01(currentValue); // 限制在 0~1 之间
        UpdateBar();
    }

    void UpdateBar()
    {
        if (emotionSlider != null)
        {
            emotionSlider.value = currentValue;
        }
    }
}
