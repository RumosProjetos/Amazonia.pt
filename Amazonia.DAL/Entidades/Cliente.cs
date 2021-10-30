using System;
using System.Linq;

namespace Amazonia.DAL.Entidades
{
    public class Cliente : Entidade
    {
        public Morada Morada { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year;
        public string NumeroIdentificacaoFiscal { get; set; }

        public bool NifEstaValido()
        {
            if (NumeroIdentificacaoFiscal.Length != 9)
                return false;

            if (NumeroIdentificacaoFiscal.ToCharArray().Distinct().ToList().Count == 1)
                return false;


            //123456789
            var produtoSomatorio = 0;
            var fatorMultiplicao = 2;
            for (int i = NumeroIdentificacaoFiscal.Length-2; i >= 0; i--)
            {
                var elemento = (Convert.ToInt32(NumeroIdentificacaoFiscal[i].ToString()));
                var produto = elemento * fatorMultiplicao;
                produtoSomatorio += produto;
                fatorMultiplicao++;
            }

            var restoDivisaoPor11 = produtoSomatorio % 11;
            if((restoDivisaoPor11 == 0 || restoDivisaoPor11 == 1) && (Convert.ToInt32(NumeroIdentificacaoFiscal[8].ToString())) == 0)
            {
                return true;
            }
            else
            {
                return (11 - restoDivisaoPor11) == (Convert.ToInt32(NumeroIdentificacaoFiscal[8].ToString()));
            }
        }



        /// <summary>
        /// Exibe os dados do Cliente
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Nome: {Nome} => Idade: {Idade} => Identificador: {Identificador}";
        }
    }
}