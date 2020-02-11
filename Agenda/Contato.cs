using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda
{
    class Contato
    {
        public Contato()
        {
            this.Codigo = 0;
            this.Nome = "";
            this.Telefone = "";
        }
        public Contato(int codigo, string nome, string telefone)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Telefone = telefone;
        }

        private int con_cod;
        public int Codigo
        {
            get
            {
                return this.con_cod;
            }
            set
            {
                this.con_cod = value;
            }
        }
        private string con_nome;
        public string Nome
        {
            get { return this.con_nome; }
            set { this.con_nome = value; }
        }
        private string con_telefone;
        public string Telefone
        {
            get { return this.con_telefone; }
            set { this.con_telefone = value; }
        }
    }
}
