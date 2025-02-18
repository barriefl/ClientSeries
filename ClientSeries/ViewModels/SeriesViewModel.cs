using ClientSeries.Models;
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
    public class SeriesViewModel : ObservableObject
    {
        public IRelayCommand BtnAddSerie { get; }

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

        private Serie serieToAdd;

        public SeriesViewModel() 
        {
            BtnAddSerie = new RelayCommand(ActionAddSerie);
            SerieToAdd = new Serie();
        }

        private void ActionAddSerie()
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
            ContentDialogResult result = await errorMessage.ShowAsync();
        }
    }
}
