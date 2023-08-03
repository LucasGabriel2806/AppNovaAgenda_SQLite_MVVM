using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppNovaAgenda_SQLite_MVVM.Helpers
{
    public class SqliteDataBaseHelper
    {
        /**
         * Sempre que formos trabalhar com Sqlite, uma das altyernativas é criar 
         * um diretório helpers. Nele eu coloquei uma classe que ela faz algumas 
         * operações pra mim que são um pouquinho mais corriqueiras.
         * 
         */
        readonly SQLiteAsyncConnection _db;

        /**
         * Esse método é o construtor da minha classe. Ele ta recebendo como
         * parametro uma string dbPath.
         * Quando iniciamos o App, o App vai tentar se conectar ao nosso
         * arquivo que ta salvo no telefone.
         * essa propriedade _db vai conter a "conexão" com meu sqlite.
         * Não é bem uma conexão, é mais uma leitura de arquivo.
         * Quando eu acabei de chamar essa classe SqliteDataBaseHelper
         * ele faz todas aquelas verificações do que falta acessar e 
         * também cria minha tabela baseada num model
         */
        public SqliteDataBaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<Model.Contato>().Wait();
        }

        /**
         * Pega todos os contatos e retorna uma lista de Model Contato.
         * Task é porque vai ler o arquivo, então quando eu dou o 
         * atualizar existe uma diferença de tempo de execução do
         * arquivo e fazer a leitura da memória do celular, então
         * eu coloco como task porque ela pode ficar executando
         * enquanto eu to mexemdo no app por exemplo.
         * 
         * 
         */
        public Task<List<Model.Contato>> GetAllContatosAsync()
        {
            /**
             * Vai ler minha tabela do modelo contato e vai 
             * transformar todos os dados dessa tabela numa lista 
             * esse método retorna como lista.
             */
            return _db.Table<Model.Contato>().ToListAsync();
        }
        
        public Task<int> SaveContatoAsync(Model.Contato contato)
        {
            /**
             * Insert na tabela
             */
            return _db.InsertAsync(contato);
        }

    }
}
