using System.Collections.Generic;
using TutorielRhinoMocks.Animaux;

namespace TutorielRhinoMocks.Services
{
    public interface ILocalisateurDAnimaux
    {
        IAnimal LocaliserAnimal(List<IAnimal> animaux);
    }
}
