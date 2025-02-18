using ClientSeries.Models;
using ClientSeries.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.ViewModels
{
    public class GetDeleteOrPutSeriesViewModel : ObservableObject
    {
        public IRelayCommand BtnGetSerie { get; }
        public IRelayCommand BtnPutSerie { get; }
        public IRelayCommand BtnDeleteSerie { get; }
        private Serie serie;
        private int numSerie;
        private WSService service;

        public Serie Serie
        {
            get
            {
                return this.serie;
            }

            set
            {
                this.serie = value;
                OnPropertyChanged();
            }
        }

        public int NumSerie
        {
            get
            {
                return this.numSerie;
            }

            set
            {
                this.numSerie = value;
                OnPropertyChanged();
            }
        }

        public GetDeleteOrPutSeriesViewModel()
        {
            BtnGetSerie = new RelayCommand(ActionGetSerie);
            BtnPutSerie = new RelayCommand(ActionPutSerie);
            BtnDeleteSerie = new RelayCommand(ActionDeleteSerie);
            Serie = new Serie();
            service = new WSService("http://localhost:5239/api/");
        }

        public void ActionGetSerie()
        {
            var resultat = service.GetSerieAsync("series", this.NumSerie);

            this.Serie.Titre = resultat.Result.Titre;
        }

        public void ActionPutSerie() 
        {
            
        }

        public void ActionDeleteSerie()
        {

        }

        //public void ActionAddSerie()
        //{
        //    if ()
        //    {
        //        MessageAsync("La série a été ajoutée avec succès !", "Série ajoutée");

        //        Serie serie = new Serie
        //        {
        //            Titre = SerieToAdd.Titre,
        //            Resume = SerieToAdd.Resume,
        //            Nbsaisons = SerieToAdd.Nbsaisons,
        //            Nbepisodes = SerieToAdd.Nbepisodes,
        //            Anneecreation = SerieToAdd.Anneecreation,
        //            Network = SerieToAdd.Network
        //        };

        //        service.PostSerieAsync("series", serie);
        //    }
        //}

        private async void MessageAsync(string content, string title)
        {
            ContentDialog errorMessage = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };

            errorMessage.XamlRoot = App.MainRoot.XamlRoot;
            await errorMessage.ShowAsync();
        }
    }
}
