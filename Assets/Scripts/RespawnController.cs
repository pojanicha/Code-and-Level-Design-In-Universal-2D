using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public static RespawnController Instance;

    public Transform respawnPoint;
    private void Awake()
    { 
            Instance = this;
    }


}