using TutorielRhinoMocks.Animaux;

namespace TutorielRhinoMocks.Humains
{
    public class Chasseur : IChasseur
    {
        public bool Attaquer(IAnimal animal)
        {
            return animal.SeFaireAttaquer();
        }
    }
}
