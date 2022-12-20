using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Enum;

namespace ToDo.Interfaces
{
    public interface ICard
    {
        string Title { get; set; }
        string Content { get; set; }
        IPerson AssignedPerson { get; set; }
        EnumSize Size { get; set; }
        EnumStatus Status { get; set; }
    }
}