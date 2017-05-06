namespace Chaos.Model
{
    public class Player
    {
        private int id;

        // TODO: Każdy gracz powinien posiadać listę czarów, które może rzucić.

        public Player(string playerName, int id)
        {
            Name = playerName;
            this.id = id;
        }

        public string Name { get; set; }
    }
}