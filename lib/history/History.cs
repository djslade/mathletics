using mathletics.lib.match;

namespace mathletics.lib.history
{
    public class History
    {
        private List<Match> _matches = [];

        public List<Match> Matches { get => _matches; }

        public void AddMatch(Match match)
        {
            _matches.Insert(0, match);
        }
    }
}