using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button startBTN;
    [SerializeField] private Button exitBTN;
    [SerializeField] private TMP_Text scoreLabel;

    public void MenuBTNSBindings(GameManager gameManager)
    {
        startBTN.onClick.AddListener(gameManager.StartGame);
        exitBTN.onClick.AddListener(gameManager.GameExit);
    }
    public void SetScorelabelValue(int score)
    {
        scoreLabel.text = score.ToString();
    }

}
