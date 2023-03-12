using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace K_Multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            string s_conditionCheck = string.Empty;
            while(s_conditionCheck != "Q")
            {
                Console.WriteLine("┌----------------------------------------------┐");
                Console.WriteLine("│                                              │");
                Console.WriteLine("│            << Coding Test.v1.0 >>            │");
                Console.WriteLine("│                                              │");
                Console.WriteLine("│ Authored by Kimdaewhi                        │");
                Console.WriteLine("│ Created Mon. Nov 23                          │");
                Console.WriteLine("└----------------------------------------------┘");



                Solution solution = new Solution();
                s_conditionCheck = solution.solutionMain();

                if (s_conditionCheck == "Q")
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    switch (s_conditionCheck)
                    {
                        case "1":
                            #region ****************** case 1 ******************
                            int[] array = { 1, 5, 2, 6, 3, 7, 4 };
                            int[,] commands = { { 2, 5, 3 }
                                              , { 4, 4, 1 }
                                              , { 1, 7, 3} };
                            int[] answer = solution.Multiple_Get(array, commands);

                            Console.WriteLine("[입력값]");
                            Console.Write("array[] : ");
                            for (int i = 0; i < array.Length; i++)
                            {
                                if (i < array.Length - 1)
                                {
                                    Console.Write(array[i] + ", ");
                                }
                                else
                                {
                                    Console.WriteLine(array[i]);
                                }
                            }

                            Console.Write("commands[] : ");
                            for (int i = 0; i < commands.Length / 3; i++)
                            {
                                for (int j = 0; j < commands.Length / 3; j++)
                                {
                                    Console.Write(commands[i, j] + ", ");
                                    if (i >= (commands.Length / 3 - 1) && j >= (commands.Length / 3 - 1))
                                    {
                                        Console.WriteLine(commands[i, j]);
                                    }
                                }
                            }


                            Console.Write("답 : ");
                            for (int i = 0; i < answer.Length; i++)
                            {
                                if (i < answer.Length - 1)
                                {
                                    Console.Write(answer[i] + ", ");
                                }
                                else
                                {
                                    Console.WriteLine(answer[i]);
                                }

                            }
                            Console.WriteLine(); Console.WriteLine();
                            #endregion ************* end case 1 *************
                            break;

                        case "2":
                            #region ****************** case 2 ******************
                            string s_gender = string.Empty;
                            string s_residence = string.Empty;
                            DataTable dt_champion = new DataTable();
                            DataTable dt_woman = new DataTable();
                            dt_champion.TableName = "Champion";
                            dt_champion.Columns.Add("SEQ", typeof(int));                      // 순번
                            dt_champion.Columns.Add("NAME", typeof(string));                  // 이름
                            dt_champion.Columns.Add("GENDER", typeof(string));                // 성별
                            dt_champion.Columns.Add("AGE", typeof(string));                   // 나이
                            dt_champion.Columns.Add("POSITION", typeof(string));              // 포지션(주, 부)
                            dt_champion.Columns.Add("RESIDENCE", typeof(string));             // 소속


                            dt_champion = solution.InitDataTable(dt_champion);


                            Console.Write("성별 : ");
                            s_gender = Console.ReadLine();
                            Console.Write("소속 : ");
                            s_residence = Console.ReadLine();

                            // 성별이 여자인 챔피언 Filter (LINQ 이용)
                            dt_woman = solution.WomanFilter_Get(dt_champion, s_gender, s_residence);
                            foreach (DataRow dr in dt_woman.Rows)
                            {
                                Console.WriteLine(dr["SEQ"] + "\t " + dr["NAME"] + "\t " + dr["GENDER"] + "\t " + dr["AGE"] + "\t " + dr["POSITION"] + "\t " + dr["RESIDENCE"]);
                            }

                            Console.WriteLine(); Console.WriteLine();
                            #endregion ************* end case 2 *************
                            break;

                        case "3":
                            #region ****************** case 2 ******************
                            int[] numbers = { 1, 3, 4, 6, 5, 9, 8, 12, 15, 18, 17, 11, 22 };
                            var data = from num in numbers
                                       where num % 2 == 0
                                       orderby num
                                       select num;

                            foreach (var i in data)
                            {
                                Console.Write("{0} ", i);
                            }
                            Console.WriteLine(); Console.WriteLine();
                            #endregion ************* end case 3 *************
                            break;

                        default: Console.WriteLine("※※※※ 잘못된 선택입니다. 다시 입력하세요.");            break;
                    }

                }
            }
            

        }




        



        public class Solution
        {

            /// <summary>
            /// 문항 선택 Main
            /// </summary>
            /// <returns>사용자로부터 입력받은 string 반환</returns>
            public string solutionMain()
            {
                string s_conditionCheck = string.Empty;
                Console.WriteLine("********* 문항을 선택하십시오. 프로그램을 종료하시려면 'Q'를 입력하십시오. *********");
                Console.WriteLine("[1] K번째 수");
                Console.WriteLine("[2] LINQ 예제");
                Console.WriteLine("[3] LINQ 예제(2)");

                Console.WriteLine();
                Console.Write("선택 : ");
                s_conditionCheck = Console.ReadLine();
                Console.WriteLine("********************************************************************************");
                Console.WriteLine();

                return s_conditionCheck;
            }




            /// <summary>
            /// K번째 수
            /// </summary>
            /// <param name="array">1차원 배열</param>
            /// <param name="commands">2차원 배열(시작위치, 끝위치, 검색위치)</param>
            /// <returns>최종 검색 위치</returns>
            public int[] Multiple_Get(int[] array, int[,] commands)
            {
                int commandCount = commands.Length / 3;                 // 커맨드 개수
                int[] answer = new int[commandCount];                   // 반환할 정답 개수로 초기화

                int[] i_newArr;

                for (int i = 0; i < commandCount; i++)
                {
                    int i_startIdx  = Convert.ToInt32(commands[i, 0].ToString());
                    int i_endIdx    = Convert.ToInt32(commands[i, 1].ToString());
                    int i_searchIdx = Convert.ToInt32(commands[i, 2].ToString());
                    int newArrCnt = i_endIdx - i_startIdx + 1;              // 추출할 array Size
                    i_newArr = new int[newArrCnt];

                    #region ######### 1. 신규 배열 추출 #########
                    for (int j = 0; j < newArrCnt; j++)
                    {
                        i_newArr[j] = array[i_startIdx - 1 + j];
                    }
                    #endregion #################################

                    // 2. 배열 Sorting
                    Array.Sort(i_newArr);
                    answer[i] = i_newArr[commands[i, 2] - 1];
                }


                return answer;
            }


            /// <summary>
            /// LINQ 예제
            /// </summary>
            /// <param name="dt_people">필터링 되지 않은 DataTable</param>
            /// <returns>필터링 후의 DataTable</returns>
            public DataTable WomanFilter_Get(DataTable dt_champion, string s_gender, string s_residence)
            {
                DataTable dt_woman = dt_champion.Clone();

                dt_woman = dt_champion.AsEnumerable().Where(Row => Row.Field<string>("GENDER") == s_gender &&
                                                                               Row.Field<string>("RESIDENCE") == s_residence)
                                                                 .OrderByDescending(Row => Row.Field<int>("SEQ"))
                                                                 .CopyToDataTable();

                return dt_woman;
            }


            /// <summary>
            /// DataTable 초기화
            /// </summary>
            /// <param name="dt_dataTable">타겟 DataTable</param>
            public DataTable InitDataTable(DataTable dt_dataTable)
            {
                dt_dataTable.Rows.Add(1   , "Ahri"        , "W"    , "27"     , "Mage, Slayer"        , "Ionia");
                dt_dataTable.Rows.Add(2   , "Caitlyn"     , "W"    , "32"     , "Marksman"            , "Piltover");
                dt_dataTable.Rows.Add(3   , "Darius"      , "M"    , "46"     , "Fighter, Tank"       , "Noxus");
                dt_dataTable.Rows.Add(4   , "Kayn"        , "M"    , "35"     , "Fighter, Slayer"     , "Ionia");
                dt_dataTable.Rows.Add(5   , "Varus"       , "M"    , "30"     , "Marksman, Mage"      , "Ionia");

                dt_dataTable.Rows.Add(6   , "Rek'Sai"     , "W"    , "None"   , "Fighter, Slayer"     , "Void");
                dt_dataTable.Rows.Add(7   , "Pantheon"    , "M"    , "41"     , "Fighter, Slayer"     , "Targon");
                dt_dataTable.Rows.Add(8   , "Garen"       , "M"    , "46"     , "Fighter, Tank"       , "Demacia");
                dt_dataTable.Rows.Add(9   , "Lucian"      , "M"    , "31"     , "Marksman"            , "Demacia");
                dt_dataTable.Rows.Add(10  , "Galio"       , "M"    , "None"   , "Tank, Mage"          , "Demacia");

                dt_dataTable.Rows.Add(11  , "Vayne"       , "W"    , "32"     , "Marksman, Slayer"    , "Demacia");
                dt_dataTable.Rows.Add(12  , "LeBlanc"     , "W"    , "28"     , "Mage, Slayer"        , "Noxus");
                dt_dataTable.Rows.Add(13  , "Sion"        , "M"    , "52"     , "Tank, Fighter"       , "Noxus");
                dt_dataTable.Rows.Add(14  , "Diana"       , "W"    , "29"     , "Fighter, Mage"       , "Targon");
                dt_dataTable.Rows.Add(15  , "Ashe"        , "W"    , "31"     , "Marksman, Controller", "Freljord");

                dt_dataTable.Rows.Add(16  , "Vel'Koz"     , "M"    , "None"   , "Mage"                , "Void");
                dt_dataTable.Rows.Add(17  , "Maokai"      , "M"    , "None"   , "Tank, Mage"          , "Shadow Isles");
                dt_dataTable.Rows.Add(18  , "Kalista"     , "W"    , "24"     , "Marksman"            , "Shadow Isles");
                dt_dataTable.Rows.Add(19  , "Lulu"        , "W"    , "98"     , "Controller, Mage"    , "Bandle City");
                dt_dataTable.Rows.Add(20  , "Rumble"      , "M"    , "24"     , "Fighter, Mage"       , "Bandle City");

                dt_dataTable.Rows.Add(21  , "Vi"          , "W"    , "34"     , "Fighter, Slayer"     , "Piltover");
                dt_dataTable.Rows.Add(22  , "Jinx"        , "W"    , "22"     , "Marksman"            , "Zaun");
                dt_dataTable.Rows.Add(23  , "Ezreal"      , "M"    , "28"     , "Marksman, Mage"      , "Piltover");
                dt_dataTable.Rows.Add(24  , "Thresh"      , "M"    , "49"     , "Controller, Fighter" , "Shadow Isles");
                dt_dataTable.Rows.Add(25  , "Katarina"    , "W"    , "32"     , "Slayer, Mage"        , "Noxus");

                return dt_dataTable;
            }


        }



    }
}
