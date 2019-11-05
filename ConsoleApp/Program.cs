using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double valorDigitado = LerValorUsuario();
                int opcaoSelecionada = LerParOuImparUsuario();
                double[] valoresCalculados = ObterValoresCriado(valorDigitado);
                Imprimir(valoresCalculados);
                double[] valoresParOrImpar = ObterValorPorPosicaoParOrImpar(valoresCalculados, IsPar(opcaoSelecionada));
                Imprimir(valoresParOrImpar);
                Console.WriteLine("Resultado: {0}", valoresParOrImpar.Sum());                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool IsPar(int opcaoSelecionada)
        {
            return opcaoSelecionada == 1;
        }

        private static double[] ObterValorPorPosicaoParOrImpar(double[] valoresCalculados, bool isPar)
        {                        
            if (isPar)
            {
                return valoresCalculados.Where((i, index) => (index + 1) % 2 == 0).ToArray();                   
            }
            else
            {
                return valoresCalculados.Where((i, index) => (index + 1) % 2 != 0).ToArray();
            }            
        }

        private static int LerParOuImparUsuario()
        {
            Console.WriteLine("Deseja a somatória das posições ( 0 - impar, 1 - par)");
            string valorPosicao = Console.ReadLine();
            if (string.IsNullOrEmpty(valorPosicao))
            {
                throw new Exception("Opção inválida");
            }
            if (!valorPosicao.Trim().Equals("0") & !valorPosicao.Trim().Equals("1"))
            {
                throw new Exception("Opção inválida");
            }
            return int.Parse(valorPosicao);
        }

        private static double LerValorUsuario() 
        {
            Console.WriteLine("Informe um valor");
            string valorUsuario = Console.ReadLine();
            if (string.IsNullOrEmpty(valorUsuario))
            {
                throw new Exception("Valor inválido");
            }
            if (!double.TryParse(valorUsuario, out double valorDigitado))
            {
                throw new Exception("Valor inválido");
            }
            return valorDigitado;
        }

        public static double[] ObterValoresCriado(double valorDigitado)
        {
            double[] valores = new double[10];
            for (int i = 1; i <= 10; i++)
            {
                if (i % 3 == 0)
                {
                    valores[i - 1] = i * 0.3 * valorDigitado;
                }
                else
                {
                    valores[i - 1] = i * 0.1 * valorDigitado;
                }
            }
            return valores;
        }

        public static void Imprimir(double[] valores)
        {
            Console.WriteLine("[{0}]", string.Join(", ", valores));
        }
    }
}
