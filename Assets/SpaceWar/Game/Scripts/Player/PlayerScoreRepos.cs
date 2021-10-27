using UnityEngine;

public class PlayerScoreRepos 
{
    public int _maxScore { get; set; }
    const string maxScoreKey = "maxScoreKey";

    public void Initialize()
    {
        _maxScore = PlayerPrefs.GetInt(maxScoreKey);
    }

    public void SaveScore(int newScore)
    {
        if (newScore > _maxScore)
        {
            PlayerPrefs.SetInt(maxScoreKey,newScore);
            UpdateScoreInfo();
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt(maxScoreKey, 0);
    }

    private void UpdateScoreInfo()
    {
        _maxScore = PlayerPrefs.GetInt(maxScoreKey);
    }
}
