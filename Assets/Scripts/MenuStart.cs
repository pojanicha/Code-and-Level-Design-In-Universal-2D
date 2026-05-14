using UnityEngine;

public class MenuStart : MonoBehaviour
{
    [SerializeField] private GameObject audio; 


    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SimpleFade.Instance.LoadScene(1);

    }


    public void OpenAudio()
    {
        audio.SetActive(true);
    }

    public void CloseAudio()
    {
        audio.SetActive(false);
    }


}
