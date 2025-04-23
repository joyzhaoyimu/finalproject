using UnityEngine;
using Yarn.Unity;

public class DisplayDAfterDialogue : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private GameObject displayD;

    public void ShowPromptIfAfterCleanUp()
    {
        if (dialogueRunner.CurrentNodeName == "AfterCleanUp")
        {
            displayD.SetActive(true);
            Debug.Log("✅ DisplayC Canvas triggered at end of WakeUp1");
        }
    }
}
