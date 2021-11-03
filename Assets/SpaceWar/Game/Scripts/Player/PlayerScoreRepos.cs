using UnityEngine;

public class PlayerScoreRepos 
{
    public int maxScore { get; set; }
    const string maxScoreKey = "maxScoreKey";

    public void Initialize()
    {
        maxScore = PlayerPrefs.GetInt(maxScoreKey);
    }

    public void SaveScore(int newScore)
    {
        if (newScore > maxScore)
        {
            PlayerPrefs.SetInt(maxScoreKey, newScore);
            UpdateScoreInfo();
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt(maxScoreKey, 0);
    }

    private void UpdateScoreInfo()
    {
        maxScore = PlayerPrefs.GetInt(maxScoreKey);
    }
}
