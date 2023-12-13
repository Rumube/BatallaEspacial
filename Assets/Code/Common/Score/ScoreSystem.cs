namespace Common.Score
{
    public interface ScoreSystem
    {
        int[] GetBestScores();
        void Reset();
        int CurrentScore { get;}
    }
}