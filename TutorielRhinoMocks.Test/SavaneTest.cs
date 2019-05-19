using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
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
            _savane.SoignerAnimal(_animalQuelconque);

            //Assert
            _veterinaire.AssertWasCalled(x => x.Soigner(_animalQuelconque));
        }

        [TestMethod]
        public void SoignerUnAnimal_QuandAnimalEstGueri_AlorsRetourneVrai()
        {
            //Arrange
            _veterinaire.Stub(x => x.Soigner(_animalQuelconque)).Return(true);

            //Act
            bool retour = _savane.SoignerAnimal(_animalQuelconque);

            //Assert
            retour.Should().BeTrue();
        }

        [TestMethod]
        public void SoignerUnAnimal_QuandAnimalNEstPasGueri_AlorsRetourneFaux()
        {
            //Arrange
            _veterinaire.Stub(x => x.Soigner(_animalQuelconque)).Return(false);

            //Act
            bool reponse = _savane.SoignerAnimal(_animalQuelconque);

            //Assert
            reponse.Should().BeFalse();
        }
        #endregion

        #region CeremonieDeFormationDeNouveauVeterinaire
        [TestMethod]
        public void CeremonieDeFormationDeNouveauVeterinaire_EnToutTemps_AlorsFormerNouveauVeterinaireEstAppeleAvecUnVeterinairePasEncoreFormeEnParametre()
        {
            //Arrange

            //Act
            _savane.CeremonieDeFormationDeNouveauVeterinaire();

            //Assert
            _veterinaire.AssertWasCalled(x => x.FormerNouveauVeterinaire(Arg<Veterinaire>.Matches(y => y.PasEncoreForme == true)));
        }
        #endregion

        #region ChasserUnAnimal
        [TestMethod]
        public void ChasserUnAnimal_EnToutTemps_AlorsLocaliserAnimalEstAppelleAvecListeDeTousLesAnimaux()
        {
            //Arrange
            List<IAnimal> tousLesAnimaux = new List<IAnimal>
            {
                _lion,
                _rhinoceros
            };


            //Act
            _savane.ChasserUnAnimal();

            //Assert
            _localisateurDAnimaux.AssertWasCalled(x => x.LocaliserAnimal(Arg<List<IAnimal>>.List.ContainsAll(tousLesAnimaux)));
        }

        [TestMethod]
        public void ChasserUnAnimal_EnToutTemps_AlorsAttaquerEstAppelleAvecAnimalLocalise()
        {
            //Arrange
            _localisateurDAnimaux.Stub(x => x.LocaliserAnimal(Arg<List<IAnimal>>.Is.Anything)).Return(_animalQuelconque);

            //Act
            _savane.ChasserUnAnimal();

            //Assert
            _chasseur.AssertWasCalled(x => x.Attaquer(_animalQuelconque));
        }

        [TestMethod]
        public void ChasserUnAnimal_QuandAnimalEstMort_AlorsRetourneAnimalChasse()
        {
            //Arrange
            _localisateurDAnimaux.Stub(x => x.LocaliserAnimal(Arg<List<IAnimal>>.Is.Anything)).Return(_animalQuelconque);
            _chasseur.Stub(x => x.Attaquer(_animalQuelconque)).Return(true);

            //Act
            IAnimal animal = _savane.ChasserUnAnimal();

            //Assert
            animal.Should().Be(_animalQuelconque);
        }

        [TestMethod]
        public void ChasserUnAnimal_QuandAnimalNEstPasMort_AlorsRetourneNull()
        {
            //Arrange
            _localisateurDAnimaux.Stub(x => x.LocaliserAnimal(Arg<List<IAnimal>>.Is.Anything)).Return(_animalQuelconque);
            _chasseur.Stub(x => x.Attaquer(_animalQuelconque)).Return(false);

            //Act
            IAnimal animal = _savane.ChasserUnAnimal();

            //Assert
            animal.Should().BeNull();
        }
        #endregion

        #region MangerUnRhinoceros
        [TestMethod]
        public void MangerUnRhinoceros_QuandLionNAPasFaim_AlorsAttaquerNEstPasAppelle()
        {
            //Arrange
            _lion.AFaim = false;

            //Act
            _savane.MangerUnRhinoceros();

            //Assert
            _lion.AssertWasNotCalled(x => x.Attaquer(Arg<IRhinoceros>.Is.Anything));
        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionNAPasFaim_AlorsRetourneNull()
        {
            //Arrange
            _lion.AFaim = false;

            //Act
            IRhinoceros rhinoceros = _savane.MangerUnRhinoceros();

            //Assert
            rhinoceros.Should().BeNull();
        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionAFaim_AlorsLionAttaqueRhinoceros()
        {
            //Arrange
            _lion.AFaim = true;

            //Act
            _savane.MangerUnRhinoceros();

            //Assert
            _lion.AssertWasCalled(x => x.Attaquer(_rhinoceros));
        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionAFaimEtRhinocerosEstMort_AlorsRetourneRhinoceros()
        {
            //Arrange
            _lion.AFaim = true;
            _lion.Stub(x => x.Attaquer(_rhinoceros)).Return(true);

            //Act
            IRhinoceros rhinoceros = _savane.MangerUnRhinoceros();

            //Assert
            rhinoceros.Should().Be(_rhinoceros);
        }

        [TestMethod]
        public void MangerUnRhinoceros_QuandLionAFaimEtRhinocerosNEstPasMort_AlorsRetourneNull()
        {
            //Arrange
            _lion.AFaim = true;
            _lion.Stub(x => x.Attaquer(_rhinoceros)).Return(false);

            //Act
            IRhinoceros rhinoceros = _savane.MangerUnRhinoceros();

            //Assert
            rhinoceros.Should().BeNull();
        }
        #endregion
    }
}
