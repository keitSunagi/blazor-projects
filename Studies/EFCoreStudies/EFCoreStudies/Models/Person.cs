using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStudies.Models
{
    class Person
    {
        [Key]
        public int Cpf { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public DateTime BirthDate { get; set; } = DateTime.UtcNow;
        public List<Item> ItemList { get; set; } = new List<Item>();

        public override string ToString()
        {
            return $"CPF: {Cpf} / Nome: {Name} / Idade: {Age} / Data de Nascimento: {BirthDate.ToString()}";
        }
    }
}
