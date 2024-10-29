namespace DanskeTask.Interface
{
    public interface IFileImporter
    {
        public void ImportFile(IEnumerable<string> paths, int minSeverity = int.MaxValue);
    }
}
