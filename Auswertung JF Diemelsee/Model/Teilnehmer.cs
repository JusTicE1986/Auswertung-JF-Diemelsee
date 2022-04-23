using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auswertung_JF_Diemelsee.Model
{
    public class Teilnehmer : Base.BindableBase
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set {SetProperty<string> (ref _firstName , value); }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set {SetProperty<string> (ref _lastName , value); }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { SetProperty<DateTime?>(ref _birthDate, value); }
        }
        private int _errorsQuestionaire;
        public int ErrorsQuestionaire
        {
            get { return _errorsQuestionaire; }
            set { SetProperty<int>(ref _errorsQuestionaire , value); }
        }
        private DateTime? _ageInYears;
        public DateTime? AgeInYears
        {
            get { return _ageInYears; }
            set { SetProperty<DateTime?>(ref _ageInYears , value); }
        }
        public Teilnehmer() { }
        public Teilnehmer(string firstname, string lastname, DateTime? date) 
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.BirthDate = date;
        }


    }
}
