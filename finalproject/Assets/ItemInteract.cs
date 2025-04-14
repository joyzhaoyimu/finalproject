using UnityEngine;

public class ItemInteract : InteractableObject
{
    public int itemID;
   public tableInteract table;

    public override void Oninteract()
    {
         hasInteracted = true;
         // Implement the interaction logic here
         Debug.Log("Interacted with the item!");
         table.SetItemStatus(itemID, true);
         this.gameObject.SetActive(false);
    }

}
