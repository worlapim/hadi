
namespace hadi
{
    internal static class DisplayEvents
    {
        public static void MoveToPosition(Player player, int position)
        {
            DisplayConsole.Print($"{player} se pusunul z políčka {player.Position} na políčko {position}");
        }

        public static void MoveToPositionOutOfBounds(Player player, int position)
        {
            DisplayConsole.Print($"{player} se pokusil posunout na políčko {position}, které neexistuje. Zůstává stát na políčku {player.Position}.");
        }

        public static void MoveToOtherPlayerPosition(Player playerMoved, Player playerOriginal)
        {
            DisplayConsole.Print($"{playerMoved} přišel na políčko kde je {playerOriginal} a posunul ho zpět");
        }

        public static void MoveToShortcutPosition(Player playerMoved, Shortcut shortcut)
        {
            DisplayConsole.Print($"Na políčku {playerMoved.Position} je {shortcut}");
        }

        public static void Roll(bool again, bool autoplay)
        {
            if (again)
            {
                DisplayConsole.WaitInput("hážeš znovu", autoplay);
            }
            DisplayConsole.WaitInput("hážeš", autoplay);
        }

        public static void Rolled(int roll)
        {
            DisplayConsole.Print($"padlo {roll}");
        }

        public static void Victory(Player player)
        {
            DisplayConsole.Print($"{player} vyhrál");
        }

        public static int GetPlayerCount()
        {
            return DisplayConsole.ReadIntFromConsole("zadejte počet hráčů:");
        }

        public static void TurnStart(Player player)
        {
            DisplayConsole.Print($"hraje {player}");
        }
    }
}
