using System;
using System.Collections.Generic;
using System.Text;

namespace DIO_Projeto2
{
    public class GerenciarConta
    {
		static List<Conta> listContas = new List<Conta>();
		public void Gerenciar()
		{
			string opcaoUsuario = ObterOpcaoUsuario();
			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						Console.WriteLine("Opção invalida!! Tente novamente!");
						break;
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}
			Console.WriteLine("Obrigado por utilizar nossos serviços bancários.");
			Console.ReadKey();
		}

		private static void Depositar()
		{
			Console.Write("Digite o número da conta para depósito: ");
			int iConta = int.Parse(Console.ReadLine());
			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());
			listContas[iConta].Depositar(valorDeposito);
		}

		private static void Sacar()
		{
			if (listContas.Count == 0)
			{
				Console.WriteLine("Não é possível realizar está operação pois não há contas cadastradas.");
				return;
			}
			else
			{
				ListarContasOperacao();
			}
			Console.Write("Digite o número da conta: ");
			int iConta = int.Parse(Console.ReadLine());
			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());
			listContas[iConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{
			if (listContas.Count == 0)
			{
				Console.WriteLine("Não é possível realizar está operação pois não há contas cadastradas.");
				return;
			}
			else if (listContas.Count == 1)
			{
				Console.WriteLine("Não é possível realizar está operação pois só há uma conta cadastrada.");
				return;
			}
			else
            {
				ListarContasOperacao();

			}
			Console.Write("Digite o número da conta de origem: ");
			int iContaOrigem = int.Parse(Console.ReadLine());
			Console.Write("Digite o número da conta de destino: ");
			int iContaDestino = int.Parse(Console.ReadLine());
			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());
			listContas[iContaOrigem].Transferir(valorTransferencia, listContas[iContaDestino]);
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta no banco");
			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());
			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();
			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());
			Console.Write("Digite o crédito inicial: ");
			double entradaCredito = double.Parse(Console.ReadLine());
			Conta novaConta = new Conta(numeroConta: listContas.Count,
										tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);
			listContas.Add(novaConta);
		}
		private static void ListarContasOperacao()
		{
			Console.WriteLine("Contas cadastradas");
			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta encontrada.");
				return;
			}
			foreach (var conta in listContas)
			{
				Console.WriteLine(conta.ResumoConta());
			}
			Console.WriteLine();
		}
		private static void ListarContas()
		{
			Console.WriteLine("Listar contas existentes");
			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta encontrada.");
				return;
			}
			foreach (var conta in listContas)
			{
				Console.WriteLine(conta);
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Bem vindo ao JW Bank!!");
			Console.WriteLine("Por favor, informe a opção desejada:");
			Console.WriteLine("1 - Listar contas");
			Console.WriteLine("2 - Inserir nova conta");
			Console.WriteLine("3 - Transferir");
			Console.WriteLine("4 - Sacar");
			Console.WriteLine("5 - Depositar");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();
			string opcaoUsuario = Console.ReadLine();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
