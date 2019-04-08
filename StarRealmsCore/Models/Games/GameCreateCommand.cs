using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Data;
using StarRealmsCore.Models.Decks;

namespace StarRealmsCore.Models.Games
{
    public class GameCreateCommand
    {
        public int Id { get; set; }
        public int PlayerTurn { get; set; }
        public int ChallengerId { get; set; }
        public int TargetId { get; set; }

        public Game ToGame()
        {
            Random rnd = new Random();
            return new Game
            {
                Id = Id,
                PlayerTurn = rnd.Next(1, 3) 
            };
        }

        public PlayerGame ToPGChallenger()
        {
            return new PlayerGame
            {
                GameId = Id,
                PlayerId = ChallengerId
            };
        }

        public PlayerGame ToPGTarget()
        {
            return new PlayerGame
            {
                GameId = Id,
                PlayerId = TargetId
            };
        }

        public DeckCreateCommand ToChallengerDeck()
        {
            return new DeckCreateCommand
            {
                PlayerId = ChallengerId,
                Type = 1,
                GameId = Id 
            };
        }

        public DeckCreateCommand ToTargetDeck()
        {
            return new DeckCreateCommand
            {
                PlayerId = TargetId,
                Type = 1,
                GameId = Id 
            };
        }
    }
}
