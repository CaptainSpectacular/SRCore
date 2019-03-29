using StarRealmsCore.Data;

namespace StarRealmsCore.Models.Players
{
    public class PlayerGameCreateCommand
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public PlayerGame ToPlayerGame()
        {
            return new PlayerGame
            {
                PlayerId = PlayerId,
                GameId = GameId
            };
        }
    }
}
