using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;
public class tableInteract : InteractableObject
{
    public DialogueRunner dialogueRunner;
    int itemCount = 0;
    public List<GameObject> items = new List<GameObject>();

    public void SetItemStatus(int id, bool status)
    {
        items[id].SetActive(status);
        itemCount++;
    }
    public override void Oninteract()
    {
        if(itemCount < items.Count) return;
        hasInteracted = true;
        // Implement the interaction logic here
        Debug.Log("Interacted with the table!");
        dialogueRunner.StartDialogue("WakeUp1");
        GameManager.Instance.OnInteractionComplete();
    }
}
