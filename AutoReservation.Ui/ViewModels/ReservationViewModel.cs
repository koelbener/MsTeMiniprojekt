using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Ui.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly List<ReservationDto> reservationenOriginal = new List<ReservationDto>();
        private ObservableCollection<ReservationDto> reservationen;
        private ObservableCollection<KundeDto> kunden;
        private ObservableCollection<AutoDto> autos;

        public ObservableCollection<ReservationDto> Reservationen
        {
            get
            {
                if (reservationen == null)
                {
                    reservationen = new ObservableCollection<ReservationDto>();
                }
                return reservationen;
            }
        }

        private ReservationDto selectedReservation;
        public ReservationDto SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                if (selectedReservation != value)
                {
                    selectedReservation = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<KundeDto> Kunden
        {
            get
            {
                if (kunden == null)
                {
                    kunden = new ObservableCollection<KundeDto>();
                }
                return kunden;
            }
        }

        public ObservableCollection<AutoDto> Autos
        {
            get
            {
                if (autos == null)
                {
                    autos = new ObservableCollection<AutoDto>();
                }
                return autos;
            }
        }

        #region Load-Command

        private RelayCommand loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(
                        param => Load(),
                        param => CanLoad()
                    );
                }
                return loadCommand;
            }
        }

        protected override void Load()
        {
            Reservationen.Clear();
            reservationenOriginal.Clear();
            foreach (ReservationDto reservation in Service.Reservationen())
            {
                Reservationen.Add(reservation);
                reservationenOriginal.Add((ReservationDto)reservation.Clone());
            }
            selectedReservation = Reservationen.FirstOrDefault();

            Kunden.Clear();
            foreach (KundeDto kunde in Service.Kunden())
            {
                Kunden.Add(kunde);
            }

            Autos.Clear();
            foreach (AutoDto auto in Service.Autos())
            {
                Autos.Add(auto);
            }


        }

        private bool CanLoad()
        {
            return Service != null;
        }

        #endregion

        #region Save-Command

        private RelayCommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(
                        param => SaveData(),
                        param => CanSaveData()
                    );
                }
                return saveCommand;
            }
        }

        private void SaveData()
        {
            foreach (ReservationDto res in Reservationen)
            {
                if (res.ReservationNr == default(int))
                {
                    Service.InsertReservation(res);
                }
                else
                {
                    ReservationDto original = reservationenOriginal.FirstOrDefault(ao => ao.ReservationNr == res.ReservationNr);
                    Service.UpdateReservation(res, original);
                }
            }
            Load();
        }

        private bool CanSaveData()
        {
            if (Service == null)
            {
                return false;
            }

            StringBuilder errorText = new StringBuilder();
            foreach (ReservationDto res in Reservationen)
            {
                string error = res.Validate();
                if (!string.IsNullOrEmpty(error))
                {
                    errorText.AppendLine(res.ToString());
                    errorText.AppendLine(error);
                }
            }

            ErrorText = errorText.ToString();
            return string.IsNullOrEmpty(ErrorText);
        }

        #endregion

        #region New-Command

        private RelayCommand newCommand;

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(
                        param => New(),
                        param => CanNew()
                    );
                }
                return newCommand;
            }
        }

        private void New()
        {
            Reservationen.Add(new ReservationDto());
        }

        private bool CanNew()
        {
            return Service != null;
        }

        #endregion

        #region Delete-Command

        private RelayCommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(
                        param => Delete(),
                        param => CanDelete()
                    );
                }
                return deleteCommand;
            }
        }

        private void Delete()
        {
            Service.DeleteReservation(selectedReservation);
            Load();
        }

        private bool CanDelete()
        {
            return
                selectedReservation != null &&
                selectedReservation.ReservationNr != default(int) &&
                Service != null;
        }

        #endregion

    }
}