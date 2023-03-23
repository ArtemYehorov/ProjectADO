using ProjectADO.Context;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectADO.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Teams _selectedTeam1;
        public Teams SelectedTeam1
        {
            get => _selectedTeam1;
            set
            {
                if (_selectedTeam1 != value)
                {
                    _selectedTeam1 = value;
                    RefreshPlayers1();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTeam1)));
                }
            }
        }

        private Teams _selectedTeam2;
        public Teams SelectedTeam2
        {
            get => _selectedTeam2;
            set
            {
                if (_selectedTeam2 != value)
                {
                    _selectedTeam2 = value;
                    RefreshPlayers2();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTeam2)));
                }
            }
        }

        public ObservableCollection<Teams> Teams { get; set; }
        public ObservableCollection<Player> Players { get; set; }

        public ObservableCollection<Player> FilteredPlayers1 { get; set; }
        public ObservableCollection<Player> FilteredPlayers2 { get; set; }

        public ObservableCollection<Country> Country { get; set; }
        public ObservableCollection<Context.Сoach> Сoachs { get; set; }

        public MainWindowViewModel()
        {
            Teams = new ObservableCollection<Teams>();
            Players = new ObservableCollection<Player>();
            FilteredPlayers1 = new ObservableCollection<Player>();
            FilteredPlayers2 = new ObservableCollection<Player>();
            Country = new ObservableCollection<Country>();
            Сoachs = new ObservableCollection<Context.Сoach>();
            LoadData();
        }

        private void LoadData()
        {
            Country.Clear();
            Players.Clear();
            Teams.Clear();
            Сoachs.Clear();

            using SqlConnection connection = new(App.ConectionString);
            try
            {
                connection.Open();

                #region Country

                Country = new();
                using SqlCommand cmd = new("SELECT Id, Name FROM countries", connection);
                {
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Country.Add(new()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                        });
                    }
                }
                #endregion

                #region Players
                Players = new();
                using SqlCommand cmd2 = new("SELECT id, name, surname, patronymic, age, team_id FROM players", connection);
                {
                    using var reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        Players.Add(new()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Patronymic = reader.GetString(3),
                            Age = reader.GetInt32(4),
                            IdTeam = reader.GetInt32(5)
                        });
                    }
                }
                #endregion

                #region Teams
                Teams = new();
                using SqlCommand cmd3 = new("SELECT Id, name, coach_id, country_id FROM teams", connection);
                {
                    using var reader = cmd3.ExecuteReader();
                    while (reader.Read())
                    {
                        Teams.Add(new()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            IdCoach = reader.GetInt32(2),
                            IdCountry = reader.GetInt32(3),
                        });
                    }
                }
                #endregion

                #region Сoach
                Сoachs = new();
                using SqlCommand cmd4 = new("SELECT id, name, surname, age, country_id FROM coaches", connection);
                {
                    using var reader = cmd4.ExecuteReader();
                    while (reader.Read())
                    {
                        Сoachs.Add(new()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Age = reader.GetInt32(3),
                            IdCountry = reader.GetInt32(4)
                        });
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshPlayers1()
        {
            FilteredPlayers1.Clear();
            if (SelectedTeam1 != null)
            {
                foreach (var player in Players)
                {
                    if (player.IdTeam == SelectedTeam1.Id)
                    {
                        FilteredPlayers1.Add(player);
                    }
                }
            }
        }

        private void RefreshPlayers2()
        {
            FilteredPlayers2.Clear();
            if (SelectedTeam2 != null)
            {
                foreach (var player in Players)
                {
                    if (player.IdTeam == SelectedTeam2.Id)
                    {
                        FilteredPlayers2.Add(player);
                    }
                }
            }
        }
    }
}