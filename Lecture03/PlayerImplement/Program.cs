using System;
using System.Text;

namespace PlayerImplement
{
    internal class Program
    {
        private static void Main()
        {
            Player player1 = new Player
            {
                Name = "Player 1",
                Level = 14,
                HP = 83,
                Exp = 1042
            };

            Player player2 = new Warrior
            {
                Name = "Player 2",
                Level = 23,
                HP = 122,
                Exp = 48932
            };

            player1.PrintInfo();
            player1.PrintJob();

            Console.WriteLine();

            player2.PrintInfo();
            player2.PrintJob();
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Exp { get; set; }

        public void PrintInfo()
        {
            var info = new StringBuilder()
                .AppendLine($"---------- Info ----------")
                .AppendLine($"Name : {Name}")
                .AppendLine($"Level: {Level}")
                .AppendLine($"HP   : {HP}")
                .AppendLine($"Exp  : {Exp}")
                .AppendLine($"--------------------------");

            Console.Write(info.ToString());
        }

        public virtual void PrintJob()
        {
            Console.WriteLine("플레이어입니다.");
        }
    }

    public class Warrior : Player
    {
        public override void PrintJob()
        {
            Console.WriteLine("전사입니다.");
        }
    }
}
