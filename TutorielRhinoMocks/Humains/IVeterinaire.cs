using System.Collections.Generic;
using TutorielRhinoMocks.Animaux;

namespace TutorielRhinoMocks.Humains
{
    public interface IVeterinaire : IHumain
    {
        bool PasEncoreForme { get; set; }
        List<IRhinoceros> AmenerDesRhinoceros();
        List<ILion> AmenerDesLions();
        void FormerNouveauVeterinaire(IVeterinaire nouveauVeterinaire);
        bool Soigner(IAnimal animal);
    }
}
