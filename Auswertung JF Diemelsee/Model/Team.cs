using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auswertung_JF_Diemelsee.Model
{
    public class Team : Base.BindableBase
    {
        private string _teamName;
        public string TeamName
        {
            get { return _teamName; }
            set { SetProperty(ref _teamName, value); }
        }

        private ObservableCollection<Teilnehmer> _listOfTeilnehmer;
        public ObservableCollection<Teilnehmer> ListOfTeilnehmer
        {
            get { return _listOfTeilnehmer; }
            set { SetProperty(ref _listOfTeilnehmer, value); }
        }

        private string _teamCategory;
        public string TeamCategory
        {
            get { return _teamCategory; }
            set { SetProperty(ref _teamCategory, value); }
        }

        private bool _isOutofCompetition;
        public bool IsOutofCompetition
        {
            get { return _isOutofCompetition; }
            set { SetProperty(ref _isOutofCompetition, value); }
        }

        public Team() { }
        public Team(string name, ObservableCollection<Teilnehmer> teilnehmers, string category, bool outOfCompetition)
        {
            this.TeamName = name;
            this.ListOfTeilnehmer = teilnehmers;
            this.TeamCategory = category;
            this.IsOutofCompetition = outOfCompetition;
        }
    }
}
