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
                    if (!SQLCon.LoggedIn())
                        SQLCon.LogIn();
                    Console.WriteLine("Welcome, You've succesfully logged in");
                    break;

                case "logout":
                    if (SQLCon.LoggedIn())
                        SQLCon.LogOut();
                    Console.WriteLine("Bye");
                    break;

                case "logged in":
                    if (SQLCon.LoggedIn())
                        Console.WriteLine("You are currently logged in");
                    else if (!SQLCon.LoggedIn())
                        Console.WriteLine("You are currently logged out");
                    break;

                case "AddStudent":
                    if (!SQLCon.LoggedIn())
                    {
                        Console.WriteLine("Please log in before trying to add a new student");
                        break;
                    }
                    AddStudent(SQLCon);
                    break;

                case "AddNote":
                    if (!SQLCon.LoggedIn())
                    {
                        Console.WriteLine("Please log in before trying to add a new note");
                        break;
                    }
                    AddNote(SQLCon);
                    break;

                case "help":
                    Console.WriteLine("Your current available commands are: \r\n" + " login, logout, logged in, AddStudent, AddNote, close");
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

            while (enteringInformation)
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

                        if (userInput == "cancel")
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

        private void AddNote(SQLConnection SQLcon)
        {
            bool enteringInformation = true;
            string currentInformationState = "ElevID";
            string userInput;
            int ElevID = ' ';   
            bool succes = int.TryParse("", out ElevID);
            string ElevNote = " ";
            Console.WriteLine("Intast ID'et på eleven du vil lave en note til, eller skriv 'cancel' for at afbryde");

            while (enteringInformation)
            {
                userInput = Console.ReadLine();

                switch (currentInformationState)
                {
                    case "ElevID":
                        if (userInput == "cancel")
                        {
                            enteringInformation = false;
                            Console.WriteLine("AddNote var afbrudt");
                            break;
                        }

                        ElevID = ' ';//userInput;
                        //int selectoption;
                        //if (int.TryParse(userInput, out selectoption))
                            currentInformationState = "ElevNote";
                        Console.WriteLine("Indtast nu Elev Noten, eller skriv 'cancel' for at afbryde");
                        break;



                    case "ElevNote":

                        if (userInput == "cancel")
                        {
                            enteringInformation = false;
                            Console.WriteLine("AddNote var afbrudt");
                            break;
                        }

                        ElevNote = userInput;
                        currentInformationState = "Confirmation";
                        Console.WriteLine("Du har nu intastet:"
                            + "\r\n En ElevNote"
                            + "\r\n skriv apply for at tilføje Noten, eller cancel for at abryde");
                        break;

                    case "Confirmation":

                        if (userInput == "cancel")
                        {
                            enteringInformation = false;
                            Console.WriteLine("AddNote var abrudt");
                            break;
                        }
                        //SQLcon.AddNote(ElevNote);
                        enteringInformation = false;
                        Console.WriteLine("ElevNote til elev " + ElevID + " was added");
                        break;

                }
            }
        }


    }
}
