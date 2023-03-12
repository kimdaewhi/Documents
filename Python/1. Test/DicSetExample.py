# 1. Dictionary 기초
'''
- key와 value를 갖는 데이터 구조
- key는 내부적으로 hash값으로 저장
- 순서를 따지지 않음. 즉, index가 없음
'''

# Dictionary 구조 : { key : value }
a = {'Korea' : 'Seoul', 'Canada' : 'Ottawa', 'USA' : 'Washington D.C'}
b = {0:1, 1:6, 7:9, 8:10}

# print(a['Korea'])       # index가 아닌 key값으로 접근해야 함. value 반환

a['Japan'] = 'Tokyo'      # Dictionary 추가
a['China'] = 'Beijing'
a['Japan'] = 'Kyoto'      # 기존 Key값 Update(같은 key값으로 추가가 안됨)


# 2. Dictionary 업데이트
a = { 'a' : 1, 'b' : 2, 'c' : 3 }
b = { 'a' : 2, 'b' : 4, 'e' : 5 }
a.update(b)              # 2개의 dict 비교하여 value 업데이트. key 없으면 추가함


# 3. Dictionary 삭제(del, pop)
a = { 'a' : 1, 'b' : 2, 'c' : 3 }
# a.pop('b')              # del a['b'] 와 동일
# del a['b']

a.clear()       # dict 비우기


# 4. dict key 존재 여부 확인
a = { 'a' : 1, 'b' : 2, 'c' : 3 }
flag = 'b' in a     # True
# print(a.get('b'))         # get : key가 존재하지 않더라도 오류 반환하지 않음. None 반환
# print(a.keys())           # keys : 모든 key 반환
# print(a.values())         # values : 모든 value 반환
# print(list(a.items()))    # items : dict의 모든 key, value 반환




# 5. set 기초(잘 안씀...)
'''
dictionary에서 key만 활용하는 데이터 구조와 동일
수학에서의 집합과 동일한 개념
'''

a = {1, 1, 2, 3, 3, 4, 1, 5}
# print(a)                # 중목 모두 제거함

a = [1, 1, 2, 3, 3, 4, 1, 5]
b = set(a)
# print(b)

a = { 1, 2, 3 }
b = { 2, 3, 4}
# print(a.union(b))           # 합집합
# print(a.intersection(b))    # 교집합
# print(a.difference(b))      # 차집합
# print(a.issubset(b))        # 부분집합