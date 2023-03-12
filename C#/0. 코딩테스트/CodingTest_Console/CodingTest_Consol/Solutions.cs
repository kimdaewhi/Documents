using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CodingTest_Console.Question;

namespace CodingTest_Console
{
    class Solutions
    {
        private List<string> list_solution;

        public Solutions()
        {
            list_solution = new List<string>();
        }




        /// <summary>
        /// 정수 n의 다음 정수 구하기(2진수 변환)
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12911 참고
        /// 
        /// 자연수 n이 주어졌을 때, n의 다음 큰 숫자는 다음과 같이 정의 합니다.
        /// 조건 1. n의 다음 큰 숫자는 n보다 큰 자연수 입니다.
        /// 조건 2. n의 다음 큰 숫자와 n은 2진수로 변환했을 때 1의 갯수가 같습니다.
        /// 조건 3. n의 다음 큰 숫자는 조건 1, 2를 만족하는 수 중 가장 작은 수 입니다.
        /// 예를 들어서 78(1001110)의 다음 큰 숫자는 83(1010011)입니다.
        /// 
        /// 자연수 n이 매개변수로 주어질 때, n의 다음 큰 숫자를 return 하는 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="n">정수</param>
        /// <returns></returns>
        public static int Solution_NextValue(int n)
        {
            NextValue qustion1 = new NextValue();

            int answer = 0;

            StringBuilder sb_binary = new StringBuilder(qustion1.ConvertBinary(n));
            int cntOfOne = 0;           // n의 1 개수
            int cntOfOne_2 = 0;         // n 다음 수의 1 개수

            cntOfOne = qustion1.CountOfOne(sb_binary);

            // cntOfOne과 동일한 정수 nextval 구하기
            int nextval = n + 1;
            while (true)
            {
                StringBuilder nextval_binary = new StringBuilder(qustion1.ConvertBinary(nextval));
                cntOfOne_2 = qustion1.CountOfOne(nextval_binary);

                if (cntOfOne == cntOfOne_2)
                {
                    answer = nextval;
                    break;
                }
                else
                {
                    nextval = nextval + 1;
                }

            }

            return answer;
        }




        /// <summary>
        /// 탐욕법
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42885 참고
        /// </summary>
        /// <param name="list_people">원소 List</param>
        /// <param name="limit">최대 수치</param>
        /// <returns>최소값</returns>
        public static int Solution_Greedy(List<int> list_people, int limit)
        {
            int answer = 0;

            int init_limit = limit;

            Queue<int> queue = new Queue<int>();

            for(int i = 0; i < list_people.Count; i++)
            {
                if (queue.Count == list_people.Count)       // 모든 원소가 이미 탑승했으면 break;
                    break;

                if(queue.Contains(i) == false)              // 보트 탄사람이 아니면 보트 태우기 and Enqueue
                {
                    limit = limit - list_people[i];
                    queue.Enqueue(i);
                }

                for (int j = 0; j < list_people.Count; j++) //보트 태운 후 다음사람부터 더 태울사람 있는지 체크하는 로직
                {
                    if ((queue.Contains(j) == false) && (limit >= list_people[j]))
                    {
                        limit = limit - list_people[j];
                        queue.Enqueue(j);
                    }
                }

                answer = answer + 1;                        // 보트 탑승횟수 + 1 및 다시 초기화
                limit = init_limit;
                
            }

            return answer;
        }




        /// <summary>
        /// 탐욕법(체육복)
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42862 참고
        /// </summary>
        /// <param name="n">총 학생 수</param>
        /// <param name="lost">잃어버린 학생 배열</param>
        /// <param name="reserve">여벌 체육복이 있는 학생 배열</param>
        /// <returns>수업 가능한 학생 수</returns>
        public static int Solution_SportWear(int n, int[] lost, int[] reserve)
        {
            int answer = 0;

            Queue<int> que = new Queue<int>();      // 도난 안당했으나 체육복 못빌려주는애들

            for (int i = 1; i <= n; i++)            // 전체를 loop 돌림(잃어버린 학생 배열이나, 여벌 배열을 기준으로 돌리지 않음)
            {
                if (lost.Contains(i))           // 체육복 잃어버린 학생일 때
                {
                    if (reserve.Contains(i))    // 여벌이 있는 학생일 때 
                    {
                        answer++;               // 수업 가능함
                        que.Enqueue(i);         // ??
                    }
                    else if ( reserve.Contains(i - 1) &&            // 잃어버린 학생의 앞번 친구가 여벌 체육복이 있는 학생일 때
                              lost.Contains(i - 1) == false &&      // 위의 학생이 체육복 도난당한 애가 아니거나
                              que.Contains(i - 1) == false )        // 큐에 없으면(도난 안당했으나 여벌 없는애들)
                    {
                        answer++;
                        que.Enqueue(i - 1);                         // 체육복 못빌려주는 학생(i)를 큐에 넣어줌
                    }
                    else if ( reserve.Contains(i + 1) &&            // 잃어버린 학생의 뒷번 친구가 여벌 체육복이 있는 학생일 때
                              lost.Contains(i + 1) == false &&      // 위의 학생이 체육복 도난당한 애가 아니거나
                              que.Contains(i + 1) == false)
                    {
                        answer++;
                        que.Enqueue(i + 1);
                    }
                }
                else                            // 체육복을 잃어버린 학생이 아닐 때
                {
                    answer++;
                } 
            }

            return answer;
        }



        /// <summary>
        /// 개인정보 수집 유효기간(카카오)
        /// https://school.programmers.co.kr/learn/courses/30/lessons/150370?language=csharp
        /// today는 "YYYY.MM.DD" 형태로 오늘 날짜를 나타냅니다.
        /// </summary>
        /// <param name="today">금일 날짜</param>
        /// <param name="terms">약관 유효기간 배열</param>
        /// <param name="privacies">수집된 개인정보</param>
        /// <returns>파기할 정보 index</returns>
        public static int[] Solution_ExpireArr(string today, string[] terms, string[] privacies)
        {
            int[] answer = new int[] { };
            List<int> list_answer = new List<int>();

            for (int i = 0; i < privacies.Length; i++)
            {
                // 1. 만료일자 구하기
                string[] expireDate = privacies[i].Split(' ')[0].Split('.');

                int currMM = Convert.ToInt32(expireDate[1]);
                int expMM = 0;
                for (int j = 0; j < terms.Length; j++)
                {
                    if( privacies[i].Split(' ')[1].ToString() == terms[j].Split(' ')[0].ToString())
                    {
                        expMM = Convert.ToInt32(terms[j].Split(' ')[1]);

                        expireDate[1] = currMM + expMM > 12 ? (currMM - (12 - expMM)).ToString() : (currMM + expMM).ToString();         // 만료일자 월 구하기
                        expireDate[0] = currMM + expMM > 12 ? (Convert.ToInt32(expireDate[0]) + 1).ToString() : expireDate[0];          // 만료일자 년 구하기
                                                                                                                                        // 만료일자 일 구하기
                        if (Convert.ToInt32(expireDate[2]) == 1)
                        {
                            expireDate[2] = "28";
                            expireDate[1] = Convert.ToInt32(expireDate[1]) - 1 == 0 ? "12" : (Convert.ToInt32(expireDate[1]) - 1).ToString();
                            expireDate[0] = Convert.ToInt32(expireDate[1]) - 1 == 0 ? (Convert.ToInt32(expireDate[0]) - 1).ToString() : expireDate[0];
                        }
                        else
                        {
                            expireDate[2] = (Convert.ToInt32(expireDate[2]) - 1).ToString();
                        }

                        string strExpDate = string.Empty;
                        for (int k = 0; k < expireDate.Length; k++)
                        {
                            strExpDate += expireDate[k] + ".";
                        }
                        strExpDate = strExpDate.Substring(0, strExpDate.Length - 1);
                        // ------------------------------- 만료일자 구하기 End

                        // 2. 현재일 <-> 파기일 비교해서 List에 Add하기
                        if (Convert.ToDateTime(today) > Convert.ToDateTime(strExpDate))
                        {
                            list_answer.Add(i + 1);
                        }
                        break;
                    }
                    
                }


            }

            answer = list_answer.ToArray();

            return answer;
        }




    }
}
