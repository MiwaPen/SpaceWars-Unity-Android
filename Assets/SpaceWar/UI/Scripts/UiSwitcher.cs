using UnityEngine;

public class UiSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private GameObject MenuUI;
    private void Start()
    {
        GameplayUI.SetActive(false);
        MenuUI.SetActive(false);
    }

    public void ShowMenuUI()
    {
        GameplayUI.SetActive(false);
        MenuUI.SetActive(true);
    }
    public void ShowGameplayUI()
    {
        GameplayUI.SetActive(true);
        MenuUI.SetActive(false);
    }
}
