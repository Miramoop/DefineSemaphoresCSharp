// CSCI 436 - Assignment #8 - Concurrency using Semaphores
// Miranda Morris
// 2/18/2024

//Define semaphores in C#, Java, VB, or C++ and use them to provide cooperation and competition synchronization in the shared-buffer example.
//Submit your well-commented code as a Visual Studio project (zipped) for C#, VB, or C++ programs, or as an Eclipse project for a Java program. 


//A semaphore acts as a traffic light. It allows certain users in based on certain rules
//and permissions. In the example, below I wanted to take into account what it would be like
//to set up a very basic log in example of a online website

using System;
using System.Threading;

namespace SemaphoreExample
{
    public class SemaphoreExample
    {
        //creating a semaphore that has a a minimum and maximum of 4 concurrent entries
        public static Semaphore sem = new Semaphore(4,4);

        static void Main(string[] args)
        {
            //creating a semaphore thread that goes through 20 different users
            for(int i = 0; i < 20; i++)
            {
                new Thread(SemaphoreExample.CompleteTask).Start(i);
            }
        }

        //Creating the various permissions for each user and their access
        static void CompleteTask(object id)
        {
            
            Console.WriteLine(id + " would like to access the semaphore"); //The user would like to access the semaphore for 10 seconds (logs into the site)
            sem.WaitOne(10000);
            Console.WriteLine(id + " has gained access to the semaphore"); //The user gains access to the semaphore after 15 seconds (log in attempt works)
            Thread.Sleep(15000);
            Console.WriteLine(id + " is idle on the semaphore"); //The user is idle for 20 seconds (idling for 20 seconds kicks them out of website)
            sem.WaitOne(20000);
            Console.WriteLine(id + " has left the semaphore");  //The user leaves the semaphore (logs out of site)
            sem.Release();
        }

    }

}
