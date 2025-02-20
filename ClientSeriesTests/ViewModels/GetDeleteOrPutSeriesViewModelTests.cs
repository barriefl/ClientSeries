using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSeries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSeries.Models;

namespace ClientSeries.ViewModels.Tests
{
    [TestClass()]
    public class GetDeleteOrPutSeriesViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void GetDeleteOrPutSeriesViewModelTest()
        {
            // Arrange.
            GetDeleteOrPutSeriesViewModel viewModel = new GetDeleteOrPutSeriesViewModel();

            // Assert.
            Assert.IsNotNull(viewModel);
        }

        /// <summary>
        /// Test ActionGetSerieTest OK
        /// </summary>
        [TestMethod()]
        public void ActionGetSerieTest_OK()
        {
            // Arrange.
            GetDeleteOrPutSeriesViewModel viewModel = new GetDeleteOrPutSeriesViewModel();

            // Properties de NumSerie.
            viewModel.Serie.Serieid = 1;

            // Création d'un objet Serie.
            Serie serieAttendue = new Serie
            {
                Serieid = 1,
                Titre = "Scrubs",
                Resume = "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",
                Nbsaisons = 9,
                Nbepisodes = 184,
                Anneecreation = 2001,
                Network = "ABC (US)"
            };

            // Act.
            viewModel.ActionGetSerie();
            Thread.Sleep(1000);

            // Assert.
            Assert.AreEqual(serieAttendue, viewModel.Serie, "La devise ne correspond pas à la devise attendue.");
        }

        /// <summary>
        /// Test ActionPutSerieTest OK
        /// </summary>
        // Le test crash à cause de la méthode asynchrone MessageAsync().
        [TestMethod()]
        public void ActionPutSerieTest_OK()
        {
            // Arrange.
            GetDeleteOrPutSeriesViewModel viewModel = new GetDeleteOrPutSeriesViewModel();

            // Properties de NumSerie.
            viewModel.Serie.Serieid = 10;

            // Création d'un objet Serie.
            Serie serieAttendue = new Serie
            {
                Serieid = 10,
                Titre = "Heroe",
                Resume = "Partout dans le monde, un certain nombre d'individus en apparence ordinaires se révèlent dotés de capacités hors du commun : la régénération cellulaire, la téléportation, la télépathie... Ils ne savent pas ce qui leur arrive, ni les répercussions que tout cela pourrait avoir. Ils ignorent encore qu'ils font partie d'une évolution qui va changer le monde à jamais !",
                Nbsaisons = 4,
                Nbepisodes = 78,
                Anneecreation = 2006,
                Network = "NBC"
            };

            // Act.
            // On Get la série pour avoir les valeurs.
            viewModel.ActionGetSerie();
            Thread.Sleep(1000);

            // On modifie le titre et après on Put.
            viewModel.Serie.Titre = "Heroe";
            viewModel.ActionPutSerie();
            Thread.Sleep(1000);

            // Assert.
            Assert.AreEqual(serieAttendue, viewModel.Serie, "La devise ne correspond pas à la devise attendue.");
        }
    }
}