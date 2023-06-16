//Author:   Gregorics Tibor
//Date:     2021.10.24.
//Title:    Read from text file

using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TextFile
{
    public class TextFileReader
    {
        private readonly StreamReader reader;

        public TextFileReader(string filename)
        {
            if (!File.Exists(filename)) throw new System.IO.FileNotFoundException();
            reader = new StreamReader(filename);
        }

        //Task: 	reading the next character
        //Input:    StreamReader reader -  datachannel to a text file
        //Output:   char ch             -  char
        //          bool l              -  true if the character exists
        //Activity: it uses the Read() method of reader if the text file is not empty
        public bool ReadChar(out char ch)
        {
            if (reader == null) throw new System.IO.FileNotFoundException();
            ch = '\0';
            string limiter = " \n\t\r";
            int x;
            while ((x = reader.Read()) != -1 && limiter.Contains(Convert.ToChar(x))) ;
            if (x == -1) return false;
            ch = Convert.ToChar(x);
            return true;
        }

        public char? ReadChar()
        {
            if (reader == null) throw new System.IO.FileNotFoundException();

            string limiter = " \n\t\r";
            int x;
            while ((x = reader.Read()) != -1 && limiter.Contains(Convert.ToChar(x))) ;
            if (x == -1) return null;
            char ch = Convert.ToChar(x);
            return ch;
        }

        //Task: 	reading the next string that is terminated by whitespace or eof
        //Input:    StreamReader reader -  datachannel to a text file
        //Output:   string str          -  string
        //          bool l              -  true if the string exists
        //Activity: it finds the beginning of the next string overstepping whitespaces, 
        //          and if this string exists, it concatenates its characters bordered by whitespace or eof
        public bool ReadString(out string str)
        {
            str = "";
            if (reader == null) throw new System.IO.FileNotFoundException();

            string limiter = " \n\t\r";
            int x;
            while ((x = reader.Read()) != -1 && limiter.Contains(Convert.ToChar(x))) ;
            if (x == -1) return false;

            str += Convert.ToChar(x);
            while ((x = reader.Read()) != -1 && !limiter.Contains(Convert.ToChar(x)))
            {
                str += Convert.ToChar(x);
            }
            return true;
        }

        public string ReadString()
        {
            if (reader == null) throw new System.IO.FileNotFoundException();

            string limiter = " \n\t\r";
            int x;
            while ((x = reader.Read()) != -1 && limiter.Contains(Convert.ToChar(x))) ;
            if (x == -1) return null;

            string str = "" + Convert.ToChar(x);
            while ((x = reader.Read()) != -1 && !limiter.Contains(Convert.ToChar(x)))
            {
                str += Convert.ToChar(x);
            }
            return str;
        }

        //Task: 	reading the next integer that is terminated by white-space or eof
        //Input:    StreamReader reader -  datachannel to a text file
        //Output:   int n               -  integer
        //          bool l              -  true if the string exists
        //Activity: it reads the next string (see ReadString()), and then it will be converted to integer
        public bool ReadInt(out int n)
        {
            if (reader == null) throw new System.IO.FileNotFoundException();
            n = 0;
            bool l = ReadString(out string str);
            if (l) n = int.Parse(str);
            return l;
        }
 
        public int? ReadInt()
        {
            if (reader == null) throw new System.IO.FileNotFoundException();
            string str = ReadString();
            if (str == null) return null;
            return int.Parse(str);
        }

        //Task: 	reading the next bouble number that is terminated by white-space or eof
        //Input:    StreamReader reader -  datachannel to a text file
        //Output:   double a            -  double
        //          bool l              -  true if the string exists
        //Activity: it reads the next string (see ReadString()), and then it will be converted to double
        public bool ReadDouble(out double a) 
        {
            if (reader == null) throw new System.IO.FileNotFoundException();
            a = 0.0; 
            bool l = ReadString(out string str);
            if (l) a = str.Contains('.') ? double.Parse(str,CultureInfo.CreateSpecificCulture("en-GB")) : double.Parse(str);
            return l;
        }

        public double? ReadDouble()
        {
            if (reader == null) throw new System.IO.FileNotFoundException();
            string str = ReadString();
            if (str == null) return null;
            return double.Parse(str);
        }

        //Task: 	reading the next line
        //Input:    StreamReader reader -  datachannel to a text file
        //Output:   string line         -  char
        //          bool l              -  true if the character exists
        //Activity: it uses the ReadLine() method of reader
        public bool ReadLine(out string line)
        {
            line = reader.ReadLine();
            return line != null;
        }
        public string ReadLine()
        {
            return reader.ReadLine();
        }
    }
}
