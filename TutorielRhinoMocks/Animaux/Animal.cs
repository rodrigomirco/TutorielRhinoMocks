using System;

namespace TutorielRhinoMocks.Animaux
{
    public class Animal : IAnimal
    {
        public bool SeFaireAttaquer()
        {
            return EstMort();
        }

        private bool EstMort()
        {
            return new Random().Next(100) % 2 == 0;
        }

    }
}
