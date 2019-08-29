using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORMEF
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelPessoas context = new ModelPessoas();
            Pessoa p = new Pessoa()
            {
                Nome = "João Pinheiro",
                Nascimento = new DateTime(2019, 12, 15)
            };
            Pessoa p2 = new Pessoa()
            {
                Nome = "Maria Pinheiro",
                Nascimento = new DateTime(1988, 12, 24)
            };
            Pessoa resultado = PersistirPessoa(context, p);
            Pessoa resultadop2 = PersistirPessoa(context, p2);

            Cidade curitiba = null;
            curitiba = (from c in context.Cidades
                            .Include(c => c.Moradores)
                        where c.Nome == "Curitiba"
                        select c).FirstOrDefault();
            if (curitiba == null)
            {
                curitiba = new Cidade() { Nome = "Curitiba" };
            }

            resultado.Cidade = curitiba;
            resultadop2.Cidade = curitiba;

            context.SaveChanges();

            foreach (Pessoa pessoa in curitiba.Moradores)
            {
                Console.WriteLine("Nome:" + pessoa.Nome);
            }


            Casa casa = new Casa()
            {
                Cidade = curitiba,
                Endereco = "Rua: XXXXXXX, Nº.1111, Bairro: oooo"
            };
            casa.Moradores.Add(resultado);
            casa.Moradores.Add(resultadop2);

            context.Casas.Add(casa);
            context.SaveChanges();
             Console.ReadKey();


        }

        private static Pessoa PersistirPessoa(ModelPessoas context, Pessoa p)
        {
            var resultado = (from pessoa in context.Pessoas
                             where pessoa.Nome == p.Nome
                             select pessoa).FirstOrDefault();
            if (resultado == null)
            {
                resultado = context.Pessoas.Add(p);
            }

            return resultado;
        }
    }
}
