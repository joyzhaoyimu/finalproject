using UnityEngine;
using Yarn.Unity;

public class CurtainInteract : InteractableObject
{
    public DialogueRunner dialogueRunner;
    public override void Oninteract()
    {
        hasInteracted = true;
        // Implement the interaction logic here
        Debug.Log("Interacted with the bed!");
        dialogueRunner.StartDialogue("Curtain");
        GameManager.Instance.OnInteractionComplete();
    }
}
