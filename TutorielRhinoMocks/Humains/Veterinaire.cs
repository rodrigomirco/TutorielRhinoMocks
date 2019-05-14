using System.Collections.Generic;
using TutorielRhinoMocks.Animaux;

namespace TutorielRhinoMocks.Humains
{
    public class Veterinaire : IVeterinaire
    {
        public bool PasEncoreForme { get; set; }

        public List<ILion> AmenerDesLions()
        {
            return new List<ILion>();
        }

        public List<IRhinoceros> AmenerDesRhinoceros()
        {
            return new List<IRhinoceros>();
        }

        public void FormerNouveauVeterinaire(IVeterinaire nouveauVeterinaire)
        {
            nouveauVeterinaire.PasEncoreForme = false;
        }

        public bool Soigner(IAnimal animal)
        {
            return true;
        }
    }
}
