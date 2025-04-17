using Unity.VisualScripting;
using UnityEngine;

public class DoorInteractSimple : MonoBehaviour
{
    public GameObject door; // The door GameObject

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Implement the interaction logic here
            door.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
