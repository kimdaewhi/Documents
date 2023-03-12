using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodingTest_Console;

namespace CodingTest_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMain();
        }


        private static void PrintMain()
        {
            int solutionNum = 0;
            string s_condition = string.Empty;

            while (s_condition != "Q" || s_condition != "q")
            {
                Console.Clear();
                Console.WriteLine("==================== [ 코딩테스트 연습문제 구현 ] ====================");
                Console.WriteLine("    - 작성자 : 김대휘");
                Console.WriteLine("    - 최초작성일 : 2022.10.11");
                Console.WriteLine("    - 최종수정일 : 2022.10.12");
                Console.WriteLine("    - v 2.0.0" + Environment.NewLine + "※ 종료하려면 'Q'를 입력하세요.");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("[1] 다음 큰 숫자");
                Console.WriteLine("[2] 구명보트(탐욕법)");
                Console.WriteLine("[3] 체육복(탐욕법)");
                Console.WriteLine("[4] 개인정보 수집 유효기간");
                Console.WriteLine("--------------------------------------");
            
                Console.Write("문제를 선택하세요 : ");
                s_condition = Console.ReadLine();


                if (int.TryParse(s_condition, out solutionNum))
                {
                    switch (solutionNum)
                    {
                        case 1:
                            Console.Write("정수를 입력하세요 : ");
                            int paramNum = Convert.ToInt32(Console.ReadLine());
                            int answer1 = Solutions.Solution_NextValue(paramNum);
                            /* 결과 출력 */
                            Console.WriteLine(">>> " + paramNum.ToString() + "의 다음 정수 값은 " + answer1.ToString() + "입니다.");
                            Console.Write("계속하려면 아무 키나 입력하세요."); Console.ReadKey();
                            break;

                        case 2:
                            List<int> people_list = new List<int>() { 88, 72, 72, 61, 58, 55, 50, 65, 74, 70, 68, 63, 90, 80, 81, 66, 72 };
                            int limit = 200;
                            int answer2 = Solutions.Solution_Greedy(people_list, limit);
                            Console.WriteLine(">>> 최소 보트 이동수 : " + answer2.ToString() + "입니다.");
                            Console.Write("계속하려면 아무 키나 입력하세요."); Console.ReadKey();
                            break;

                        case 3:
                            int total = 5;
                            int[] lost = { 2, 4 };
                            int[] reserve = { 1, 3, 5 };

                            int answer3 = Solutions.Solution_SportWear(total, lost, reserve);
                            Console.WriteLine(">>> 수업 가능한 학생 수 : " + answer3);
                            Console.Write("계속하려면 아무 키나 입력하세요."); Console.ReadKey();
                            break;

                        case 4:
                            string today = "2022.05.19";
                            string[] terms = { "A 6", "B 12", "C 3" };
                            string[] privacies = { "2021.05.02 A", "2021.07.01 B", "2022.02.19 C", "2022.02.20 C" };

                            // string today = "2020.01.01";
                            // string[] terms = { "Z 3", "D 5" };
                            // string[] privacies = { "2019.01.01 A" };

                            int[] answer = Solutions.Solution_ExpireArr(today, terms, privacies);
                            Console.WriteLine(">>> 파기 해야하는 약관 : " + string.Join(", ", answer)); Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("올바른 번호를 입력하세요.");
                            break;

                        

                    }
                }
                else
                {
                    if (s_condition == "Q" || s_condition == "q")
                    {
                        Console.WriteLine("프로그램을 종료합니다.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("올바른 번호를 입력하세요.");
                    }

                }
            }
        }



    }


}
