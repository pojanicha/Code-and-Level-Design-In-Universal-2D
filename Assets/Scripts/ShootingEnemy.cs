using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; 


    private float timer;
    private GameObject player;

    [SerializeField] private float distanceAmout;
    [SerializeField] private float Fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      

        float distance = Vector2.Distance(transform.position, player.transform.position);


        if (distance <= distanceAmout) // Check if player is within 7 units
        {
            timer += Time.deltaTime;

            if (timer >= Fire) // Fire every 1.5 seconds
            {
                timer = 0f; // Reset the timer
                Shoot();
            }

        }

        

    }

    void Shoot()
            {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }



}
