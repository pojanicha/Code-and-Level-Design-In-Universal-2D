using UnityEngine;
using TMPro;

public class UIItems : MonoBehaviour
{
    [SerializeField]private PlayerController playerController;
    [SerializeField] private Door door;
    private TextMeshProUGUI textUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = playerController.currentItems + "/" + door.requiredItemCount;
        
    }
}
