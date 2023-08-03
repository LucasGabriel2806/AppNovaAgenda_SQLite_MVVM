using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppNovaAgenda_SQLite_MVVM.ViewModel
{
    class NovoContatoViewModel : INotifyPropertyChanged
    {
        private string nome, email, telefone, observacoes;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Nome
        {
            get { return nome; }
            set { nome = value;}
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { email = value; }
        }

        public string Observacoes
        {
            get { return observacoes; }
            set { observacoes = value; }
        }

        public ICommand SalvarNovoContato
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        /**
                         * Não dei o new porque é um propriedade static
                         */
                        await App.Database.SaveContatoAsync(new Model.Contato()
                        {
                            /**
                             * Fiz a amarração entre o ViewModel e a View pra pegar
                             * os dados que o usuário digitou.
                             */
                            Nome = Nome,
                            Telefone = Telefone,
                            Email = Email,
                            Observacoes = Observacoes
                        });

                        await Application.Current.MainPage.DisplayAlert("Beleza!", "Contato Salvo!", "OK");
                        //PopAsync é o voltar da Navigation
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }
                });
            }
        }

    }
}
