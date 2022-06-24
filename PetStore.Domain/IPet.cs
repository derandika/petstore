using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Domain
{
    /// <summary>
    /// IPet Interface
    /// </summary>
    interface IPet
    {
        double Id { get; set; }
        Category Category { get; set; }
        string Name { get; set; }
        string[] PhotoUrl { get; set; }
        //string[] Tags { get; set; }
        string Status { get; set; }
    }
}
