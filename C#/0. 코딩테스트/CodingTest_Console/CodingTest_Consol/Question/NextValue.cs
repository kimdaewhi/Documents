using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_Console.Question
{
    internal class NextValue
    {
        /// <summary>
        /// 2진수로 변환된 정수의 1 개수 구하기
        /// </summary>
        /// <param name="sb">2진수 StringBuilder</param>
        /// <returns>1의 개수(count)</returns>
        public int CountOfOne(StringBuilder sb)
        {
            int cnt = 0;

            // 정수 n의 1 개수 구하기
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i].ToString() == "1")
                    cnt++;
            }

            return cnt;
        }


        /// <summary>
        /// 정수 num을 2진수로 변환하는 함수
        /// </summary>
        /// <param name="num">변환할 정수</param>
        /// <returns>2진수 변환값</returns>
        public string ConvertBinary(int num)
        {
            StringBuilder sb = new StringBuilder();

            List<int> list_remain = new List<int>();

            int quotient = 0;           // 몫
            int remainder = 0;          // 나머지


            remainder = num % 2;
            quotient = num / 2;
            list_remain.Add(remainder);     // 나머지값을 List에 추가

            for (int i = 0; quotient >= 2; i++)
            {
                // 몫과 몫에 대한 나머지를 List에 추가
                remainder = quotient % 2;
                quotient = quotient / 2;
                list_remain.Add(remainder);
            }

            // 몫을 StringBuilder 첫 번째 index에 Append
            sb.Append(quotient.ToString());
            for (int i = list_remain.Count - 1; i >= 0; i--)
            {
                // List 역순으로 Append
                sb.Append(list_remain[i].ToString());
            }

            // StringBuilder 맨 앞자리가 0이면 제거
            if (sb[0].ToString() == "0")
                sb.Remove(0, 1);

            return sb.ToString();
        }
    }
}
