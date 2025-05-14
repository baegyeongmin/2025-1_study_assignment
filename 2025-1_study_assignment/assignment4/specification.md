# Assignment 4

기초 스터디 4차시 C# 프로그래밍 기초에 대한 과제입니다.

명세를 잘 읽어보시고, example output을 참고하여 구현해주세요.

4-1, 4-2, 4-3 중 2개의 과제만 제출하시면 됩니다.

<br/>

TODO 파트를 구현하여 제출하세요.

TODO 이외의 부분은 수정하지 말아주세요.

<br/>

online gcc를 이용하여 실행해볼 수 있습니다. (C#을 선택하세요.)

: https://www.onlinegdb.com/online_c_compiler

<br/>

제출 시에는 스터디장의 안내에 따라 정해진 branch에 push해주세요.

4-1, 4-2, 4-3 중 2개의 과제만 제출하시면 됩니다.

## Assignment 4-1 Calculator

계산기를 구현하는 문제입니다.

### input

입력은 (num1) (op) (num2) 형태로만 주어집니다.

Parser는 제공됩니다.

<br/>

Calculator 클래스에

public double Calculate(double num1, string op, double num2);

함수를 구현하시면 됩니다.

### output

+, -, *, / 연산에 대한 결과를 출력합니다.

<br/>

유효하지 않은 연산자에 대해 InvalidOperationException을 반환합니다.

throw new InvalidOperationException("Invalid operator");

<br/>

/ 연산에서 DivideByZeroException을 반환합니다.

throw new DivideByZeroException("Division by zero is not allowed");

### CHALLANGE

새로운 연산이 추가됩니다. 형변환이 필요할 시 명시적 형변환을 사용합니다.
<br/>

(double)a ** (int)b

: a의 b제곱을 반환합니다. b는 정수라 가정하고, 음수도 가능합니다.

(int)a % (int)b

: a를 b로 나눈 나머지를 반환합니다. a, b는 정수라 가정합니다.

(int)a G (int)b

: a와 b의 최대공약수를 반환합니다. a, b는 정수라 가정합니다.

(int)a L (int)b

: a와 b의 최소공배수를 반환합니다. a, b는 정수라 가정합니다.

## Assignment 4-2 Star

별찍기로 C# 모양을 만드는 문제입니다.

### input

입력 radius는 C라는 글자의 반지름입니다.

한 글자는 정사각형으로 표현되며, size는 한 변의 길이입니다.

### output

한 글자는 정사각형으로 표현되며

'*', ' ', '\n' 세 가지 문자만 사용하여 나타냅니다.

<br/>

C는 3개의 변으로 나타나며, radius는 정사각형의 중심에서 한 변까지의 거리입니다.

#은 4개의 선분으로 나타나며, 선분의 길이는 size, 선분의 위치는 정사각형을 삼등분하는 지점입니다.

### CHALLANGE

챌린지 버전으로 구현하여도 과제로 인정되며, 필수는 아닙니다.

<br/>

C는 radius를 반지름으로 하는 원의 우측 10% 만큼을 잘라내어 만듭니다.

#은 4개의 선분으로 나타나며, 가로선은 정사각형을 삼등분하는 지점에, 세로선은 기울기가 -5인 직선으로 나타납니다.

세로선의 중앙은 정사각형을 삼등분하는 지점을 지납니다.

## Assignment 4-3 Statistics

학생의 점수 데이터를 이용하여 통계를 내는 문제입니다.

### input

입력은 2차원 배열로 주어지며, data[row, column]으로 접근할 수 있습니다.

double.Parse(str)을 이용하여 string을 double로 변경할 수 있습니다.

<br/>

첫 번째 행은 각 열의 헤더를 포함합니다.

두 번째 행부터 학생의 점수와 관련된 데이터가 주어집니다.

stdCount는 총 학생 수입니다.

### output

세 가지 정보를 출력합니다.

1. 각 과목의 평균 점수
2. 각 과목의 (최대, 최소) 점수
3. 학생 이름과 총점에 따른 등수

<br/>

출력 형식은 example output을 참고해주세요.