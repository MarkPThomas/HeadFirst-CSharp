using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballRoster.Model;

namespace BasketballRoster.ViewModel
{
    class RosterViewModel
    {
        public string TeamName { get; set; }
        public ObservableCollection<PlayerViewModel> Starters {get; set; }
        public ObservableCollection<PlayerViewModel> Bench { get; set; }

        private Roster _roster;

        public RosterViewModel(Roster roster)
        {
            _roster = roster;

            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();

            TeamName = roster.TeamName;
            UpdateRosters();
        }

        private void UpdateRosters()
        {
            // Uses LINQ queries to extract the starting and bench players
            // And update the Starters & Bench properties
            var startingPlayers = from player in _roster.Players
                                  where player.Starter
                                  select player;

            foreach (Player player in startingPlayers)
            {
                Starters.Add(new PlayerViewModel(player.Name, player.Number));
            }

            var benchPlayers = from player in _roster.Players
                               where player.Starter == false
                               select player;

            foreach (Player player in benchPlayers)
            {
                Bench.Add(new PlayerViewModel(player.Name, player.Number));
            }
        }
    }
}
