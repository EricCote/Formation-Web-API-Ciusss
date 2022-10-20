using Ciusss.Models;

namespace Ciusss.Services
{
    public class Participants : List<Participant>, IParticipants
    {
        public Participants()
        {
            AddRange(new List<Participant> {
                new Participant { Id=1, Nom="Jeffrey", Prenom="James", Salaire=100000},
                new Participant { Id = 2, Nom = "Bellemare", Prenom = "Vincent",Salaire=110000 },
                new Participant { Id=3, Nom="Nappert", Prenom="Frantz", Salaire=120000},
                new Participant { Id=4, Nom="Baillargeon", Prenom="Phillipe", Salaire=130000}
            });
        }
    }
}
