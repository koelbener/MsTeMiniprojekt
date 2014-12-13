using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class KundeDto : DtoBase
    {
        private DateTime geburtsdatum;
        private int id;
        private String nachname;
        private String vorname;

        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if (id == null || !id.Equals(value))
                {
                    this.id = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public String Nachname
        {
            get { return nachname; }
            set
            {
                if (nachname == null || !nachname.Equals(value))
                {
                    this.nachname = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public String Vorname
        {
            get { return vorname; }
            set
            {
                if (vorname == null || !vorname.Equals(value))
                {
                    this.vorname = value;
                    RaisePropertyChanged();
                }
            }
        }

        [DataMember]
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set
            {
                if (geburtsdatum == null || !geburtsdatum.Equals(geburtsdatum))
                {
                    this.geburtsdatum = value;
                    RaisePropertyChanged();
                }
            }
        }


        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Nachname))
            {
                error.AppendLine("- Nachname ist nicht gesetzt.");
            }
            if (string.IsNullOrEmpty(Vorname))
            {
                error.AppendLine("- Vorname ist nicht gesetzt.");
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                error.AppendLine("- Geburtsdatum ist nicht gesetzt.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new KundeDto
            {
                id = id,
                nachname = nachname,
                vorname = vorname,
                geburtsdatum = geburtsdatum
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}",
                id,
                nachname,
                vorname,
                geburtsdatum);
        }

    }
}
