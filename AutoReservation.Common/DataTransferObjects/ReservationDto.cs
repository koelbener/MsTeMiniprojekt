using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class ReservationDto : DtoBase
    {

        private DateTime von;
        private DateTime bis;
        private int reservationNr;
        private AutoDto auto;
        private KundeDto kunde;

        [DataMember]
        public KundeDto Kunde
        {
            get { return kunde; }
            set
            {
                if (kunde == null || !kunde.Equals(value))
                {
                    // TODO: is kunde.Equals valid?
                    this.kunde = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public AutoDto Auto
        {
            get { return auto; }
            set
            {
                if (auto == null || !auto.Equals(value))
                {
                    // TODO: is auto.equals valid?
                    this.auto = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public DateTime Von
        {
            get {return von; }
            set
            {
                if (von == null || !von.Equals(value))
                {
                    this.von = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public DateTime Bis
        {
            get { return bis; }
            set
            {
                if (bis == null || !bis.Equals(value))
                {
                    this.bis = value;
                    RaisePropertyChanged();

                }
            }
        }

        [DataMember]
        public int ReservationNr
        {
            get { return reservationNr; }
            set
            {
                {
                    this.reservationNr = value;
                    RaisePropertyChanged();
                }
            }
        }


        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new ReservationDto
            {
                ReservationNr = ReservationNr,
                Von = Von,
                Bis = Bis,
                Auto = (AutoDto)Auto.Clone(),
                Kunde = (KundeDto)Kunde.Clone()
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                ReservationNr,
                Von,
                Bis,
                Auto,
                Kunde);
        }

    }
}
