using UnityEngine;
using Yarn.Unity;

public class Ending : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] GameObject ending1;

    public void PlayEnding()
    {
        if(dialogueRunner.CurrentNodeName == "Curtain1")
        {
            ending1.SetActive(true);
            Debug.Log("Play Ending1");
        }
        else if(dialogueRunner.CurrentNodeName == "Curtain2")
        {
            Debug.Log("Play Ending2");
        }
    }
}
