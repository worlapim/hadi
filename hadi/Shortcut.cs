
namespace hadi
{
    internal class Shortcut
    {
        public enum ShortcutType
        {
            Ladder,
            Snake,
        }
        public int Entrance { get; set; }
        public int Exit { get; set; }
        public ShortcutType Type { get; set; }

        public Shortcut(int entrance, int exit, ShortcutType type)
        {
            Entrance = entrance;
            Exit = exit;
            Type = type;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case ShortcutType.Ladder:
                    return $"žebřík z {Entrance} do {Exit}";
                case ShortcutType.Snake:
                    return $"had z {Entrance} do {Exit}";
                default:
                    return $"zkratka z {Entrance} do {Exit}";
            }
        }
    }
}
