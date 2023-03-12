# 1. Tuple 기초
a = (1, 2, 3)
b = [1, 2, 3]

# a[0] = 0            # Tuple은 안됨(생성 후 변경 불가능)
# b[0] = 0            # List는 값 변경 가능


a, b = (100, 200)     # 변수 동시에 선언 및 init 가능
print(a, b)


# ※ Python은 function 리턴 시 멀티플 리턴이 가능한데, 이는 Tuple을 이용해서 가능함(Tuple 주 사용목적(?))
a = 4
b = 5

a, b = b, a          # 와 이건 다른 언어에서 못보던 신세계네.... 파이썬만 가능?
'''
# a, b 두 값 swap 시
# 일반적인 programming language
temp = a            # 임시 변수 두어서 기존 값 저장
a = b
b = temp
'''
print(a, b)