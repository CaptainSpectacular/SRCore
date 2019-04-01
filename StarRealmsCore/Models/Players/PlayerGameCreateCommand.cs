using StarRealmsCore.Data;

namespace StarRealmsCore.Models.Players
{
    public class PlayerGameCreateCommand
    {
        public int GameId { get; set; }
        public int ChallengerId { get; set; }
        public int TargetId { get; set; }
        public string ChallengerName { get; set; }
        public string TargetName { get; set; }

        public PlayerGame ToPlayerGameChallenger()
        {
            return new PlayerGame
            {
                PlayerId = ChallengerId,
                GameId = GameId
            };
        }

        public PlayerGame ToPlayerGameTarget()
        {
            return new PlayerGame
            {
                PlayerId = TargetId,
                GameId = GameId
            };
        }
    }
}
