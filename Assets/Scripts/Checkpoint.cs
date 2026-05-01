using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Collider2D trigger;

    public Sprite normalSprite;
    public Sprite activelSprite;

    private SpriteRenderer sr;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RespawnController.Instance.respawnPoint = transform;
            sr.sprite = activelSprite;
            trigger.enabled = false;
        }
    }

}
