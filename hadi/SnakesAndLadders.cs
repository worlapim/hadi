

namespace hadi
{
    public class SnakesAndLadders
    {
        private Random Random { get; } = new Random();
        public const int StartPosition = 1;
        public const int FinishPosition = 100;
        private List<Shortcut> Shortcuts { get; set; } = new List<Shortcut>();
        private List<Player> Players { get; set; } = new List<Player>();
        public bool AutoPlay { get; set; } = false;

        public void Play()
        {
            Start();
            PlayTurns();
        }

        private void PlayTurns()
        {
            while (true)
            {
                foreach (Player player in Players)
                {
                    PlayerTurn(player);
                    foreach (Player playerToCheck in Players)
                    {
                        if (playerToCheck != null)
                        {
                            if (playerToCheck.Position == FinishPosition)
                            {
                                DisplayEvents.Victory(player);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void Start()
        {
            int playerCounts = DisplayEvents.GetPlayerCount();
            CreatePlayers(playerCounts);
            CreateShortcuts();
        }

        private void CreatePlayers(int playerCount)
        {
            Players.Clear();
            for (int i = 1; i <= playerCount; i++)
            {
                Players.Add(new Player(i));
            }
        }

        private void CreateShortcuts()
        {
            Shortcuts.Clear();
            Shortcuts.Add(new Shortcut(2, 38, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(7, 14, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(8, 31, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(15, 26, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(21, 42, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(28, 84, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(36, 44, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(51, 67, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(71, 91, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(78, 98, Shortcut.ShortcutType.Ladder));
            Shortcuts.Add(new Shortcut(87, 94, Shortcut.ShortcutType.Ladder));

            Shortcuts.Add(new Shortcut(16, 6, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(46, 25, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(49, 11, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(62, 19, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(64, 60, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(74, 53, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(89, 68, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(92, 88, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(95, 75, Shortcut.ShortcutType.Snake));
            Shortcuts.Add(new Shortcut(99, 80, Shortcut.ShortcutType.Snake));
        }

        private void PlayerTurn(Player player)
        {
            DisplayEvents.TurnStart(player);
            int roll = RollADie();
            Move(player, roll);
        }

        private void Move(Player player, int roll)
        {
            int destination = player.Position + roll;
            MoveTo(player, destination);
        }

        private void MoveTo(Player player, int destination)
        {
            if (destination > FinishPosition || destination < StartPosition)
            {
                DisplayEvents.MoveToPositionOutOfBounds(player, destination);
                return;
            }
            List<Player> pushedPlayers = GetPlayersOnPosition(destination);
            DisplayEvents.MoveToPosition(player, destination);
            player.Position = destination;
            foreach (Player pushedPlayer in pushedPlayers)
            {
                DisplayEvents.MoveToOtherPlayerPosition(player, pushedPlayer);
                Move(pushedPlayer, -1);
            }
            Shortcut? shortcut = GetShortcutOnPosition(destination);
            if (shortcut != null)
            {
                DisplayEvents.MoveToShortcutPosition(player, shortcut);
                MoveTo(player, shortcut.Exit);
            }
        }

        private List<Player> GetPlayersOnPosition(int position)
        {
            return Players.Where(p => p.Position == position).ToList();
        }

        private Shortcut? GetShortcutOnPosition(int position)
        {
            List<Shortcut> shortcuts = Shortcuts.Where(p => p.Entrance == position).ToList();
            return shortcuts.FirstOrDefault();
        }

        private int RollADie() 
        {
            int result = 0;
            DisplayEvents.Roll(false, AutoPlay);
            while (true) 
            {
                int roll = Random.Next(1, 7);
                DisplayEvents.Rolled(roll);
                result += roll;
                if (roll != 6)
                {
                    break;
                }
                DisplayEvents.Roll(true, AutoPlay);
            }
            return result;
        }

       
    }
}
