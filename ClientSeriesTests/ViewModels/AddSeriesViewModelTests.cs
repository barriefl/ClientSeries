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
    public class AddSeriesViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void SeriesViewModelTest()
        {
            // Arrange.
            AddSeriesViewModel series = new AddSeriesViewModel();

            // Assert.
            Assert.IsNotNull(series);
        }

        /// <summary>
        /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionAddSerieTest()
        {
            // Arrange.
            // Création d'un objet de type SeriesViewModel.
            AddSeriesViewModel series = new AddSeriesViewModel();
            // Properties de SerieToAdd.
            series.SerieToAdd.Titre = "Nicolas, a Magical Girl";
            series.SerieToAdd.Resume = "Nicolas est une femme.";
            series.SerieToAdd.Nbsaisons = 1;
            series.SerieToAdd.Nbepisodes = 6;
            series.SerieToAdd.Anneecreation = 2025;
            series.SerieToAdd.Network = "YouTube";

            // Création d'un objet Serie.
            Serie serie = new Serie
            {
                Titre = "Nicolas, a Magical Girl",
                Resume = "Nicolas est une femme.",
                Nbsaisons = 1,
                Nbepisodes = 6,
                Anneecreation = 2025,
                Network = "YouTube"
            };

            // Act.
            // Appel de la méthode ActionAddSerie.
            series.ActionAddSerie();

            // Assert.
            // Assertion : Serie est égal à l'objet espérée serie.
            Assert.AreEqual(serie, series.SerieToAdd, "La série attendue n'est pas la même que celle ajoutée.");
        }
    }
}