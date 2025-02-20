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
    public class AddSeriesViewModel : ObservableObject
    {
        public IRelayCommand BtnAddSerie { get; }
        private Serie serieToAdd;
        private WSService service;

        public Serie SerieToAdd
        {
            get
            {
                return this.serieToAdd;
            }

            set
            {
                this.serieToAdd = value;
                OnPropertyChanged();
            }
        }

        
        public AddSeriesViewModel() 
        {
            BtnAddSerie = new RelayCommand(ActionAddSerie);
            SerieToAdd = new Serie();
            service = new WSService("https://localhost:7297/api/");
        }

        public void ActionAddSerie()
        {
            if (this.SerieToAdd.Titre == "" || this.SerieToAdd.Titre == null) 
            {
                MessageAsync("Le titre de la série est incorrect.", "Erreur");
            }
            else if (this.SerieToAdd.Resume == "" || this.SerieToAdd.Resume == null)
            {
                MessageAsync("Le résumé de la série est incorrect.", "Erreur");
            }
            else if (this.SerieToAdd.Nbsaisons == 0 || this.SerieToAdd.Nbsaisons == null)
            {
                MessageAsync("Le nombre de saisons de la série est incorrect.", "Erreur");
            }
            else if (this.SerieToAdd.Nbepisodes == 0 || this.SerieToAdd.Nbepisodes == null)
            {
                MessageAsync("Le nombre d'épsiodes de la série est incorrect.", "Erreur");
            }
            else if (this.SerieToAdd.Anneecreation == 0 || this.SerieToAdd.Anneecreation == null)
            {
                MessageAsync("L'année de création de la série est incorrect.", "Erreur");
            }
            else if (this.SerieToAdd.Network == "" || this.SerieToAdd.Network == null)
            {
                MessageAsync("La chaine de la série est incorrect.", "Erreur");
            }
            else
            {
                MessageAsync("La série a été ajoutée avec succès !", "Série ajoutée");

                Serie serie = new Serie
                {
                    Titre = SerieToAdd.Titre,
                    Resume = SerieToAdd.Resume,
                    Nbsaisons = SerieToAdd.Nbsaisons,
                    Nbepisodes = SerieToAdd.Nbepisodes,
                    Anneecreation = SerieToAdd.Anneecreation,
                    Network = SerieToAdd.Network
                };

                service.PostSerieAsync("series", serie);
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
