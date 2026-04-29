using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.AddItem(); // เพิ่มไอเท็มให้กับผู้เล่น
            }

            Destroy(gameObject); // ทำลายไอเท็มหลังจากเก็บ

        }
    }
}