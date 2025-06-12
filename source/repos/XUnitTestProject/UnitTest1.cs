using RaftlapDLL;
using RaftlapDLL.Models;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            RaftLab obj = new RaftLab();

            Console.WriteLine("Testing single user API");

            for (int i = 0; i <= 15; i++)
            {
                User Single = await obj.getUserDetails(i);
                if (Single == null)
                {
                    Console.WriteLine("No record has been found for the UserId " + i);
                }
                else
                {
                    Console.WriteLine("Below are the Details for UserId " + i);
                    Console.WriteLine("UserId ->" + Single.Id);
                    Console.WriteLine("EmailId ->" + Single.Email);
                    Console.WriteLine("First_Name ->" + Single.First_Name);
                    Console.WriteLine("Last_Name ->" + Single.Last_Name);
                    Console.WriteLine("Avatar ->" + Single.Avatar);
                }
               
                Console.WriteLine("----------------------------------------------------------------------------");

            }

            Console.WriteLine("End of single user");

            for (int Page = 0; Page <= 15; Page++)
            {
                Console.WriteLine("start of Multiple user");
                List<User> multiple = await obj.getUserPageDetails(Page);

                if (multiple == null)
                {
                    Console.WriteLine("No record has been found for the page Number " + Page);
                }
                else
                {
                    Console.WriteLine(multiple.Count() + " records has been found for the page Number " + Page);
                    Console.WriteLine("Below are the Details for Page " + Page);

                    foreach (User user in multiple)
                    {
                        Console.WriteLine("UserId ->" + user.Id);
                        Console.WriteLine("EmailId ->" + user.Email);
                        Console.WriteLine("First_Name ->" + user.First_Name);
                        Console.WriteLine("Last_Name ->" + user.Last_Name);
                        Console.WriteLine("Avatar ->" + user.Avatar);
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++");
                    }
                }

                Console.WriteLine("----------------------------------------------------------------------------");
            }

            Console.WriteLine("End of Multiple user");

        }
    }
}