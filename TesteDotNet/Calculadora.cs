using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TesteDotNet
{
    class Calculadora
    {
        public static int Soma(int num1, int num2)
        {
            int resultado = 0;
            resultado = num1 + num2;

            return resultado;
        }

        public static int Subtracao(int num1, int num2)
        {
            int resultado = 0;
            resultado = num1 - num2;

            return resultado;
        }
        public static int Multiplicacao(int num1, int num2)
        {
            int resultado = 0;
            resultado = num1 * num2;

            return resultado;
        }
        public static int Divisao(int num1, int num2)
        {
            int resultado = 0;
            resultado = num1 / num2;

            return resultado;
        }

        public static int Soma(params int[] num)
        {
            int resultado = 0;

            for (int i = 0; i < num.Length; i++)
            {
                resultado += num[i];
            }

            return resultado;
        }
        public static double Media(params double[] num)
        {
            double soma = 0.0;
            int j = 0;

            for (int i = 0; i < num.Length; i++)
            {
                soma += num[i];

                j++;
            }

            double media = (soma / j);

            return media;
        }

        public static int SomaPares(params int[] num)
        {
            int resultado = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] % 2 == 0)
                {
                    resultado += num[i];
                }
            }

            return resultado;
        }

        public static Dictionary<string, double> LerArquivo(string arquivoPath)
        {
            string linha;
            Dictionary<string, double> pessoas = new Dictionary<string, double>();
            double resultado = 0;

            StreamReader arquivo = new StreamReader(arquivoPath);
            while ((linha = arquivo.ReadLine()) != null)
            {
                if (linha.Trim().Length != 0)
                {
                    resultado = 0;
                    string[] listaPessoas = linha.Split(";");
                    string nome = listaPessoas[0];
                    string operacao = listaPessoas[1];
                    string valor1 = listaPessoas[2];
                    string valor2 = listaPessoas[3];

                    if (operacao.Contains("Soma"))
                    {
                        List<int> valores = new List<int>();
                        for (int i = 2; i <= listaPessoas.Length - 1; i++)
                        {
                            if (listaPessoas.Length > 0)
                            {
                                valores.Add(Int32.Parse(listaPessoas[i]));
                            }
                        }
                        resultado = Soma(valores.ToArray());
                    }
                    if (operacao.Contains("Divisão"))
                    {
                        resultado = Divisao(Int32.Parse(valor1), Int32.Parse(valor2));
                    }
                    if (operacao.Contains("Multiplicacao"))
                    {
                        resultado = Multiplicacao(Int32.Parse(valor1), Int32.Parse(valor2));
                    }
                    if (operacao.Contains("Subtração"))
                    {
                        resultado = Subtracao(Int32.Parse(valor1), Int32.Parse(valor2));
                    }
                    pessoas.Add(nome, resultado);
                }
            }
            arquivo.Close();

            return pessoas;
        }

    }
}
