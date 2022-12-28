using System.Collections.Generic;

namespace RockPaperScissors
{
    public class GameOption
    {
        public GameOption()
        {
            Beats = new List<int>();
            LosesTo = new List<int>();
        }
        public int Id { get; set; }
        public string Option { get; set; }
        public List<int> Beats { get; set; }
        public List<int> LosesTo { get; set; }
    }
}
