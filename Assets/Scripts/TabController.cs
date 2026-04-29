using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] page;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateTab(0); 
    }

    public void ActivateTab(int tabNo)
    {
        for (int i = 0; i < page.Length; i++)
        {
            
            page[i].SetActive(false);
            tabImages[i].color = Color.gray;
        }
        page[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;

    }

}
