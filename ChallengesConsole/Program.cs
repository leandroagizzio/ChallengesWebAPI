using ChallengesConsole.Challenges;
using ChallengesWebAPI;
using ChallengesWebAPI.Challenges.Challenges.EqualRowColumnPairs;
using ChallengesWebAPI.Interfaces;
using ChallengesWebAPI.Models;
using ChallengesWebAPI.Models.Dto;
using System.Linq;
using ChallengesWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ChallengesWebAPI.Models.Dto.Interfaces;
using ChallengesWebAPI.Helper;
using ChallengesWebAPI.Models.Interfaces;

namespace ChallengesConsole
{
    public class Program
    {
        static void Main(string[] args) {
            //new EqualRowColumnPairsConsole();

            //var x = lista.Select(c => new ChallengeDto() { Name = c.Name, Link = c.Link }).ToList();

            //var y = lista.Select(c =>  (c.Name, c.Link) ).ToList();

            //var z =
            //    from item in lista
            //    select new { item.Name, item.Link };

            //Environment.CurrentDirectory
            //C:\dev\ChallengesWebAPI\ChallengesWebAPI\bin\Debug\net7.0
            // net7 deb bin CWebAPI
            //       ../../../../ChallengesWebAPI/ChallengesWebAPI.db

            var banco = new AppDbContext(
                (
                    (new DbContextOptionsBuilder<AppDbContext>())
                        //.UseSqlite(connectionString: "DataSource=C:\\dev\\ChallengesWebAPI\\ChallengesWebAPI/ChallengesWebAPI.db;Cache=Shared")
                        .UseSqlite(connectionString: "DataSource=../../../../ChallengesWebAPI/ChallengesWebAPI.db;Cache=Shared")
                ).Options
                );

            var desafio = banco.Challenges.FirstOrDefault();
            var lista = banco.Executions.Where(e => e.ChallengeId == desafio.Id).ToList();

            var desafioDto = HelperFactory.GetChallengeDto().CopyToMe(desafio);
            var listaDto = lista.Select(e => HelperFactory.GetExecutionDto().CopyToMe(e)).ToList();
            desafioDto.Executions = listaDto;
            ;

            var y = 10;

            ////var challengeDto = banco.Challenges.Select(c => new { c.Name, c.Link }).ToList();
            //var challengesDto = banco.Challenges.Select(c => 
            //    new ChallengeDto { Name = c.Name, Link = c.Link }                            
            //).Cast<IChallengeDto>().ToList();

            ////var executionDto = banco.Executions.Select(e => new { e.Input, e.Output, e.IsSuccessful, e.Time }).ToList();

            ////banco.Executions.Where(e => e.ChallengeId == 1)(e => new { e.Input, e.Output, e.IsSuccessful, e.Time });


            ////var ccInex = banco.Executions.Select(e => e.Challenge.Name).Distinct().ToList();

            //var challengeDto = banco.Challenges.Where(c => c.Name == "batatinha").Select(c =>
            //    new ChallengeDto{
            //        Name = c.Name, Link = c.Link,
            //        Executions = banco.Executions.Where(e => e.ChallengeId == c.Id)
            //            .OrderByDescending(e => e.Time)
            //            .Select(e => 
            //                new ExecutionDto { 
            //                    Input = e.Input, Output = e.Output, IsSuccessful = e.IsSuccessful, Time = e.Time })
            //            .Cast<IExecutionDto>()
            //            .ToList()
            //    }
            //).Cast<IChallengeDto>().FirstOrDefault();

            //new AddTwoNumbersLinkedListConsole();

            new SubarrayAveragesConsole();

            Console.WriteLine("Hello, World!");
        }
    }
}