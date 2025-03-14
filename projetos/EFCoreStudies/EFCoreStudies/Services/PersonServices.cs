using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStudies.Context;
using EFCoreStudies.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreStudies.Services
{
    class PersonServices
    {
        public ProgramContext BdContext { get; set; } = new ProgramContext();
        public string AddNewPerson(string name, DateTime birthdate, int cpf)
        {
            string message = string.Empty;
            Person ResultPerson = new Person();
            int age = DateTime.UtcNow.Year - birthdate.Year;
            ResultPerson.Name = name;
            ResultPerson.Age = age;
            ResultPerson.Cpf = cpf;
            try
            {
                BdContext.Persons.Add(ResultPerson);
                BdContext.SaveChanges();
                message = "Pessoa Salva com sucesso!";
            }catch(DbUpdateException ex)
            {
                message = "Erro na execução - " + ex.Message;
            }
            return message;
        }
    }
}
