using UnityEngine;
using Yarn.Unity;

public class EndingDisplay2 : MonoBehaviour
{
    [SerializeField] private GameObject endingDisplay1;
    [SerializeField] private DialogueRunner dialogueRunner;


    public void ShowPromptAfterEnding()
    {

        if (dialogueRunner.CurrentNodeName == "Ending2")
        {
            endingDisplay1.SetActive(true);
            Debug.Log("✅ EndingDisplay1 Canvas triggered at end of Ending1");
        }

    }
}
