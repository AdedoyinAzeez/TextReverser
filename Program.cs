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
            int offset = 0;
            int readLength = 10;

            try
            {
                FileStream inputFile = new FileStream(input, FileMode.Open, FileAccess.Read);

                if (inputFile.CanRead)
                {
                    FileStream outputFile = new FileStream(output, FileMode.Open, FileAccess.Write);

                    byte[] bytes = new byte[readLength];
                    int numBytesToRead = (int)inputFile.Length;
                    int numBytesRead = 0;
                    int remainder = 0;

                    //offset = numBytesToRead; offset > -remainder; offset -= readLength
                    for (offset = 0; offset <= numBytesToRead; offset+= readLength)
                    {
                        //if (offset < 0)
                        //{
                        //    //offset = offset;
                        //    //readLength = offset;
                        //}

                        
                        inputFile.Seek(-offset, SeekOrigin.End);

                        int n = inputFile.Read(bytes, 0, readLength);
                        numBytesRead += n;
                        remainder = numBytesToRead - numBytesRead;

                        if (remainder < readLength)
                        {
                            readLength = remainder;
                        }

                        //if (n < -offset)
                        //{
                        //    break;
                        //}

                        //if (remainder < numBytesToRead)
                        //{
                        //    numBytesToRead = remainder;
                        //}

                        try
                        {
                            if (outputFile.CanWrite)
                            {
                                Array.Reverse(bytes);
                                //outputFile.Position = 0;
                                outputFile.Write(bytes, 0, n);
                                outputFile.Flush();
                               
                            }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine(ex.Message + " outputCatch");
                        }
                    }

                    outputFile.Close();
                    outputFile.Dispose();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message + " inputCatch");
            }

            Console.WriteLine("Data written to file");


        }
    }
}