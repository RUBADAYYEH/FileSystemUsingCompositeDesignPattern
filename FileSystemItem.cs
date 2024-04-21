using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    //compnent structure
    public abstract class FileSystemItem
    {
        public FileSystemItem(string name)
        {
            this.Name = name;
        }
        public string Name { get; }
        //primnary op
        public abstract decimal GetSizeInKB();
        // this method will be executed in both leaf nodes and composite nodes.
    }
}
