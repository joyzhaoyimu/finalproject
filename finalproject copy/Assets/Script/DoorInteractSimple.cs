using UnityEngine;

public class DoorInteractSimple : MonoBehaviour
{
    public GameObject door;             // 门对象
    public GameObject promptToHide;     // 提示 UI（Canvas 或 Image）
    public GameObject promptToShow;     // 另一个提示 UI（Canvas 或 Image）
    public GameObject lucyBarUI; 

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 开门
            door.SetActive(true);

            // 隐藏触发器自身（例如互动提示或碰撞框）
            this.gameObject.SetActive(false);

            // 隐藏提示 Canvas
            if (promptToHide != null)
            {
                promptToHide.SetActive(false);
            }
             if (promptToShow != null)
            {
                promptToShow.SetActive(true);
            }

             if (lucyBarUI != null)
            {
                lucyBarUI.SetActive(true);
            }

            // 取消自己（防止重复触发）
            this.gameObject.SetActive(false);
        }
    }




}
