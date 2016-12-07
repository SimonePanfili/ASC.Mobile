using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC.Mobile.Common.Models;

namespace ASC.Mobile.Services.Demo
{
    public class CalendarioCorsiService : ICalendarioCorsiService
    {
        public ObservableCollection<Corso> Corsi { get; } = new ObservableCollection<Corso>();

        public bool IsLoaded => true;

        public Task LoadAsync() => Task.FromResult<object>(null);

        public CalendarioCorsiService()
        {
            Corsi.Add(new Corso
            {
                IdCorso = 1243,
                Codice = "10854",
                Descrizione = "OPERATORE PER IL BENESSERE FISICO E NATUROPATA",
                Qualifica = "NATUROPATA",
                Organizzatore = "RC COMITATO PROVINCIALE REGGIO CALABRIA",
                Disciplina = "BIONATURA",
                DataInizio = DateTime.Now.AddDays(-1),
                DataFine = DateTime.Now.AddDays(1),
                Address = new Address
                {
                    At = "Reggio Calabria",
                    Street = "croce valanidi",
                    ZipCode = "89100",
                    Province = "RC",
                    City = "Reggo Calabria"
                }
            });

            Corsi.Add(new Corso
            {
                IdCorso = 4325,
                Codice = "10185",
                Descrizione = "CORSO TECNICO ADDESTRATORE CINOFILO",
                Qualifica = "ISTRUTTORE",
                Organizzatore = "ROVIGO ROVIGO C/O C.P. A.S.C. ROVIGO",
                Disciplina = "ATTIVITA' CINOFILE",
                DataInizio = DateTime.Now,
                DataFine = DateTime.Now.AddDays(2),
                Address = new Address
                {
                    At = "Campo Cinofilo",
                    Street = "Strada del Casale",
                    ZipCode = "36100",
                    Province = "VI",
                    City = "Vicenza"
                }
            });

            Corsi.Add(new Corso
            {
                IdCorso = 1245,
                Codice = "10306",
                Descrizione = "DIFESA PERSONALE - SDS CONCEPT",
                Qualifica = "ALLENATORE - METODO S.D.S. CONCEPT",
                Organizzatore = "ROVIGO ROVIGO C/O C.P. A.S.C. ROVIGO",
                Disciplina = "DIFESA PERSONALE",
                DataInizio = DateTime.Now.AddDays(-2),
                DataFine = DateTime.Now,
                Address = new Address
                {
                    At = "Accademia Fu Dou Shin Dolo",
                    Street = "Via Argine Sinistro 87",
                    ZipCode = "30031",
                    Province = "VE",
                    City = "Dolo"
                }
            });

            Corsi.Add(new Corso
            {
                IdCorso = 9076,
                Codice = "10406",
                Descrizione = "INSEGNANTE YOGA",
                Qualifica = "INSEGNANTE",
                Organizzatore = "RC COMITATO PROVINCIALE REGGIO CALABRIA",
                Disciplina = "YOGA",
                DataInizio = DateTime.Now,
                DataFine = DateTime.Now.AddDays(2),
                Address = new Address
                {
                    At = "Progetto Natural-Mente",
                    Street = "VIA SIOTTO PINTOR 2/M",
                    ZipCode = "07100",
                    Province = "SS",
                    City = "Sassari"
                }
            });

            Corsi.Add(new Corso
            {
                IdCorso = 8768,
                Codice = "10423",
                Descrizione = "CINTURE NERE DI KARATE",
                Qualifica = "CINTURA NERA I DAN",
                Organizzatore = "ROVIGO ROVIGO C/O C.P. A.S.C. ROVIGO",
                Disciplina = "ARTI MARZIALI - KARATE",
                DataInizio = DateTime.Now.AddDays(-1),
                DataFine = DateTime.Now.AddDays(2),
                Address = new Address
                {
                    At = "Accademia Fu Dou Shin Dolo",
                    Street = "Via Argine Sinistro 87",
                    ZipCode = "30031",
                    Province = "VE",
                    City = "Dolo"
                }
            });
        }
    }
}
