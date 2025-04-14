using Unity.VisualScripting;
using UnityEngine;

public class DoorInteract : InteractableObject
{
    public GameObject door; // The door GameObject

    public override void Oninteract()
    {
        // Implement the interaction logic here
        door.SetActive(true);
        this.gameObject.SetActive(false);
        GameManager.Instance.OnInteractionComplete();
    }

}
