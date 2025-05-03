namespace mathletics.lib.stats
{
    public class Stats
    {
        private int _streak = 0;
        private int _longestStreak = 0;
        private int _totalMatches = 0;

        public int Streak { get => _streak; }
        public int LongestStreak { get => _longestStreak; }
        public int TotalMatches { get => _totalMatches; }

        public void IncreaseStreak()
        {
            _streak++;
            if (_streak > _longestStreak) _longestStreak = _streak;
        }

        public void ResetStreak()
        {
            _streak = 0;
        }

        public void IncreaseTotalMatches()
        {
            _totalMatches++;
        }
    }
}