using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Country_Capital
{
     class Program
    {
        static void Main(string[] args)
        {
            //Collection to save all the countries and the coresponding capitals
            Dictionary<int, Dictionary<string, string>> country_Capital 
                = new Dictionary<int, Dictionary<string, string>>();
            int addedCountryCounter = 0; 
            
            //Variables to export the countries and their capitals
            string Africa = @"..\..\..\DataAfrica.txt";
            string Asia = @"..\..\..\DataAsia.txt";
            string Australia = @"..\..\..\DataAustralia.txt";
            string Europe = @"..\..\..\DataEurope.txt";
            string NorthAmerica = @"..\..\..\DataNorthAmerica.txt";
            string SouthAmerica = @"..\..\..\DataSouthAmerica.txt";

            //Text and rules
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hey there!");
            Console.WriteLine("This program was written by Bochkata."); 
            Console.WriteLine("You will be asked to type the capital of random generated country.");
            Console.WriteLine("Score over 80% to win.");
            Console.WriteLine("Please choose difficulty. Note:If u don't choose a difficulty a random number will be chosen between 1 and 200.");
            Console.WriteLine("Easy - 15 countries)(Normal - 35 countries)(Hard - 70 countries)(Insane - 150 countries)(Custom - number of your choice)");
            
            //Chosing the difficulty
            string difficulty = Console.ReadLine();
            Console.WriteLine("Please select continents to include countries from by typing the corresponding number seperated with a space:");
            Console.WriteLine("(1-Asia),(2-Africa),(3-North America),(4-South America),(5-Europe),(6-Australia)");

            //checking which continents should be added
            var inputNumber = Console.ReadLine().Split(" ");
            if (inputNumber.Contains("1"))
            {
                var AsiaCountries = GetAllTheCountriesAndTheirCapitalsFromTheSelectedContinent(Asia);
                var countriesToAdd = FillingTheDictionaryWithCountries(AsiaCountries);
                foreach (var currentCountry in countriesToAdd)
                {
                    country_Capital.Add(addedCountryCounter, new Dictionary<string, string>());
                    country_Capital[addedCountryCounter].Add(currentCountry.Key, currentCountry.Value);
                    addedCountryCounter++;
                }
            }
            if (inputNumber.Contains("2"))
            { 
                var AfricaCountries = GetAllTheCountriesAndTheirCapitalsFromTheSelectedContinent(Africa);
                var countriesToAdd = FillingTheDictionaryWithCountries(AfricaCountries);
                foreach (var currentCountry in countriesToAdd)
                {
                    country_Capital.Add(addedCountryCounter, new Dictionary<string, string>());
                    country_Capital[addedCountryCounter].Add(currentCountry.Key, currentCountry.Value);
                    addedCountryCounter++;
                }
            }
            if (inputNumber.Contains("3"))
            {
                var NorthAmericaCountries = GetAllTheCountriesAndTheirCapitalsFromTheSelectedContinent(NorthAmerica);
                var countriesToAdd = FillingTheDictionaryWithCountries(NorthAmericaCountries);
                foreach (var currentCountry in countriesToAdd)
                {
                    country_Capital.Add(addedCountryCounter, new Dictionary<string, string>());
                    country_Capital[addedCountryCounter].Add(currentCountry.Key, currentCountry.Value);
                    addedCountryCounter++;
                }
            }
            if (inputNumber.Contains("4"))
            {
                var SouthAmericaCountries = GetAllTheCountriesAndTheirCapitalsFromTheSelectedContinent(SouthAmerica);
                var countriesToAdd = FillingTheDictionaryWithCountries(SouthAmericaCountries);
                foreach (var currentCountry in countriesToAdd)
                {
                    country_Capital.Add(addedCountryCounter, new Dictionary<string, string>());
                    country_Capital[addedCountryCounter].Add(currentCountry.Key, currentCountry.Value);
                    addedCountryCounter++;
                }
            }
            if (inputNumber.Contains("5"))
            {
                var EuropeCountries = GetAllTheCountriesAndTheirCapitalsFromTheSelectedContinent(Europe);
                var countriesToAdd = FillingTheDictionaryWithCountries(EuropeCountries);
                foreach (var currentCountry in countriesToAdd)
                {
                    country_Capital.Add(addedCountryCounter, new Dictionary<string, string>());
                    country_Capital[addedCountryCounter].Add(currentCountry.Key, currentCountry.Value);
                    addedCountryCounter++;
                }
            }
            if (inputNumber.Contains("6"))
            {
                var AustraliaCountries = GetAllTheCountriesAndTheirCapitalsFromTheSelectedContinent(Australia);
                var countriesToAdd = FillingTheDictionaryWithCountries(AustraliaCountries);
                foreach (var currentCountry in countriesToAdd)
                {
                    country_Capital.Add(addedCountryCounter, new Dictionary<string, string>());
                    country_Capital[addedCountryCounter].Add(currentCountry.Key, currentCountry.Value);
                    addedCountryCounter++;
                }
            }

            //if none are added
            if (country_Capital.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0 selected continents!");
                Console.WriteLine("Please reopen the program and follow the instructions!");
                Console.ForegroundColor = ConsoleColor.White;
                System.Environment.Exit(0);
            }

            //Number of questions part
            int numberOfQuestions = 0;
            if (difficulty.ToLower()=="easy")
            {
                numberOfQuestions = 15;
            }
            if (difficulty.ToLower() == "normal")
            {
                numberOfQuestions = 35;
            }
            if (difficulty.ToLower() == "hard")
            {
                numberOfQuestions = 70;
            }
            if (difficulty.ToLower() == "insane")
            {
                numberOfQuestions = 150;
            }
            if (difficulty.ToLower()=="custom")
            {
                Console.Write("Please type a whole(integer) number for the count of questions: ");
                var checkForWholeNumber = int.TryParse(Console.ReadLine(), out numberOfQuestions);
            }

            //invalid cases
            if (numberOfQuestions <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You didn't select a difficulty or it was invalid so it will be random amount of countries between 1 and 200!");
                Random rng = new Random();
                numberOfQuestions = rng.Next(1,200);
                Console.WriteLine($"The random amount of countries is {numberOfQuestions}!");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Good luck!");

            //counter which is later used for the result calculation
            int rightAnsweredQuestions = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Random number = new Random();
                int countryNumber = number.Next(0, country_Capital.Count - 1);
                Console.ForegroundColor = ConsoleColor.White;
                string question = "";
                string rightAnswer = "";
                foreach (var tempCountryNumber in country_Capital)
                {
                    if (tempCountryNumber.Key == countryNumber)
                    {
                        foreach (var tempCountry in tempCountryNumber.Value)
                        {
                            question = tempCountry.Key;
                            rightAnswer = tempCountry.Value;
                        }
                    }
                }
                Console.WriteLine();
                if (numberOfQuestions-i==1)
                    Console.WriteLine($"Last question ");
                else
                    Console.WriteLine($"Remaining questions {numberOfQuestions-i}");
                Console.WriteLine("What is the capital of " + question+ "?");
                string answer = Console.ReadLine();

                //Right
                if (answer.ToLower() == rightAnswer.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!!! :) You get a point!");
                    rightAnsweredQuestions++;
                }

                //Wrong
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong! :( You don't get a point!");
                    Console.Write("The correct answer was ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(rightAnswer);
                }
            }
            Console.WriteLine();
            double percentageCorrectAnswers = rightAnsweredQuestions*100/numberOfQuestions;
            
            //Pass
            if (percentageCorrectAnswers>80)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Good game you won! You scored {Math.Round(percentageCorrectAnswers)}%");
            }

            //Fail
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Try again for better result! You scored {Math.Round(percentageCorrectAnswers)}%");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static Dictionary<string,string> FillingTheDictionaryWithCountries(List<string> countries)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            foreach (var item in countries)
            {
                var tempString = item.Split("_", StringSplitOptions.RemoveEmptyEntries);
                string country = tempString[0];
                string capital = tempString[1];
                temp.Add(country, capital);
            }
            return temp;
        }
        private static List<string> GetAllTheCountriesAndTheirCapitalsFromTheSelectedContinent(string continentName)
        {
            var output = new List<string>();
            using (StreamReader sr = new StreamReader(continentName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    output.Add(line);
                }
            }
            return output;
        }
    }
}

