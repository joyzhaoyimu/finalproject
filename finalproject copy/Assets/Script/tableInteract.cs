using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Yarn.Unity;

public class tableInteract : InteractableObject
{
    public DialogueRunner dialogueRunner;
    public int itemCount = 0;
    public List<GameObject> items = new List<GameObject>();
    bool hasTriggeredDialogue = false;
    public GameObject displayC; // 拖拽 DisplayC Canvas 进来
      public GameObject displayD; // 新增提示D

    [Header("Patient Models")]
    public GameObject patientBefore; // 拖进来的旧模型
    public GameObject patientAfter;  // 拖进来的新模型

    public LucyBarController lucyBarController;  // 👈 你的血条控制器脚本


    public void SetItemStatus(int id, bool status)
    {
        Debug.Log($"id:{id}, status:{status}");
        items[id].SetActive(status);
        itemCount++;
        if (lucyBarController != null)
        {
            lucyBarController.DecreaseEmotion();  // 👈 调用扣血函数
        }
    }

    public override void Oninteract()
    {
        if (itemCount < items.Count) return;
         Debug.Log("✅ Item count reached 4, starting AfterCleanUp dialogue!");

        // 隐藏提示Canvas
        if (displayC != null){
            displayC.SetActive(false);
        }

        // 切换病人模型
        if (patientBefore != null)
        {
        patientBefore.SetActive(false);
        }

        if (patientAfter != null)
        {
        patientAfter.SetActive(true);
        }

        // 触发新对话
        dialogueRunner.StartDialogue("AfterCleanUp");
        hasTriggeredDialogue = true;
        hasInteracted = true;
        Debug.Log("Interacted with the table!");
        GameManager.Instance.OnInteractionComplete();
    }

    void Update()
    {
        if (hasInteracted) return;
        if (!hasTriggeredDialogue && itemCount >= 4){
            Oninteract();
        }
    }

}
