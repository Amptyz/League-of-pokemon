using LOP.Entities;
using LOP.Cards;

namespace LOP.GameSystem
{
    public class GameInfoSystem
    {
        private static GameInfoSystem instance;
        public static GameInfoSystem Instance
        {
            get { return instance ??= new GameInfoSystem(); }
        }
        public GameTeam Blue;
        public GameTeam Red;
        private GameInfoSystem()
        {
            Blue = new GameTeam();
            Red = new GameTeam();
        }
    }
    public class GameTeam
    {
        public Entity Player { get; private set; }
        public Entity[] PickedPokemons;
        public Card[] PickedCards;
        public Card[] CardsInHand;
        public List<Card> CardsInPile;
        public GameTeam()
        {
            Player = new Player();
            PickedPokemons = new Entity[4];
            PickedCards = new Card[4];
            CardsInHand = new Card[4];
            CardsInPile = new List<Card>();
        }
        public void InitializeBeforeGameStart()
        {
            List<Card> temp = new List<Card>();
            for (int i = 0; i < 4; ++i)
            {
                temp.Add(PickedCards[i]);
            }
            for (int i = 0; i < 4; ++i)
            {
                temp.Add(PickedPokemons[i].SkillCard);
            }
            Random rand = new Random();
            for (int i = 0; i < 8; ++i)
            {
                int idx = rand.Next(temp.Count);
                CardsInPile.Add(temp[idx]);
                temp.RemoveAt(idx);
            }
            for (int i = 0; i < 4; ++i)
            {
                GetCard();
            }
        }
        public void GetCard()
        {
            for (int i = 0; i < 4; ++i)
                if (CardsInHand[i] == null)
                {
                    CardsInHand[i] = CardsInPile[0];
                    CardsInPile.RemoveAt(0);
                }
        }
    }
}
