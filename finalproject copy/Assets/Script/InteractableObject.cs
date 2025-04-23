using UnityEngine;
using UnityEngine.Pool;

public interface IInteractable
{
    string InteractionID { get; }
    bool CanInteract();
    void Oninteract();
}
public abstract class InteractableObject : MonoBehaviour, IInteractable
{

    public string interactionID;
    public bool hasInteracted = false;
    public bool interactionEnabled = false;
    public string InteractionID => interactionID;

    public virtual bool CanInteract(){
        return interactionEnabled && !hasInteracted;
    }

    public abstract void Oninteract();

    public Transform GetTransform(){
        return transform;
    }
}
