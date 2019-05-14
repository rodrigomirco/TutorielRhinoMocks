namespace TutorielRhinoMocks.Animaux
{
    public interface ILion : IAnimal
    {
        bool AFaim { get; set; }
        bool Attaquer(IRhinoceros rhinoceros);
    }
}
