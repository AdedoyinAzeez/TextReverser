using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IOReverse
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter input file path:");
            //first line read on the console is assigned to the "input" variable
            String input = Console.ReadLine();

            //creates a bool that confirms the input file path exists
            bool inputFileExist = File.Exists(input);

            Console.WriteLine(inputFileExist ? "File exists." : "File does not exist.");
            Console.WriteLine(" ");

            if (inputFileExist)
            {
                Console.WriteLine("Enter output file path:");
                //second line read on console is assigned to the "output" variable
                String output = Console.ReadLine();

                //creates a bool that confirms the output file path exists
                bool outputFileExist = File.Exists(output);

                Console.WriteLine(outputFileExist ? "File exists." : "File does not exist.");
                Console.WriteLine(" ");

                //if the output file path does not exist, create a new file with the path given on the console
                if (!outputFileExist)
                {
                    FileStream fs = File.Create(output);
                }

                //calls textreverser method
                TextReverser(input, output);
            }

        }

        //public static void write(String x)
        //{
        //    //opens the output file and writes
        //    using (StreamWriter writeFile = File.AppendText(output))
        //    {
        //        output = x;
        //        list.Reverse();
        //        list.ForEach(i => writeFile.WriteLine(i));
        //        counter = 0;
        //        list.Clear();
        //        list.Add(reversedLine);
        //        counter++;

        //    }

        //}

        public static void TextReverser(String input, String output)
        {
            String line;
            String reversedLine = "";
            //int textFileLineCount = File.ReadLines(input).Count();
            //int textFileReadLimit = 10;
            //int counter = 1;

            List<String> list = new List<String>();

            //opens the input file given
            using (StreamReader readFile = File.OpenText(input))
            {
                //reads the first line in the input file
                line = readFile.ReadLine();

                //while the file is not empty and the number of line counter is less than the read line limit, continue
                while (line != null)
                {

                    //converts the contents of the line read into a character array
                    char[] charArray = line.ToCharArray();

                    //reverse the array
                    Array.Reverse(charArray);

                    //converts the reversed character array into a string
                    reversedLine = new String(charArray);

                   // list.Add(reversedLine);

                    try
                    {
                        FileStream fStream = File.Open(output, FileMode.Open);
                        if (fStream.CanWrite)
                        {
                            //string s = textBox1.Text;
                            //reversedLine = textBox1.Text;
                         var test=   fStream.Seek(2, SeekOrigin.Begin);
                            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(reversedLine);
                            fStream.Write(bytes, 0, bytes.Length);
                        }
                        fStream.Flush();
                        fStream.Close();

                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    //if (counter <= textFileReadLimit && textFileReadLimit <= textFileLineCount)
                    //{
                    //    list.Add(reversedLine);
                    //    counter++;
                    //}

                    //else if (counter > textFileReadLimit && textFileReadLimit <= textFileLineCount)
                    //{
                    //    //opens the output file
                    //    using (FileStream writeFile = File.Open(output, FileMode.Open))
                    //    {
                    //        list.Reverse();

                    //        list.ForEach(i => writeFile.WriteLine(i));
                    //        counter = 1;
                    //        list.Clear();
                    //        list.Add(reversedLine);
                    //        counter++;

                    //    }
                    //}
                    //else if (counter <= textFileReadLimit && textFileReadLimit > textFileLineCount)
                    //{
                    //    list.Add(reversedLine);
                    //    counter++;

                    //    if (counter == textFileLineCount)
                    //    {
                    //        using (StreamWriter writeFile = File.AppendText(output))
                    //        {
                    //            list.Reverse();
                    //            list.ForEach(i => writeFile.WriteLine(i));
                    //            counter = 1;
                    //            list.Clear();
                    //            list.Add(reversedLine);
                    //            counter++;
                    //        }
                    //    }

                    //}


                    ////reads the next line
                    //line = readFile.ReadLine();

                    //if(line == null)
                    //{
                    //    //opens the output file
                    //    using (StreamWriter writeFile = File.AppendText(output).)
                    //    {
                    //        list.Reverse();
                    //        //Console.SetCursorPosition

                    //        list.ForEach(i => writeFile.WriteLine(i));
                    //        counter = 1;
                    //        list.Clear();
                    //        list.Add(reversedLine);
                    //        counter++;

                    //    }
                    //}

                    line = readFile.ReadLine();
                }

                //opens the output file
                    using (StreamWriter writeFile = File.AppendText(output))
                {
                    list.Reverse();
                    //Console.SetCursorPosition

                    list.ForEach(i => writeFile.WriteLine(i));
                }



                Console.WriteLine("Data written to file");

                //closes the StreamReader
                readFile.Close();
                Console.ReadLine();
            }
        }
    }
}