using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApi.Model
{
    public class FuncionarioModel
    {

        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Preço { get; set; }
        public String SuperMercado { get; set; }



    }

}
