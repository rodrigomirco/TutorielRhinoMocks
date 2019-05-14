namespace TutorielRhinoMocks.Animaux
{
    public class Lion : Animal, ILion
    {
        public bool AFaim { get; set; }

        public bool Attaquer(IRhinoceros rhinoceros)
        {
            return rhinoceros.SeFaireAttaquer();
        }
    }
}
