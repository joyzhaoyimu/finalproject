using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;


public class EndingDisplay2 : MonoBehaviour
{
    [SerializeField] private GameObject endingDisplay2;
    [SerializeField] private DialogueRunner dialogueRunner;


    public void ShowPromptAfterEnding()
    {


        if (dialogueRunner.CurrentNodeName == "Ending2")
        {
            endingDisplay2.SetActive(true);
            Debug.Log("✅ EndingDisplay1 Canvas triggered at end of Ending1");
        }


    }
}
