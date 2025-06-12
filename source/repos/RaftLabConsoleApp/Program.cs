
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using RaftlapDLL;
using RaftlapDLL.Models;


bool flag = true;
RaftLab obj = new RaftLab();

while (flag)
{
    Console.WriteLine("Enter 1 to get Details of Single User and 2 for Multiple Users.");
    string? UserInput = Console.ReadLine();


    switch (UserInput)
    {
        case "1":
            Console.WriteLine("Enter UserId to get the details");
            string? UserId = Console.ReadLine();

            if (int.TryParse(UserId, out int Id))
            {
                User Single = await obj.getUserDetails(Id);
                if(Single == null)
                {
                    Console.WriteLine("No record has been found for the UserId " + Id);
                }
                else
                {
                    Console.WriteLine("Below are the Details for UserId " + Id);
                    Console.WriteLine("UserId ->"+Single.Id);
                    Console.WriteLine("EmailId ->" + Single.Email);
                    Console.WriteLine("First_Name ->" + Single.First_Name);
                    Console.WriteLine("Last_Name ->" + Single.Last_Name);
                    Console.WriteLine("Avatar ->" + Single.Avatar);
                }
                
            }
            else
            {
                Console.WriteLine("Enter valid Integer value");
            }
            Console.WriteLine("----------------------------------------------------------------------------");
            break;

        case "2":
            Console.WriteLine("Enter Page Number to get details");
            string PageNumber = Console.ReadLine();

            if (int.TryParse(PageNumber, out int Page))
            {
                List<User> multiple = await obj.getUserPageDetails(Page);

                if(multiple == null)
                {
                    Console.WriteLine("No record has been found for the page Number "+Page);
                }
                else
                {
                    Console.WriteLine(multiple.Count() + " records has been found for the page Number " + Page);
                    Console.WriteLine("Below are the Details for Page " + Page);

                    foreach(User user in multiple)
                    {
                        Console.WriteLine("UserId ->" + user.Id);
                        Console.WriteLine("EmailId ->" + user.Email);
                        Console.WriteLine("First_Name ->" + user.First_Name);
                        Console.WriteLine("Last_Name ->" + user.Last_Name);
                        Console.WriteLine("Avatar ->" + user.Avatar);
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++");
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter valid Integer value");
            }

            Console.WriteLine("----------------------------------------------------------------------------");
            break;

        default:
            Console.WriteLine("Invalid Input.");
            flag = false;
            break;
    }

}















/*RaftLab obj = new RaftLab();

User Single = await obj.getUserDetails(1);

User Single1 = await obj.getUserDetails(1);

var multiple = await obj.getUserPageDetails(1);

Console.ReadLine();*/