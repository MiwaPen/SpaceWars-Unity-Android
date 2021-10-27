using UnityEngine;

public class ReposBase : MonoBehaviour
{
    private PlayerScoreRepos playerScoreRepos = new PlayerScoreRepos();
    public PlayerScoreRepos PlayerScoreRepos { get => playerScoreRepos; }

    public void Awake()
    {
        playerScoreRepos.Initialize();
    }
}
