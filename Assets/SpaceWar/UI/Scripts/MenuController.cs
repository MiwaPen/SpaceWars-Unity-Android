using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button startBTN;
    [SerializeField] private Button exitBTN;
    [SerializeField] private TMP_Text scoreLabel;
    private SoundController soundController;

    private void Awake()
    {
        soundController = FindObjectOfType<SoundController>();
    }

    public void MenuBTNSBindings(GameManager gameManager)
    {
        startBTN.onClick.AddListener(gameManager.StartGame);
        startBTN.onClick.AddListener(soundController.ClickPlay);
        exitBTN.onClick.AddListener(gameManager.GameExit);
        exitBTN.onClick.AddListener(soundController.ClickPlay);

    }
    public void SetScorelabelValue(int score)
    {
        scoreLabel.text = score.ToString();
    }

}
