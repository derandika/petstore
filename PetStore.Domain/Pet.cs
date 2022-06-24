using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Domain
{
    /// <summary>
    /// Pet class
    /// </summary>
    public class Pet : IPet
    {
        public double  Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string[] PhotoUrl { get; set; }
        public string Status { get; set; }
    }

    /// <summary>
    /// Pet Category class
    /// </summary>
    public class Category
    {
        public double Id { get; set; }
        public string Name { get; set; }

    }
}
