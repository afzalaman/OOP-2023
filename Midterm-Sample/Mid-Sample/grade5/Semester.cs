using System;
using TextFile;
namespace grade5
{
    public struct Database
    {
        public string semester;
        public string neptun;
        public int th;

        public Database()
        {
            semester = "";
            neptun = "";
            th = 0;
        }
    }
    public enum Status { norm, abnorm }

    public class Semester
	{
        private TextFileReader _x;
        private Database _dx;
        private Status _sx;
        private Database _current;
        private bool _end;

		public Semester(string filename)
		{
            _x = new TextFileReader(filename);
		}
        void Read()
        {
            if (!(_x.ReadString(out _dx.semester) && _x.ReadString(out _dx.neptun) && _x.ReadInt(out _dx.th)))
            {
                _sx = Status.abnorm;
            }
            else
            {
                _sx = Status.norm;
            }
        }
        public void First()
        {
            Read();
            Next();
        }

        public Database Current()
        {
            return _current;
        }
        public bool End()
        {
            return _end;
        }

        public void Next()
        {
            _end = (_sx == Status.abnorm);
            if(!_end)
            {
                _current.semester = _dx.semester;
                //_current.neptun = _dx.neptun;
                _current.th = _dx.th;
                Read();
                while(_sx == Status.norm && _dx.semester == _current.semester)
                {
                    _current.th += _dx.th;
                    Read();
                }
            }
        }
	}
}

