using System;
using System.IO;
using SQLite;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using AppNovaAgenda_SQLite_MVVM.Helpers;

namespace AppNovaAgenda_SQLite_MVVM
{
    public partial class App : Application
    {
        /**
         * static sempre retorna a mesma
         */
        static SqliteDataBaseHelper database;
        
        public static SqliteDataBaseHelper Database
        {
            /**
             * Sempre que eu for acessar a propriedade Database, ele 
             * vai entrar no get e verificar se database é null(se ele nunca
             * executou essa linha de código dentro do if, ele é null).
             * LucasAgenda.db3 é o nome do arquivo do banco de dados.
             * Path.Combine(Environment.
             * GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
             * Esse recurso identifica onde eu vou salvar os dados do aplicativo, usamos
             * isso pois estamos trabalhando com multiplataforma, então não tenho um padrão
             * de onde os arquivos do app vao ficar, que são a parte exe e arquivos de db.
             * Eu preciso usar esse recurso pra identificar onde em qual dispositivo eu 
             * vou salvar esses dados do aplicativo.
             * Path.Combine porque vai variar de plataforma pra plataforma.
             * Tudo que eu salvar utilizando a interface do app vai ficar salvo nesse 
             * arquivo LucasAgenda.
             */
            get
            {
                if(database == null)
                {
                    database = new SqliteDataBaseHelper(Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "LucasAgenda.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            /**
             * Essa MainPage(propriedade) é a mesma MainPage da ListaContatosViewModel.
             * NavigationPage é responsável por mostrar a barra de navegação e pra
             * podermos trocar de tela sempre que necessário. é primordial sempre 
             * instanciarmos o NavigationPage quando o nosso App for utilizar mais
             * de uma página.
             */
            MainPage = new NavigationPage(new View.ListaContatos());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
