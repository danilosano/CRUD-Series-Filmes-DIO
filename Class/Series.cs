using System;
using DIO_Series_Filmes.Class;


namespace DIO_Series_Filmes
{
    public class Series : EntidadeBase
    {
        private Genero genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido{get; set; }

        public Series(int Id,Genero genero, string titulo, string descricao, int ano, bool Excluido)
        {
            this.Id = Id;
            this.genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = Excluido;

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero : "+this.genero + Environment.NewLine;
            retorno += "Título : "+this.Titulo + Environment.NewLine;
            retorno += "Descrição : "+this.Descricao + Environment.NewLine;
            retorno += "Ano de Início : "+this.Ano + Environment.NewLine;

            return retorno;
        }

        public string retornaTitulo(){
            return this.Titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public void Excluir(){
            this.Excluido = true;;
        }

        public bool retornaExcluido()
		{
			return this.Excluido;
		}
    }
}