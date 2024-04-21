using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{

    public class FileSystemBuilder
    {
        private DirectoryItem currentDirectory;
        public FileSystemBuilder(string rootDirectory) {
            this.Root = new DirectoryItem(rootDirectory);
            this.currentDirectory = this.Root;
        }
        public DirectoryItem Root { get; }

        public DirectoryItem AddDirectory(string v)
        {
            var dir= new DirectoryItem(v);
            this.currentDirectory.Add(dir);
            this.currentDirectory = dir;
            return dir;
        }
        public FileItem AddFile(string v,long bytes)
        {
            var file = new FileItem(v,bytes);
            this.currentDirectory.Add(new FileItem(v, bytes));
           
            return file;
        }

        internal DirectoryItem setCurrentDirectory(string v)
        {
            var dirStack=new Stack<DirectoryItem>();
            dirStack.Push(this.Root);
            while (dirStack.Any())
            {
                var current=dirStack.Pop();
                if (current.Name == v)
                {
                    this.currentDirectory=current;
                    return current;
                }
                foreach(var item in current.Items.OfType<DirectoryItem>())
                {
                    dirStack.Push(item);
                }
            }
            throw new InvalidOperationException($"Directory anme '{v}' not found!");
            
        }
    }
}
