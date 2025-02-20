using ClientSeries.Models;
using ClientSeries.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.ViewModels
{
    public class GetDeleteOrPutSeriesViewModel : ObservableObject
    {
        private Serie serie;
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

        public IRelayCommand BtnGetSerie { get; }

        public IRelayCommand BtnPutSerie { get; }

        public IRelayCommand BtnDeleteSerie { get; }

        public GetDeleteOrPutSeriesViewModel()
        {
            GetDataOnLoadAsync();

            Serie = new Serie();

            BtnGetSerie = new RelayCommand(ActionGetSerie);
            BtnPutSerie = new RelayCommand(ActionPutSerie);
            BtnDeleteSerie = new RelayCommand(ActionDeleteSerie);
        }

        public async void GetDataOnLoadAsync()
        {
            service = new WSService("https://localhost:7297/api/");
            List<Serie> result = await service.GetSeriesAsync("series");
            if (result == null)
            {
                MessageAsync("API non disponible !", "Erreur");
            }
        }

        public async void ActionGetSerie()
        {
            var resultat = await service.GetSerieAsync("series", this.Serie.Serieid);

            if (resultat == null) 
            {
                MessageAsync("La série n'existe pas.", "Erreur");
            }
            else
            {
                this.Serie = new Serie
                {
                    Serieid = resultat.Serieid,
                    Titre = resultat.Titre,
                    Resume = resultat.Resume,
                    Nbsaisons = resultat.Nbsaisons,
                    Nbepisodes = resultat.Nbepisodes,
                    Anneecreation = resultat.Anneecreation,
                    Network = resultat.Network
                };

                MessageAsync("Série trouvée !", "Notification");
            }    
        }

        public async void ActionPutSerie() 
        {
            if (string.IsNullOrEmpty(this.Serie.Titre) || string.IsNullOrEmpty(this.Serie.Resume) || this.Serie.Nbsaisons == 0 || this.Serie.Nbepisodes == 0 || this.Serie.Anneecreation == 0 || string.IsNullOrEmpty(this.Serie.Network))
            {
                MessageAsync("Veuillez rechercher une série.", "Erreur");
            }
            else
            {
                bool updated = await service.PutSerieAsync("series", this.Serie);

                if (updated)
                {
                    var result = await service.GetSerieAsync("series", this.Serie.Serieid);

                    if (result != null)
                    {
                        this.Serie = result;

                        MessageAsync("Série modifiée avec succès !", "Notification");
                    }
                    else
                    {
                        MessageAsync("Erreur lors de la récupération de la série.", "Erreur");
                    }
                }
                else
                {
                    MessageAsync("Erreur lors de la mise à jour de la série.", "Erreur");
                }
            }
        }

        public async void ActionDeleteSerie()
        {
            if (string.IsNullOrEmpty(this.Serie.Titre) || string.IsNullOrEmpty(this.Serie.Resume) || this.Serie.Nbsaisons == 0 || this.Serie.Nbepisodes == 0 || this.Serie.Anneecreation == 0 || string.IsNullOrEmpty(this.Serie.Network))
            {
                MessageAsync("Veuillez rechercher une série.", "Erreur");
            }
            else
            {
                await service.DeleteSerieAsync("series", this.Serie.Serieid);

                this.Serie = new Serie { };

                MessageAsync("Série supprimée avec succès !", "Notification");
            }
        }

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
