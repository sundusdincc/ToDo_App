using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Enum;
using ToDo.Interfaces;

namespace ToDo
{
    public class Card : ICard
    {
        private string title;
        private string content;
        private IPerson assignedPerson;
        private EnumSize size;
        private EnumStatus status;

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public IPerson AssignedPerson { get => assignedPerson; set => assignedPerson = value; }
        public EnumSize Size { get => size; set => size = value; }
        public EnumStatus Status { get => status; set => status = value; }

        public Card()
        {

        }

        public Card(string title, string content, IPerson assignedPerson, EnumSize size, EnumStatus status)
        {
            Title = title;
            Content = content;
            AssignedPerson = assignedPerson;
            Size = size;
            Status = status;
        }
    }
}