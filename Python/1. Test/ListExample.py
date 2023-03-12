# 1. List 기본
# list1 = [1, 2, 3, 4, 5]             # List
# list2 = ['abc', 'def', 3, 4, 5, 6]  # List(타입이 다른 데이터도 넣을수가 잇네..?)
# print(list1, list2)
# tp1 = (1, 2, 3, 4, 5)                # Tuple
# print(tp1)



# 2. 문자열 List
# str1 = 'hello world'
# print(list(str1))

# str2 = 'hello word nice weather'
# strArr = str2.split()
# print(strArr)


# 3. List 슬라이싱
# list1 = [1, 2, 3, 4, 5, 6]
# print(list1[2])
# print(list1[-1])                # 음수 인덱스도 되네...?? ㄷ

# a = [1, 2, 3, 4, 5, 6, 7, 8]
# print(a[4:7])                   # 4번 index ~ 7번 index까지 . 그런데 맨 뒤 index는 포함하지 않음(그래서 8이 안나오는거)
# print(a[:7])                    # 맨 앞 ~ index 7까지
# print(a[3:])
# print(a[:])

# print(a[1:7:2])                 # 세 번째 콜론 : 건너뛰는 개수(1이면 2, 3, 4..., 2이면 2, 4, 6...)


# -------------------------------------------------------------------------------------- #


# 4. List함수 
# a = [1, 2, 3, 4, 5]
# a.append(10)
# print(a)                        # List의 맨 끝에 값 추가

from audioop import reverse


a = [1, 2, 3, 4, 5]
b = [6, 7, 8, 9, 10]
# a.append(b)                      # 요렇게하면 b List가 통으로 하나의 index로 추가됨
# a.extend(b)                      # a += b도 동일한 표현식
# a.insert(1, 40)                  # 앞 : index, 뒤 : 값
# a.remove(3)                      # 값으로 삭제
# c = a.pop(0)                     # 지정된 index 삭제 or 마지막 index 삭제(삭제하는 원소 type return)
# a.index(3)                       # 지정돤 value의 index 반환


a = [1, 2, 3, 4, 5, 10]
b = 1
c = b in a                         # a 안에 b 존재 여부 확인(T or F) >> 완전 python 스러운 코드...bb

a = [9, 10, 7, 19, 1, 2, 20, 21, 7, 8]
b = sorted(a)                      # asc
a.sort()                           # asc
a.sort(reverse=True)               # desc



