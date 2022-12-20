using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Interfaces
{
    public interface IToDo
    {
        void AddCard();
        void UpdateCard();
        void DeleteCard();
        void MoveCard();
        void ListBoard();
    }
}