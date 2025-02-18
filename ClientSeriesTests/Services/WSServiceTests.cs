using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSeries.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSeries.Models;

namespace ClientSeries.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        private WSService service;

        [TestInitialize]
        public void InitialisationDesTests()
        {
            // Rajouter les initialisations exécutées avant chaque test.
            service = new WSService("http://localhost:5239/api/");
        }

        [TestMethod()]
        public void GetSeriesAsyncTest_Ok()
        {
            // Arrange.
            List<Serie> listeSeriesAttendues = new List<Serie>();
            listeSeriesAttendues.Add(new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)"));
            listeSeriesAttendues.Add(new Serie(2, "James May's 20th Century", "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now.", 1, 6, 2007, "BBC Two"));
            listeSeriesAttendues.Add(new Serie(3, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO"));

            // Act. 
            var resultat = service.GetSeriesAsync("series");
            List<Serie> listeSeriesRecuperees = resultat.Result.Where(s => s.Serieid <= 3).OrderBy(s => s.Serieid).ToList();

            // Assert.
            CollectionAssert.AreEqual(listeSeriesAttendues, listeSeriesRecuperees, "La liste de séries attendues n'est pas la même que la liste de séries récupérées.");
        }

        [TestMethod()]
        public void GetSerieAsyncTest_Ok()
        {
            // Arrange.
            Serie serieAttendue = new Serie(3, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO");

            // Act. 
            var resultat = service.GetSerieAsync("series", 3);
            Serie serieRecuperee = resultat.Result;

            // Assert.
            Assert.AreEqual(serieAttendue, serieRecuperee, "La série attendue n'est pas la même que la série récupérée.");
        }

        [TestMethod()]
        public void GetSerieAsyncTest_NonOk()
        {
            // Arrange.
            Serie serieAttendue = new Serie(3, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO");

            // Act. 
            var resultat = service.GetSerieAsync("series", 2);
            Serie serieRecuperee = resultat.Result;

            // Assert.
            Assert.AreNotEqual(serieAttendue, serieRecuperee, "La série attendue est la même que la série récupérée.");
        }

        [TestMethod()]
        public void PutSerieAsyncTest_Ok()
        {
            // Arrange.
            Serie serie = new Serie(3, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO");

            // Act. 
            var resultat = service.PutSerieAsync("series", serie);

            // Assert.
            Assert.IsTrue(resultat.Result, "La série n'a pas bien été modifiée.");
        }

        [TestMethod()]
        public void PutSerieAsyncTest_NonOk()
        {
            // Arrange.
            Serie serie = new Serie(999, "True Blood", "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...", 7, 81, 2008, "HBO");

            // Act. 
            var resultat = service.PutSerieAsync("series", serie);

            // Assert.
            Assert.IsFalse(resultat.Result, "La série n'a pas bien été modifiée.");
        }

        [TestMethod()]
        public void PostSerieAsyncTest_Ok()
        {
            // Arrange.
            Serie serie = new Serie
            {
                Titre = "Nicolas",
                Resume = "Nicolas ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...",
                Nbsaisons = 7,
                Nbepisodes = 81,
                Anneecreation = 2008,
                Network = "HBO"
            };

            // Act. 
            var resultat = service.PostSerieAsync("series", serie);

            // Assert.
            Assert.IsTrue(resultat.Result, "La série n'a pas bien été ajoutée.");
        }

        [TestMethod()]
        public void PostSerieAsyncTest_NonOk()
        {
            // Arrange.
            Serie serie = new Serie
            {
                Serieid = 1,
                Titre = "Nicolas",
                Resume = "Nicolas ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme...",
                Nbsaisons = 7,
                Nbepisodes = 81,
                Anneecreation = 2008,
                Network = "HBO"
            };

            // Act. 
            var resultat = service.PostSerieAsync("series", serie);

            // Assert.
            Assert.IsFalse(resultat.Result, "La série n'a pas bien été ajoutée.");
        }
    }
}