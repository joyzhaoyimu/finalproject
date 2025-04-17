using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public struct InteractableSequence
{
   public List<InteractableObject> interactables;
}
public class GameManager : MonoBehaviour
{
    public bool isDoingDialogue = false;
    public GameObject curtain;
    public GameObject bed;
    public GameObject door;
    public GameObject background;
    public Sprite spritecurtain;
    public Sprite spritebed;
    public Sprite spritedoor;
    public Sprite spriteBackground;
    public List<InteractableSequence> interactables = new List<InteractableSequence>();
    private int currentIndex = 0;
    private static GameManager instance;
    public static GameManager Instance { 
        get {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();

                if(instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

         foreach(InteractableObject interactable in interactables[currentIndex].interactables){
            interactable.interactionEnabled = true;
        }
    }


    public void ChangeDialogueStatus(bool status){
        isDoingDialogue = status;
    }

    public void OnInteractionComplete(){
        if(currentIndex == interactables.Count - 1){
           // Handle Curtain Logic Here 
            background.GetComponent<SpriteRenderer>().sprite = spriteBackground;
            curtain.GetComponent<SpriteRenderer>().sprite = spritecurtain;
            bed.GetComponent<SpriteRenderer>().sprite = spritebed;
            door.GetComponent<SpriteRenderer>().sprite = spritedoor;

        }
        foreach(InteractableObject interactable in interactables[currentIndex].interactables){
            interactable.interactionEnabled = false;
        }
        currentIndex++;
        if(currentIndex <= interactables.Count - 1){
           foreach(InteractableObject interactable in interactables[currentIndex].interactables){
            interactable.interactionEnabled = true;
        }
        }

    }



}
