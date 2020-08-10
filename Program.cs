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
                    File.Create(output);
                }

                //calls textreverser method
                TextReverser(input, output);
            }

        }


        public static void TextReverser(String input, String output)
        {
            //String line;
            var offset = 0;

            try
            {
                FileStream inputFile = new FileStream(input, FileMode.Open, FileAccess.Read);

                if (inputFile.CanRead)
                {

                    inputFile.Seek(offset, SeekOrigin.End);

                    byte[] bytes = new byte[inputFile.Length];
                    int numBytesToRead = (int)inputFile.Length;
                    int numBytesRead = 0;

                    while(numBytesToRead > 0)
                    {
                        for(offset = 0; offset < inputFile.Length; offset++)
                        {
                            int n = inputFile.Read(bytes, numBytesRead, numBytesToRead);
                            //int n = inputFile.ReadByte();
                            inputFile.ReadByte();
                            //offset++;

                            //if (n == 0)
                            //{
                              //  break;
                            //}

                            //numBytesRead += n;
                            //numBytesToRead -= n;
                        }
                        
                    }

                    numBytesToRead = bytes.Length;

                    try
                    {
                        FileStream outputFile = new FileStream(output, FileMode.Open, FileAccess.Write);

                        if (outputFile.CanWrite)
                        {
                            outputFile.WriteByte(bytes[offset]);
                            //outputFile.Write(bytes, 0, numBytesToRead);
                            

                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Data written to file");


        }
    }
}

        //converts the contents of the line read into a character array
        //char[] charArray = line.ToCharArray();

        //try
        //{
        //    FileStream inputFile = File.Open(input, FileMode.Open);
        //    if (inputFile.CanRead)
        //    {
        //        inputFile.Seek(charOffset, SeekOrigin.End);
        //        byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(line);
        //        var b = inputFile.ReadByte();
        //        //inputFile.WriteByte();

        //    }
        //}
        //catch (IOException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

        //try
        //{
        //    FileStream outputFile = File.Open(output, FileMode.Open);
        //    if (outputFile.CanWrite)
        //    {
        //        //string s = textBox1.Text;
        //        //reversedLine = textBox1.Text;
        //        outputFile.Seek(lineOffset, SeekOrigin.End);
        //        byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(line);
        //        outputFile.Write(bytes, 0, bytes.Length);
        //    }
        //    outputFile.Flush();
        //    outputFile.Close();

        //}
        //catch (IOException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

    //opens the output file
    //    using (StreamWriter writeFile = File.AppendText(output))
    //{
    //    list.Reverse();
    //    //Console.SetCursorPosition

        //list.ForEach(i => writeFile.WriteLine(i));
    //}
