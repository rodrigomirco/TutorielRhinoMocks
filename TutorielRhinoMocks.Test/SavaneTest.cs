using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TutorielRhinoMocks.Animaux;
using TutorielRhinoMocks.Humains;
using TutorielRhinoMocks.Services;

namespace TutorielRhinoMocks.Test
{
    [TestClass]
    public class SavaneTest
    {
        private IAnimal _animalQuelconque;
        private ILion _lion;
        private IRhinoceros _rhinoceros;
        private IChasseur _chasseur;
        private IVeterinaire _veterinaire;
        private ILocalisateurDAnimaux _localisateurDAnimaux;

        private Savane _savane;

        private readonly Fixture _fixture = new Fixture();

        [TestInitialize]
        public void Initialize()
        {
            _lion = MockRepository.GenerateStub<ILion>();
            _rhinoceros = MockRepository.GenerateStub<IRhinoceros>();
            _chasseur = MockRepository.GenerateStub<IChasseur>();
            _veterinaire = MockRepository.GenerateStub<IVeterinaire>();
            _localisateurDAnimaux = MockRepository.GenerateStub<ILocalisateurDAnimaux>();

            _savane = new Savane(_lion, _rhinoceros, _chasseur, _veterinaire, _localisateurDAnimaux);

            _animalQuelconque = _fixture.Create<Animal>();
        }

        #region SoignerUnAnimal
        [TestMethod]
        public void SoignerUnAnimal_EnToutTemps_AlorsAppelleSoignerAvecAnimalPasseEnParametre()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void SoignerUnAnimal_QuandAnimalEstGueri_AlorsRetourneVrai()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void SoignerUnAnimal_QuandAnimalNEstPasGueri_AlorsRetourneFaux()
        {
            //Arrange

            //Act

            //Assert

        }
        #endregion

        #region CeremonieDeFormationDeNouveauVeterinaire
        [TestMethod]
        public void CeremonieDeFormationDeNouveauVeterinaire_EnToutTemps_AlorsAlorsFormerNouveauVeterinaireEstAppeleAvecUnVeterinairePasEncoreFormeEnParametre()
        {
            //Arrange

            //Act

            //Assert

        }
        #endregion

        #region ChasserUnAnimal
        [TestMethod]
        public void ChasserUnAnimal_EnToutTemps_AlorsLocaliserAnimalEstAppelleAvecListeDeTousLesAnimaux()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void ChasserUnAnimal_EnToutTemps_AlorsAttaquerEstAppelleAvecAnimalLocalise()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void ChasserUnAnimal_QuandAnimalEstMort_AlorsRetourneAnimalChasse()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void ChasserUnAnimal_QuandAnimalNEstPasMort_AlorsRetourneNull()
        {
            //Arrange

            //Act

            //Assert

        }
        #endregion

        #region MangerUnRhinoceros
        [TestMethod]
        public void MangerUnRhinoceros_QuandLionNAPasFaim_AlorsAttaquerNEstPasAppelle()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionNAPasFaim_AlorsRetourneNull()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionAFaim_AlorsLionAttaqueRhinoceros()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionAFaimEtRhinocerosEstMort_AlorsRetourneRhinoceros()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionAFaimEtRhinocerosNEstPasMort_AlorsRetourneNull()
        {
            //Arrange

            //Act

            //Assert

        }
        #endregion
    }
}
