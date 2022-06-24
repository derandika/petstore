using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Domain
{
    /// <summary>
    /// Pet Status enum
    /// </summary>
    public enum PetStatus
    {
        [Description("available")]
        Available = 0,
        [Description("pending")]
        Pending = 1,
        [Description("sold")]
        Sold = 2
    }
}
