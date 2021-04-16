using System;
using System.Collections.Generic;
using System.Text;

namespace DIO_Projeto2
{
	public class Conta
	{
		private int NumeroConta { get; set; }
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }

		public Conta(int numeroConta, TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.NumeroConta = numeroConta;
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
			if (this.Saldo - valorSaque < (this.Credito *- 1))
			{
				Console.WriteLine("Saldo insuficiente!");
				return false;
			}
			this.Saldo -= valorSaque;
			Console.WriteLine("Saque de R$ {0} realizado com sucesso!", valorSaque);
			Console.WriteLine("O saldo atual da conta de {0} é R${1}.", this.Nome, this.Saldo);
			return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;
			Console.WriteLine("O saldo atual da conta de {0} é R${1}.", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia))
			{
				contaDestino.Depositar(valorTransferencia);
			}
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "Conta: " + this.NumeroConta + " | ";
			retorno += "Tipo da Conta: " + this.TipoConta + " | ";
			retorno += "Nome: " + this.Nome + " | ";
			retorno += "Saldo: " + this.Saldo + " | ";
			retorno += "Crédito: " + this.Credito;
			return retorno;
		}
		public string ResumoConta()
		{
			string retorno = "";
			retorno += "Conta: " + this.NumeroConta + " | ";
			retorno += "Nome: " + this.Nome;
			return retorno;
		}
	}
}
