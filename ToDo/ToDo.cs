using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Enum;
using ToDo.Interfaces;

namespace ToDo
{
    public class ToDo : IToDo
    {
        private Dictionary<string, Person> TeamMembers;
        private List<Card> Cards;

        public ToDo()
        {
            TeamMembers = new Dictionary<string, Person>();
            TeamMembers.Add("100", new Person("Candar", "Tozan"));
            TeamMembers.Add("101", new Person("Ali", "Bozok"));
            TeamMembers.Add("102", new Person("Mehmet", "Çoban"));
            TeamMembers.Add("103", new Person("Ahmet", "Yılmaz"));
            TeamMembers.Add("104", new Person("Ayşe", "Türkoğlu"));

            Cards = new List<Card>();
            Cards.Add(new Card("Sınav", "Haftaya olacak fizik sınavına çalış.", TeamMembers["100"], EnumSize.M, EnumStatus.TODO));
            Cards.Add(new Card("Yemek", "Akşam yemeği pişir.", TeamMembers["104"], EnumSize.S, EnumStatus.INPROGRESS));
            Cards.Add(new Card("Market", "Gerekli malzemeler için markete git.", TeamMembers["102"], EnumSize.M, EnumStatus.DONE));
        }

        public void AddCard()
        {
            string title;
            string content;
            Person person;
            EnumSize size;

            Console.Write("Başlık Giriniz                                  :");
            title = Console.ReadLine();
            Console.Write("İçerik Giriniz                                  :");
            content = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            var ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    size = EnumSize.XS;
                    break;
                case "2":
                    size = EnumSize.S;
                    break;
                case "3":
                    size = EnumSize.M;
                    break;
                case "4":
                    size = EnumSize.L;
                    break;
                case "5":
                    size = EnumSize.XL;
                    break;
                default:
                    size = EnumSize.XS;
                    break;
            }
             Console.Write("Kişi Seçiniz (ID ile)                           :");
            var id = Console.ReadLine();
            if (!TeamMembers.ContainsKey(id))
            {
                Console.WriteLine("Hatalı giriş yaptınız...");
                return;
            }
            person = TeamMembers[id];

            Cards.Add(new Card(title, content, person, size, EnumStatus.TODO));
        }

        public void DeleteCard()
        {
            string title;
            bool finded = false;

            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:  ");
            title = Console.ReadLine();

            var CCards = new Card[Cards.Count];
            Cards.CopyTo(CCards);

            foreach (var card in CCards)
            {
                if(card.Title == title)
                {
                    Cards.Remove(card);
                    finded = true;
                }
            }
            if (!finded)
            {
                string ch;
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için : (2)");
                ch = Console.ReadLine();
                if(ch == "2")
                {
                    DeleteCard();
                }
            }
        }

        public void ListBoard()
        {
            bool finded = false;

            Console.WriteLine("\n TODO Line");
            Console.WriteLine(" ************************");
            foreach (var card in Cards)
            {
                if(card.Status == EnumStatus.TODO)
                {
                    Console.WriteLine(" Başlık      :" + card.Title);
                    Console.WriteLine(" İçerik      :" + card.Content);
                    Console.WriteLine(" Atanan Kişi :" + card.AssignedPerson);
                    Console.WriteLine(" Büyüklük    :" + card.Size);
                    Console.WriteLine(" -");
                    finded = true;
                }
            }
            if (!finded)
            {
                Console.WriteLine(" ~ BOŞ ~");
            }
            Console.WriteLine("\n");
            finded = false;

            Console.WriteLine(" IN PROGRESS Line");
            Console.WriteLine(" ************************");
            foreach (var card in Cards)
            {
                if (card.Status == EnumStatus.INPROGRESS)
                {
                    Console.WriteLine(" Başlık      :" + card.Title);
                    Console.WriteLine(" İçerik      :" + card.Content);
                    Console.WriteLine(" Atanan Kişi :" + card.AssignedPerson);
                    Console.WriteLine(" Büyüklük    :" + card.Size);
                    Console.WriteLine(" -");
                    finded = true;
                }
            }
            if (!finded)
            {
                Console.WriteLine(" ~ BOŞ ~");
            }
            finded = false;
            Console.WriteLine("\n");

            Console.WriteLine(" DONE Line");
            Console.WriteLine(" ************************");
            foreach (var card in Cards)
            {
                if (card.Status == EnumStatus.DONE)
                {
                    Console.WriteLine(" Başlık      :" + card.Title);
                    Console.WriteLine(" İçerik      :" + card.Content);
                    Console.WriteLine(" Atanan Kişi :" + card.AssignedPerson);
                    Console.WriteLine(" Büyüklük    :" + card.Size);
                    Console.WriteLine(" -");
                    finded = true;
                }
            }
            if (!finded)
            {
                Console.WriteLine(" ~ BOŞ ~");
            }
            Console.WriteLine("\n");

        }

        public void MoveCard()
        {
            bool finded = false;
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız: ");
            var title = Console.ReadLine();
            foreach (var card in Cards)
            {
                if(title == card.Title)
                {
                    finded = true;
                    Console.WriteLine("Bulunan Kart Bilgileri:");
                    Console.WriteLine(" **************************************");
                    Console.WriteLine(" Başlık      :" + card.Title);
                    Console.WriteLine(" İçerik      :" + card.Content);
                    Console.WriteLine(" Atanan Kişi :" + card.AssignedPerson);
                    Console.WriteLine(" Büyüklük    :" + card.Size);
                    Console.WriteLine(" Line        :" + card.Status);
                    Console.WriteLine();
                    Console.WriteLine(" Lütfen taşımak istediğiniz Line'ı seçiniz: ");
                    Console.WriteLine(" (1) TODO");
                    Console.WriteLine(" (2) IN PROGRESS");
                    Console.WriteLine(" (3) DONE");
                    var ch = Console.ReadLine();
                    switch (ch)
                    {
                        case "1":
                            card.Status = EnumStatus.TODO;
                            break;
                        case "2":
                            card.Status = EnumStatus.INPROGRESS;
                            break;
                        case "3":
                            card.Status = EnumStatus.DONE;
                            break;
                        default:
                            Console.WriteLine("Hatalı bir seçim yaptınız!");
                            return;
                    }
                }
            }

            if (!finded)
            {
                string ch;
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için : (2)");
                ch = Console.ReadLine();
                if (ch == "2")
                {
                    MoveCard();
                }
            }
        }

        public void UpdateCard()
        {
            throw new NotImplementedException();
        }
    }
}