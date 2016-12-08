using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ConsoleCommands
    {
        public void InputReader(string userInput, SQLConnection SQLCon)
        {
            Console.Clear();

            switch (userInput)
            {
                case "login":
                        if(!SQLCon.LoggedIn())
                            SQLCon.LogIn();
                        break;

                case "logout":
                        if (SQLCon.LoggedIn())
                            SQLCon.LogOut();
                        break;

                case "logged in":
                        if (SQLCon.LoggedIn())
                            Console.WriteLine("You are currently logged in");
                        else if (!SQLCon.LoggedIn())
                            Console.WriteLine("You are currently logged out");
                        break;
                case "AddStudent":
                    if(!SQLCon.LoggedIn())
                    {
                        Console.WriteLine("Please log in before trying to add a new student");
                        break;
                    }
                    AddStudent(SQLCon);
                    break;
                case "help":
                    Console.WriteLine("Your current available commands are: \r\n" + " login, logout, logged in, AddStudent, close");
                    break;
                default:
                        break;
            }
        }

        private void AddStudent(SQLConnection SQLCon)
        {
            bool enteringInformation = true;
            string currentInformationState = "EfterNavn";
            string userInput;
            string EfterNavn = ""; string ForNavn = ""; string Klasse = "";
            Console.WriteLine("Intast EfterNavn, eller skriv 'cancel' for at afbryde");

            while(enteringInformation)
            {
                userInput = Console.ReadLine();

                switch (currentInformationState)
                {
                    case "EfterNavn":

                        if (userInput == "cancel")
                        {
                            enteringInformation = false;
                            Console.WriteLine("AddStudent var afbrudt");
                            break;
                        }

                        EfterNavn = userInput;
                        currentInformationState = "Fornavn";
                        Console.WriteLine("Intast Fornavn, eller skriv 'cancel' for at afbryde");
                        break;

                    case "Fornavn":

                        if (userInput == "cancel")
                        {
                            enteringInformation = false;
                            Console.WriteLine("AddStudent var afbrudt");
                            break;
                        }

                        ForNavn = userInput;
                        currentInformationState = "Klasse";
                        Console.WriteLine("Intast Klasse, eller skriv 'cancel' for at afbryde");
                        break;

                    case "Klasse":

                        if(userInput == "cancel")
                        {
                            enteringInformation = false;
                            Console.WriteLine("AddStudent var afbrudt");
                            break;
                        }

                        Klasse = userInput;
                        currentInformationState = "Confirmation";
                        Console.WriteLine("Du har nu intastet:" 
                            + "\r\n Efternavn: " + EfterNavn 
                            + "\r\n Fornavn: " + ForNavn 
                            + "\r\n Klasse: " + Klasse 
                            + "\r\n skriv apply for at tilføje eller cancel for at afbryde");
                        break;

                    case "Confirmation":

                        if (userInput == "cancel")
                        {
                            enteringInformation = false;
                            Console.WriteLine("AddStudent var afbrudt");
                            break;
                        }

                        SQLCon.AddStudent(EfterNavn, ForNavn, Klasse);
                        enteringInformation = false;
                        Console.WriteLine("student " + ForNavn + " " + EfterNavn + " was added");
                        break;
                }
            }
        }
    }
}
