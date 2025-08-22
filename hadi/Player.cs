
namespace hadi
{
    internal class Player
    {
        public string Name { get; set; }
        public int Position { get; set; } = 1;
        public Player(int index) 
        {
            Name = $"Hráč {index}";
        }
        public override string ToString() 
        { 
            return Name;
        }
    }
}
