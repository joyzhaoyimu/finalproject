using UnityEngine;
using Yarn.Unity;

public class BedInteraction : InteractableObject
{
    public DialogueRunner dialogueRunner;
    public GameObject promptToHide;  // 👉 在 Inspector 中拖入 prompt UI
    public LucyBarController lucyBarController;  // 👈 你的血条控制器脚本


    public override void Oninteract()
    {
        hasInteracted = true;

        Debug.Log("Interacted with the bed!");

        if (promptToHide != null)
        {
            promptToHide.SetActive(false);  // 👈 互动后隐藏提示
        }

        if (lucyBarController != null)
    {
        lucyBarController.DecreaseEmotion();  // 👈 调用扣血函数
    }

        dialogueRunner.StartDialogue("WakeUp1");
        GameManager.Instance.OnInteractionComplete();
    }
}


