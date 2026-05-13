using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    public int requiredItemCount; // จำนวนไอเท็มที่ต้องการเพื่อเปิดประตู
    private Collider2D col;
    [SerializeField] private float moveSpeed = 0.5f; // ความเร็วในการเคลื่อนที่ของประตู
    private bool isOpen;
    [SerializeField]private float targetY;


    private void Awake()
    {
        
            col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isOpen)
        {
            if (transform.position.y > targetY)
            {
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;

            }

            else
            {
                isOpen = false; // หยุดการเคลื่อนที่เมื่อประตูถึงตำแหน่งเป้าหมาย
            }

        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        // ตรวจสอบว่าผู้เล่นมีไอเท็มครบตามที่ต้องการหรือไม่
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null && playerController.UseItems(requiredItemCount))
        {
            isOpen = true;
            col.enabled = false; // ปิดการชนเพื่อให้ผู้เล่นผ่านประตูได้
           
        }



        else
        {
            Debug.Log("Player does not have enough items to open the door.");


        }

    }







}

