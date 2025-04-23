using UnityEngine;
using Yarn.Unity;

public class PromptDisplay : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private GameObject promptCanvas;

    public void ShowPromptIfStartEnds()
    {
        if (dialogueRunner.CurrentNodeName == "Start")
        {
            promptCanvas.SetActive(true);
            Debug.Log("✅ Prompt Canvas Activated at end of Start node.");
        }
    }



}
