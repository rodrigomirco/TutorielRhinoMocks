using System.Collections.Generic;
using TutorielRhinoMocks.Animaux;
using TutorielRhinoMocks.Humains;
using TutorielRhinoMocks.Services;

namespace TutorielRhinoMocks
{
    public class Savane
    {
        private ILion _lion;
        private IRhinoceros _rhinoceros;
        private IChasseur _chasseur;
        private IVeterinaire _veterinaire;
        private ILocalisateurDAnimaux _localisateurDAnimaux;

        public Savane(ILion lion, IRhinoceros rhinoceros, IChasseur chasseur, IVeterinaire veterinaire, ILocalisateurDAnimaux localisateurDAnimaux)
        {
            _lion = lion;
            _rhinoceros = rhinoceros;
            _chasseur = chasseur;
            _veterinaire = veterinaire;
            _localisateurDAnimaux = localisateurDAnimaux;
        }

        public ILion Lion { get => _lion; set => _lion = value; }
        public IRhinoceros Rhinoceros { get => _rhinoceros; set => _rhinoceros = value; }
        public IChasseur Chasseur { get => _chasseur; set => _chasseur = value; }
        public IVeterinaire Veterinaire { get => _veterinaire; set => _veterinaire = value; }
        
        public bool SoignerAnimal(IAnimal animal)
        {
            bool estGueri = _veterinaire.Soigner(animal);
            return estGueri;
        }

        public void CeremonieDeFormationDeNouveauVeterinaire()
        {
            IVeterinaire nouveauVeterinaire = new Veterinaire { PasEncoreForme = true };
            _veterinaire.FormerNouveauVeterinaire(nouveauVeterinaire);
        }

        public IAnimal ChasserUnAnimal()
        {
            List<IAnimal> tousLesAnimaux = new List<IAnimal>
            {
                _lion,
                _rhinoceros
            };

            IAnimal animalChasse = _localisateurDAnimaux.LocaliserAnimal(tousLesAnimaux);

            bool animalEstMort = _chasseur.Attaquer(animalChasse);

            if (animalEstMort)
            {
                return animalChasse;
            }
            else
            {
                return null;
            }
        }

        public IRhinoceros MangerUnRhinoceros()
        {
            IRhinoceros rhinocerosDeRetour = null;
            if (_lion.AFaim)
            {
                bool rhinocerosEstMort = _lion.Attaquer(_rhinoceros);

                if(rhinocerosEstMort)
                {
                    rhinocerosDeRetour = _rhinoceros;
                }
            }
            return rhinocerosDeRetour;
        }
    }
}
