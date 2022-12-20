using System;


namespace ToDoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var toDo = new ToDo.ToDo();

            while (true)
            {
                Console.WriteLine("\n  Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("  *******************************************");
                Console.WriteLine("  (1) Board Listelemek");
                Console.WriteLine("  (2) Board'a Kart Eklemek");
                Console.WriteLine("  (3) Board'dan Kart Silmek");
                Console.WriteLine("  (4) Kart Taşımak");
                Console.WriteLine("  (5) Çıkış");

                var ch = Console.ReadLine();

                switch (ch)
                {
                    case "1":
                        toDo.ListBoard();
                        break;
                    case "2":
                        toDo.AddCard();
                        break;
                    case "3":
                        toDo.DeleteCard();
                        break;
                    case "4":
                        toDo.MoveCard();
                        break;
                    case "5":
                        return;
                    default:
                        break;
                }
            }

        }
    }
}
