using EFCoreStudies.Context;
using EFCoreStudies.Models;
using EFCoreStudies.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreStudies
{
    internal class Program
    {


        static void Main(string[] args)
        {

            PersonServices service01 = new PersonServices();
            Person p1 = new Person();

            DateTime birthdate;

            Console.WriteLine("Informe seu nome");
            p1.Name = Console.ReadLine();
            Console.WriteLine("Informe seu CPF");
            p1.Cpf = (int)Int128.Parse(Console.ReadLine());
            Console.WriteLine("Informe sua data de nascimento");
            string SBirthDate = Console.ReadLine();
            p1.BirthDate = DateTime.Parse(SBirthDate).ToUniversalTime();

            Console.WriteLine(service01.AddNewPerson(p1.Name, p1.BirthDate, p1.Cpf));
        }
    }
}
