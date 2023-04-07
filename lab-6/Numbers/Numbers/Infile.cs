using Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Numbers
{

    public struct Occurrence
    {
        public int number;
        public int count;
        public override string ToString()
        {
            return "(" + number.ToString() + " " + count.ToString()+")";
        }
    }

    public class Infile
    {
        private enum Status { abnorm, norm };

        private TextFileReader _x;
        private int _dx;
        private Status _sx;
        Occurrence _cur;
        bool _end;

        public Infile(string fileName)
        {
            _x = new TextFileReader(fileName);
        }

        private void Read()
        {
            _sx = (_x.ReadInt(out _dx)) ? Status.norm : Status.abnorm;
        }

        public void First() { Read(); Next(); }
        public Occurrence Current() { return _cur; }
        public bool End() { return _end; }
        public void Next()
        {
            if (!(_end = (_sx == Status.abnorm)))
            {
                _cur.number = _dx;
                _cur.count = 0;
                while(Status.norm == _sx && _dx == _cur.number)
                {
                    ++_cur.count;
                    Read();
                }
            }
        }

    }

}
