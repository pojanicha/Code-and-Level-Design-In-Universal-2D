using UnityEngine;

public class MenuStart : MonoBehaviour
{


    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SimpleFade.Instance.LoadScene(1);
    }
}
