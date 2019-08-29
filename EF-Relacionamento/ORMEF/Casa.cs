using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMEF
{
    public class Casa
    {
        public int Id { get; set; }


        [InverseProperty("Casas")]
        public IList<Pessoa> Moradores { get; set; }
            = new List<Pessoa>();

        public Cidade Cidade { get; set; }

        public String Endereco { get; set; }
    }
}
