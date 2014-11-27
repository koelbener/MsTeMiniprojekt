using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase
    {

        private int basistarif;
        private int id;
        private String marke;
        private int tagestarif;
        private AutoKlasse klasse;

        [DataMember]
        public AutoKlasse AutoKlasse
        {
            get { return klasse; }
            set
            {
                if (!klasse.Equals(value))
                {
                    klasse = value;
                    RaisePropertyChanged();
                }
            }
        }


        [DataMember]
        public int Basistarif
        {
            get { return basistarif; }
            set
            {
                if (!basistarif.Equals(value))
                {
                    basistarif = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public String Marke
        {
            get { return marke; }
            set
            {
                if (!marke.Equals(value))
                {
                    this.marke = value;
                    RaisePropertyChanged();
                }
            }
        }


        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if (!id.Equals(value))
                {
                    id = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public int Tagestarif
        {
            get { return tagestarif; }
            set
            {
                if (!tagestarif.Equals(value))
                {
                    tagestarif = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && basistarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new AutoDto
            {
                Id = Id,
                Marke = Marke,
                Tagestarif = Tagestarif,
                AutoKlasse = AutoKlasse,
                Basistarif = Basistarif
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                Id,
                Marke,
                Tagestarif,
                Basistarif,
                AutoKlasse);
        }

    }
}
