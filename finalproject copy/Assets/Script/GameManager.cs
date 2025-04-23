using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[System.Serializable]
public struct InteractableSequence
{
    public List<InteractableObject> interactables;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Dialogue")]
    public bool isDoingDialogue = false;
    public DialogueRunner dialogueRunner;

    [Header("Scene Elements")]
    public GameObject curtain;
    public GameObject bed;
    public GameObject door;
    public GameObject background;
    public GameObject table;
    public GameObject cookies;
    public GameObject cup;
    public GameObject laptop;
    public GameObject ipad;

    [Header("Sprites")]
    public Sprite spritecurtain;
    public Sprite spritebed;
    public Sprite spritedoor;
    public Sprite spriteBackground;
    public Sprite spriteTable;

    public Sprite spriteCookies;
    public Sprite spriteCup;
    public Sprite spriteLaptop;
    public Sprite spriteIpad;

    [Header("Prompt UI")]
    public GameObject promptCanvas; // 拖入提示图像或Canvas

    [Header("Interactable Sequences")]
    public List<InteractableSequence> interactables = new List<InteractableSequence>();
    [SerializeField]
    private int currentIndex = 0;

    private void Awake()
    {
        // Singleton 初始化
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 初始化当前互动序列
        if (interactables.Count > 0)
        {
            foreach (InteractableObject interactable in interactables[currentIndex].interactables)
            {
                interactable.interactionEnabled = true;
            }
        }

        // 开始对话
        dialogueRunner.StartDialogue("Start");
    }

    // 外部控制对话状态（禁用移动、交互）
    public void ChangeDialogueStatus(bool status)
    {
        isDoingDialogue = status;
    }

    // 当互动完成，切换下一阶段
    public void OnInteractionComplete()
    {
        if (currentIndex == interactables.Count - 1)
        {
            // 触发最终效果，例如拉开窗帘、显示床铺等
            background.GetComponent<SpriteRenderer>().sprite = spriteBackground;
            curtain.GetComponent<SpriteRenderer>().sprite = spritecurtain;
            bed.GetComponent<SpriteRenderer>().sprite = spritebed;
            door.GetComponent<SpriteRenderer>().sprite = spritedoor;
            table.GetComponent<SpriteRenderer>().sprite = spriteTable;
            cookies.GetComponent<SpriteRenderer>().sprite = spriteCookies;
            cup.GetComponent<SpriteRenderer>().sprite = spriteCup;
            laptop.GetComponent<SpriteRenderer>().sprite = spriteLaptop;
            ipad.GetComponent<SpriteRenderer>().sprite = spriteIpad;
        }

        // 禁用当前交互物体
        foreach (InteractableObject interactable in interactables[currentIndex].interactables)
        {
            interactable.interactionEnabled = false;
        }

        currentIndex++;

        if (currentIndex <= interactables.Count - 1)
        {
            foreach (InteractableObject interactable in interactables[currentIndex].interactables)
            {
                interactable.interactionEnabled = true;
            }
        }
    }


}
