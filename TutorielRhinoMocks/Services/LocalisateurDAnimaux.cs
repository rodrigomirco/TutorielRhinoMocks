using System;
using System.Collections.Generic;
using TutorielRhinoMocks.Animaux;

namespace TutorielRhinoMocks.Services
{
    public class LocalisateurDAnimaux : ILocalisateurDAnimaux
    {
        public IAnimal LocaliserAnimal(List<IAnimal> animaux)
        {
            Random random = new Random();
            IAnimal animalLocalise = animaux[random.Next(animaux.Count)];
            return animalLocalise;
        }
    }
}
