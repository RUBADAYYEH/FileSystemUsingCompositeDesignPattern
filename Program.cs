using CompositePattern;
using Newtonsoft.Json;

using Formatting = Newtonsoft.Json.Formatting;

internal class Program
{
    public static void Main(string[] args)
    {
       
    }

    private static void BuilderExample()
    {
        var builder = new FileSystemBuilder("dev");
        builder.AddDirectory("project1");
        builder.AddFile("p1f1.txt", 2100);
        builder.AddFile("p1f1.txt", 3100);
        builder.AddDirectory("sub-dir");
        builder.AddFile("p1f3.txt", 4100);
        builder.AddFile("p1f4.txt", 5100);
        builder.setCurrentDirectory("dev");
        builder.AddDirectory("project2");
        builder.AddFile("p2f1.txt", 6100);
        builder.AddFile("p2f2.txt", 7100);
        Console.WriteLine($"Total size (root): {builder.Root.GetSizeInKB()}");
        Console.WriteLine(JsonConvert.SerializeObject(builder.Root, Formatting.Indented));
    }

    private static void FileSystemComposites()
    {
        var root = new DirectoryItem("root");
        var project1 = new DirectoryItem("project1");
        var subDir1 = new DirectoryItem("sub-dir1");
        var project2 = new DirectoryItem("project2");
        var p1f3 = new FileItem("p1f3.txt", 4100);
        var p1f4 = new FileItem("p1f4.txt", 5100);
        var p1f1 = new FileItem("p1f1.txt", 2100);
        var p1f2 = new FileItem("p1f2.txt", 3100);
        var p2f1 = new FileItem("p2f1", 6100);
        var p2f2 = new FileItem("p2f2", 7100);
        subDir1.Add(p1f3);
        subDir1.Add(p1f4);
        project1.Add(subDir1);
        project1.Add(p1f1);
        project1.Add(p1f2);
        project2.Add(p2f1);
        project2.Add(p2f2);
        root.Add(project1);
        root.Add(project2);

        Console.WriteLine($"Total size (proj2): {project2.GetSizeInKB()}");
        Console.WriteLine($"Total size (proj1): {project1.GetSizeInKB()}");
        Console.WriteLine($"Total size (root): {root.GetSizeInKB()}");
    }
}