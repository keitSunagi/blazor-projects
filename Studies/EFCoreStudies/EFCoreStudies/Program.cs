using EFCoreStudies.Context;
using EFCoreStudies.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreStudies
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            ProgramContext context = new ProgramContext();
            Person p1 = new Person { Cpf = 77 , Age = 37, Name = "Eita", BirthDate = DateTime.UtcNow};


            try
            {
                context.Persons.Add(p1);
                context.SaveChanges();
                Console.WriteLine("Salvo com sucesso");
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine("Erro na execução!");
                Console.WriteLine("Erro: " + ex.ToString());
            }

            try
            {
                List<Person> returnerPersons = new List<Person>();
                returnerPersons = context.Set<Person>().ToList();
                foreach(Person p in returnerPersons)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            catch(DbUpdateException ex)
            {

            }
            
        }

        
    }
}
