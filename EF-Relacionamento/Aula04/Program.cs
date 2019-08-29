using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula04
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[7]{4,5,6,7,8,9,11};
            var pares = from num in numbers
                        where (num % 2) == 0
                        select num;
            Console.Write("Números:");
            foreach(int x in pares)
            {
                Console.Write(x + ",");
            }
            ExemploPessoa();
            Console.ReadKey();
        }


        static void ExemploPessoa()
        {
            Cidade vitoria = new Cidade() {
                Nome = "Vitoria" };
            Cidade curitiba = new Cidade() {
                Nome = "Curitiba" };
            IList<Pessoa> Pessoas = new List<Pessoa>();
            Pessoas.Add(new Pessoa()
            {
                Nome = "Alex Pinheiro",
                Nascimento = new DateTime(1983, 12, 15),
                Cidade = curitiba                
            });            
            Pessoas.Add(new Pessoa()
            {
                Nome = "Gabriela Pinheiro",
                Nascimento = new DateTime(1988, 02, 26),
                Cidade = curitiba
            });
            Pessoas.Add(new Pessoa()
            {
                Nome = "Rodrigo Pinheiro",
                Nascimento = new DateTime(1987, 12, 24),
                Cidade = vitoria
                
            });
            Pessoas.Add(new Pessoa()
            {
                Nome = "Penha Pinheiro",
                Nascimento = new DateTime(1964, 03, 25),
                Cidade = vitoria
            });

            var resultado =
                from p in Pessoas                
                orderby p.Nascimento ascending
                select p.Nome + " Idade:"+
                        (DateTime.Now.Year 
                        -p.Nascimento.Year)
                        .ToString();
            

            foreach (var x in resultado)
            {
                Console.Write(x + ",");
            }

            var resultadoGroup = 
                from p in Pessoas
                where DateTime.Now.Year - p.Nascimento.Year > 18
                group p by p.Cidade;

            foreach (var grupo in resultadoGroup)
            {
                Console.WriteLine("InicioGrupo:" 
                    + grupo.Key.Nome);
                foreach(var item in grupo)
                {
                    Console.Write(item + ",");
                }
                Console.WriteLine("Fim Grupo:");
            }
            Console.ReadKey();
        }
    }
}
