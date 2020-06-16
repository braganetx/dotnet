using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TesteDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem vindo!!!");

            bool fimCalculadora = false;

            while (!fimCalculadora)
            {
                string textNumero = "";
                string textNumero2 = "";
                int validoNumero1 = 0;
                int validoNumero2 = 0;
                int resultado = 0;
                string menu = "";

                Console.WriteLine("******:MENU:******");
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("\tn - Calculadora Normal");
                Console.WriteLine("\ts - Calculadora Sobrecarga");
                Console.WriteLine("\tm - Calculadora Média");
                Console.WriteLine("\tp - Calculadora Soma de Pares");
                Console.WriteLine("\td - Dicionário de dados");
                menu = Console.ReadLine();

                switch (menu)
                {
                    case "n":
                        Console.Clear();
                        Console.WriteLine("Calculadora Normal");

                        Console.Write("Digite um número e pressione Enter : \n");
                        textNumero = Console.ReadLine();

                        while (!int.TryParse(textNumero, out validoNumero1))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("O valor " + textNumero + " não é válido, por favor digite um número: \n ");
                            Console.ResetColor();
                            textNumero = Console.ReadLine();
                        }

                        Console.Write("Digite o segundo número e precione Enter: \n ");
                        textNumero2 = Console.ReadLine();

                        while (!int.TryParse(textNumero2, out validoNumero2))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Este valor não é válido, por favor digite um número: \n");
                            Console.ResetColor();
                            textNumero2 = Console.ReadLine();
                        }

                        Console.WriteLine("**Escolha a operação que deseja ultilizar**");
                        Console.WriteLine("Digite o a operação desejada");
                        Console.WriteLine("\t+ - Soma");
                        Console.WriteLine("\t- - Subtração");
                        Console.WriteLine("\t* - Multiplicação");
                        Console.WriteLine("\t/ - Divisão");
                        string operacao = Console.ReadLine();

                        try
                        {
                            switch (operacao)
                            {
                                case "+":
                                    resultado = Calculadora.Soma(validoNumero1, validoNumero2);
                                    if (Double.IsNaN(resultado))
                                    {
                                        Console.WriteLine("Esta expressão resultou em erro matemático");
                                    }
                                    else
                                    {
                                        Console.WriteLine("O resultado da operação é: {0:0.##}\n", resultado);
                                    }
                                    break;
                                case "-":
                                    resultado = Calculadora.Subtracao(validoNumero1, validoNumero2);
                                    if (Double.IsNaN(resultado))
                                    {
                                        Console.WriteLine("Esta expressão resultou em erro matemático");
                                    }
                                    else
                                    {
                                        Console.WriteLine("O resultado da operação é: {0:0.##}\n", resultado);
                                    }
                                    break;
                                case "*":
                                    resultado = Calculadora.Multiplicacao(validoNumero1, validoNumero2);
                                    if (double.IsNaN(resultado))
                                    {
                                        Console.WriteLine("Esta expressão resultou em erro matemático");
                                    }
                                    else
                                    {
                                        Console.WriteLine("O resultado da operação é: {0:0.##}\n", resultado);
                                    }
                                    break;
                                case "/":
                                    resultado = Calculadora.Divisao(validoNumero1, validoNumero2);
                                    if (Double.IsNaN(resultado))
                                    {
                                        Console.WriteLine("Esta expressão resultou em erro matemático");
                                    }
                                    else
                                    {
                                        Console.WriteLine("O resultado da operação é: {0:0.##}\n", resultado);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Valor de operação inválido");
                                    break;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops! Ocorreu um erro ao tentar fazer a operação, por favor tente uma nova operação diferente \n - Detalhes: " + e.Message);
                        }

                        break;
                    case "s":
                        Console.Write("Digite os números separados por ; (ponto e vírgula) e pressione Enter : \n");
                        textNumero = Console.ReadLine();
                        try
                        {
                            int soma = Calculadora.Soma(textNumero.Split(';').Select(Int32.Parse).ToArray());
                            if (Double.IsNaN(soma))
                            {
                                Console.WriteLine("Esta expressão resultou em erro matemático");
                            }
                            else
                            {
                                Console.WriteLine("O resultado da operação é: {0:0.##}\n", soma);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops!, Ocorreu um erro ao tentar fazer a soma." + e.Message);
                        }
                        break;
                    case "m":
                        Console.Write("Digite os números separados por ; (ponto e vírgula) e pressione Enter : \n");
                        textNumero = Console.ReadLine();
                        try
                        {
                            double media = Calculadora.Media(textNumero.Split(';').Select(Double.Parse).ToArray());
                            if (Double.IsNaN(media))
                            {
                                Console.WriteLine("Esta expressão resultou em erro matemático");
                            }
                            else
                            {
                                Console.WriteLine("O resultado da operação é: {0:0.##}\n", media);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops!, Ocorreu um erro ao tentar fazer a soma." + e.Message);
                        }
                        break;
                    case "p":
                        Console.Write("Digite os números separados por ; (ponto e vírgula) e pressione Enter : \n");
                        textNumero = Console.ReadLine();
                        try
                        {
                            int somaPares = Calculadora.SomaPares(textNumero.Split(';').Select(int.Parse).ToArray());
                            if (Double.IsNaN(somaPares))
                            {
                                Console.WriteLine("Esta expressão resultou em erro matemático");
                            }
                            else
                            {
                                Console.WriteLine("O resultado da operação é: {0:0.##}\n", somaPares);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oops!, Ocorreu um erro ao tentar fazer a soma." + e.Message);
                        }
                        break;

                    case "d":
                        try
                        {
                            Console.Clear();

                            string path = "../../../testeDotNet.txt";

                            Dictionary<string, double> pessoasDicionario = Calculadora.LerArquivo(path);

                            foreach (KeyValuePair<string, double> pessoa in pessoasDicionario)
                            {
                                Console.WriteLine("Nome : " + pessoa.Key);
                                Console.WriteLine("Resultado Operação : " + pessoa.Value);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erro ao tentar finalizar o processo!!" + e.Message);
                        }
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar ou ESC para sair: ");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine(" Obrigado por ultilizar nossa calculadora");
                    Thread.Sleep(2000);
                    fimCalculadora = true;
                    Console.WriteLine("\n");
                }
                Console.Clear();

            }
            return;
        }

    }
}
