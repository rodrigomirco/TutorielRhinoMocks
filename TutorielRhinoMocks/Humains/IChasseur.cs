using TutorielRhinoMocks.Animaux;

namespace TutorielRhinoMocks.Humains
{
    public interface IChasseur : IHumain
    {
        bool Attaquer(IAnimal animal);
    }
}
