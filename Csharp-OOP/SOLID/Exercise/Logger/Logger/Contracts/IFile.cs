using System.Text;

namespace Logger
{
    public interface IFile
    {
        public int Size { get; }
        public string Path { get; }
        public StringBuilder Log { get; set; }
        public void Write(string message);
    }
}