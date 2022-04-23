using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Auswertung_JF_Diemelsee.Commands;
using Auswertung_JF_Diemelsee.Model;

namespace Auswertung_JF_Diemelsee.ViewModel
{
    public class ViewModelMainWindow : Base.BindableBase
    {
        #region Properties
        private ObservableCollection<Team> _teams;  

        public ObservableCollection<Team> Teams
        {
            get { return _teams; }
            set {SetProperty<ObservableCollection<Team>> (ref _teams , value); }
        }
        private ObservableCollection<Teilnehmer> _listOfTeamMembers;

        public ObservableCollection<Teilnehmer> ListOfTeamMembers
        {
            get { return _listOfTeamMembers; }
            set {SetProperty<ObservableCollection<Teilnehmer>> (ref _listOfTeamMembers , value); }
        }
        #endregion

        #region Fields
        //Platz für die Fields von den ICommands
        public Teilnehmer NewMember { get; set; } = new Teilnehmer();
        public Team NewTeam { get; set; } = new Team();

        public ICommand AddNewTeamMember { get; private set; }
        public ICommand AddNewTeam { get; private set; }

        #endregion

        #region Konstruktor
        public ViewModelMainWindow()
        {
            // initialisierung der Listen
            _teams = new ObservableCollection<Team>();
            _listOfTeamMembers = new ObservableCollection<Teilnehmer>();

            AddNewTeamMember = new RelayCommand(AddNewTeamMemberExecute, AddNewTeamMemberCanExecute);
            AddNewTeam = new RelayCommand(AddNewTeamExecute, AddNewTeamCanExecute);
        }

        #endregion

        #region Methoden
        private bool AddNewTeamMemberCanExecute(object sender)
        {
            return true;
        }
        private void AddNewTeamMemberExecute(object sender)
        {
            if (NewMember == null) return;
            if (_listOfTeamMembers.Count >= 9)
            {
                MessageBox.Show("Zu viele Teilnehmer hinzugefügt", "Fehler bei Eingabe",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            if (NewMember.FirstName == null)
            {
                MessageBox.Show("Keinen Vornamen eingegeben", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            if (NewMember.LastName == null)
            {
                MessageBox.Show("Keinen Nachnamen eingegeben", "Fehler bei der Eingabe",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            if (NewMember.BirthDate == null)
            {
                MessageBox.Show("Kein Geburtsdatum eingegeben", "Fehler bei der Eingabe",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            var _member = new Teilnehmer(NewMember.FirstName, NewMember.LastName, NewMember.BirthDate);
            _listOfTeamMembers.Add(_member);
        }

        private bool AddNewTeamCanExecute(object sender) { return true; }
        private void AddNewTeamExecute(object sender)
        {
            var _team = new Team(NewTeam.TeamName,NewTeam.ListOfTeilnehmer, NewTeam.TeamCategory, NewTeam.IsOutofCompetition);
            _teams.Add(_team);
        }
        #endregion




    }
}
