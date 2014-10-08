using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Print(Rotate(Receive("http://buckheit.com/smallestdata.txt"), 8));
            Print(Rotate(Receive("http://buckheit.com/smalldata.txt"), 3));
            Print(Rotate(Receive("http://buckheit.com/bigdata.txt"), 25));
             
            //Print(Receive("http://buckheit.com/smallestdata.txt"));
            Console.ReadLine();
           
        }

        public static int[] Rotate(int[] input, int rotation)
        {
            rotation = rotation % input.Length;
            int[] output = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int replace = (i + rotation) % input.Length;
                int newVal = i % input.Length;
                output[replace] = input[newVal];
            }
            return output;
        }

        public static int[] Receive(String web)
        {
            WebRequest req = WebRequest.Create(web);

            req.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = req.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

            int x = 0;
            int[] array = new int[responseFromServer.Split(' ').Length];
            foreach (String num in responseFromServer.Split(' '))
            {
                array[x] = Int32.Parse(num);
                x++;
            }
            Print(array);

            return array;
        }

        public static void Print(int[] array)
        {
            foreach(int a in array){
                Console.Write(a + " ");
            }
            Console.WriteLine("");
        }
    }
}
