using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private int requiredItemCount; // จำนวนไอเท็มที่ต้องการเพื่อเปิดประตู
    private Collider2D col;

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
            col = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        // ตรวจสอบว่าผู้เล่นมีไอเท็มครบตามที่ต้องการหรือไม่
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null && playerController.currentItems >= requiredItemCount)
        {
           col.enabled = false; // ปิดการชนเพื่อให้ผู้เล่นผ่านประตูได้
        }



        else
        {
            Debug.Log("Player does not have enough items to open the door.");


        }

    }





    /*[ContextMenu("Open")]
    public void Open()
    {

        _animator.SetTrigger("Open");

    }
    */







}

