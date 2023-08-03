using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppNovaAgenda_SQLite_MVVM.Model
{
    public class Contato
    {
        /**
         * deu um using do sqlite, porque o sqlite ta usando
         * o meu model como base pra criar a tabela dentro do
         * arquivinho do banco de dados. Então eu preciso apontar
         * pra ele quem vai ser a chave primaria da minha tabela.
         * Pra ciar uma tabela, eu preciso de um model que vai 
         * especificar quais vao ser os campos que vão recebr os dados.
         * O ideal é sempre criar uma classe(SQLiteDataBaseHelper) 
         * que vai fazer esse auxilio, essa interface com o SQLite pra mim.
         * Anotations:
         */
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Observacoes { get; set; }


    }
}
