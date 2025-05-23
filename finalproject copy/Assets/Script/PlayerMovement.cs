using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public Sprite leftSprite;
    public Sprite rightSprite;

    [SerializeField]
    private int currentDir = 1; // 1: right, -1: left
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public IInteractable interactable;

    public LineView lineView;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        // 获取输入
        movement.x = Input.GetAxisRaw("Horizontal"); // A / D or Left / Right
        movement.y = Input.GetAxisRaw("Vertical");   // W / S or Up / Down
    
        int tempDir = currentDir;
        if(movement.x < 0){
            tempDir = -1;
        } else if (movement.x > 0){
            tempDir = 1;
        }
        // animator.SetFloat("movement", movement.x);
        if(tempDir != currentDir){
            currentDir = tempDir;
            if(currentDir == 1){
                GetComponent<SpriteRenderer>().sprite = rightSprite;
            } else {
                GetComponent<SpriteRenderer>().sprite = leftSprite;
            }
        }
                
        if(GameManager.Instance.isDoingDialogue){
            return;
        }

        // 检测交互
        if(Input.GetKey(KeyCode.E)){
            // Debug.Log("Press E");
            // if(interactable is ItemInteract){
            // Debug.Log((interactable as ItemInteract).itemID);
            // }
            if(interactable != null && interactable.CanInteract()){
                Debug.Log("Interacting with: Bed");
                interactable.Oninteract();
            }
        }


        if(Input.GetKey(KeyCode.Space))
        {
            lineView.UserRequestedViewAdvancement();
        }


    }

    void FixedUpdate()
    {
        // 移动角色
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Interactable")){
            interactable = other.GetComponent<IInteractable>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Interactable")){
            interactable = null;
        }
    }
}
