using UnityEngine;
using Yarn.Unity;

public class DisplayC : MonoBehaviour
{
    [SerializeField] private GameObject displayC;
    [SerializeField] private DialogueRunner dialogueRunner;


    public void ShowPromptAfterWakeup()
    {

        if (dialogueRunner.CurrentNodeName == "WakeUp1")
        {
            displayC.SetActive(true);
            Debug.Log("✅ DisplayC Canvas triggered at end of WakeUp1");
        }

    }
}
