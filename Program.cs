using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarstakiGezgin
{
    class Program
    {
        public static string[] yondizi = new string[4] { "W", "N", "E", "S" };
        public static RobotikGezgin robot1 = new RobotikGezgin();
        public static RobotikGezgin robot2 = new RobotikGezgin();
        static void YonDegistir(string harf,RobotikGezgin robot)
        {
            //int indis=0;
            for (int i = 0; i < yondizi.Length; i++)
            {
                if (robot.yon==yondizi[i])
                {
                    if (harf == "L")
                    {
                        if (i == 0)
                        {
                            robot.yon = yondizi[yondizi.Length - 1];
                        }
                        else
                        {
                            robot.yon = yondizi[i - 1];
                        }
                        
                        break;
                    }
                    else if (harf == "R")
                    {
                        if (i==yondizi.Length-1)
                        {
                            robot.yon = yondizi[0];
                        }
                        else
                        {
                            robot.yon = yondizi[i + 1];
                        }
                        break;
                    }

                }

            }
            
        }

        static void BirimIlerle(RobotikGezgin robot)
        {
            if (robot.yon=="N")
            {
                robot.y++;

            }
            else if (robot.yon =="S")
            {
                robot.y--;
            }
            else if (robot.yon=="W")
            {
                robot.x--;
            }
            else if (robot.yon=="E")
            {
                robot.x++;
            }
            
        }
        static void Main(string[] args)
        {
            int xmax, ymax;
            string harfKatari;
            
            Console.WriteLine("Marstaki yüzeyin sağ üst köşe koordinatlarını arada bir boşluk bırakarak giriniz ; ");

            string koordinat = Console.ReadLine();

            xmax = Convert.ToInt16(koordinat.Split(' ')[0]);
            ymax = Convert.ToInt16(koordinat.Split(' ')[1]);

            Console.WriteLine("1. robotik gezginin ilk bulunduğu konumu arada bir boşluk bırakarak giriniz ; ");

            string koordinat1 = Console.ReadLine();
            
            robot1.yon = koordinat1.Split(' ')[2];

            if (Convert.ToInt16(koordinat1.Split(' ')[0])<=xmax)
            {
                robot1.x = Convert.ToInt16(koordinat1.Split(' ')[0]);
            }
            else
            {
                robot1.x = xmax;
            }
            if (Convert.ToInt16(koordinat1.Split(' ')[1]) <= ymax)
            {
                robot1.y = Convert.ToInt16(koordinat1.Split(' ')[1]);
            }
            else
            {
                robot1.y = ymax;
            }

        etiket:
            Console.WriteLine("Harf Katarı yalnızca L-R-M harflerini içermelidir.Lütfen düzgün şekilde harf katarı giriniz ;");
            harfKatari = Console.ReadLine();
         
            foreach (var harf in harfKatari)
            {
                switch (harf)
                {
                    case 'L':
                    case 'l':
                        YonDegistir("L",robot1);
                        break;
                    case 'R':
                    case 'r':
                        YonDegistir("R",robot1);
                        break;
                    case 'M':
                    case 'm':
                        BirimIlerle(robot1);
                        break;
                    default:
                        goto etiket;
                }
            }


            Console.WriteLine("2. robotik gezginin ilk bulunduğu konumu arada bir boşluk bırakarak giriniz ; ");

             koordinat1 = Console.ReadLine();

            robot2.x = Convert.ToInt16(koordinat1.Split(' ')[0]);
            robot2.y = Convert.ToInt16(koordinat1.Split(' ')[1]);
            robot2.yon = koordinat1.Split(' ')[2];


        etiket2:
            Console.WriteLine("Harf Katarı yalnızca L-R-M harflerini içermelidir.Lütfen düzgün şekilde harf katarı giriniz ;");
            harfKatari = Console.ReadLine();

            foreach (var harf in harfKatari)
            {
                switch (harf)
                {
                    case 'L':
                    case 'l':
                        YonDegistir("L", robot2);
                        break;
                    case 'R':
                    case 'r':
                        YonDegistir("R", robot2);
                        break;
                    case 'M':
                    case 'm':
                        BirimIlerle(robot2);
                        break;
                    default:
                        goto etiket2;
                }
            }


            Console.WriteLine(robot1.x.ToString()+" "+robot1.y.ToString()+" "+robot1.yon);
            Console.WriteLine(robot2.x.ToString() + " " + robot2.y.ToString() + " " + robot2.yon);


            Console.ReadKey();

        }
    }
}
