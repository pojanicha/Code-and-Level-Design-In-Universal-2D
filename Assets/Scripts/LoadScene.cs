using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public int levelIndexToLoad;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SimpleFade.Instance.LoadScene(levelIndexToLoad);


            if (SimpleFade.Instance != null)
            {
                SimpleFade.Instance.LoadScene(levelIndexToLoad);
            }
            else
            {
                Debug.LogError("SimpleFade Instance is NULL!");
            }







        }
    }


}
