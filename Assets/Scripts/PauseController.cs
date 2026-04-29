using UnityEngine;

public class PauseController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool isPaused { get; private set; } = false;

    public static void SetPause(bool pause)
    {
        isPaused = pause;
    }

}