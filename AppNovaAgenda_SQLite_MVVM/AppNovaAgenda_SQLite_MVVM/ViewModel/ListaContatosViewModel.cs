using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppNovaAgenda_SQLite_MVVM.Helpers;

namespace AppNovaAgenda_SQLite_MVVM.ViewModel
{
    public class ListaContatosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /**
         * Se refere ao SearchBAR
         */
        public string ParametroBusca { get; set; }

        /**
         * 
         */
        public ObservableCollection<Model.Contato> ListaContatos { get; set; } =
            new ObservableCollection<Model.Contato>();

        public ICommand IrParaNovoContato
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new View.NovoContato());
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                    }
                });
            }
        }
        public ICommand AtualizarLista
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        /**
                         * tmp_list: lista temporaria que vai receber todas as informações
                         * do banco. Ela é uma lista porque o retorno do GetAllContatosAsync
                         * é uma list
                         */
                        List<Model.Contato> tmp_list = await App.Database.GetAllContatosAsync();

                        /**
                         * Pra atualizar a minha ObservableCollection, primeiro eu limpo ela
                         * pra garantir, porque o usuário pode clicar varias vezes em atualizar.
                         * Antes de copiar os dados da list pra ObservableCollection eu limpo ela.
                         */
                        ListaContatos.Clear();
                        /**
                         * Aqui eu to usando um metodo da LINQ pra abastecer toda a minha 
                         * ObservableCollection usando a expressão lambida.
                         * Pra cada elemento x, vai executar o listacontatos.add adicionando
                         * o elemento x, poderia ser qualquer letra.
                         */
                        tmp_list.ForEach(x => ListaContatos.Add(x));
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
