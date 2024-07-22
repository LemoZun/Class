using System.Drawing;

namespace Class
{
    internal class Program
    {


        /*
         * 구조체는 값형식, 클래스는 참조
         * 객체지향의 4대 특징
         * 캡슐화 : 객체가 구동되기 위한 데이터와 동작을 객체 자신이 가질 수 있음, 불필요한 데이퍼 변질을 막기 위해 필요한 부분만 노출
         * 상속 : 하위객체가 상속받은 상위 객체에서 정의된 필드와 메서드를 활용해 반복적인 코드 최소화, 공유속성에 쉽게 접근함
         * 추상화 : 객체의 중요한 부분을 강조하기 위해 공통적인 속성과 기능을 추출, 불필요한 세부사항 제거하고 객체의 본질적인 부분만 표현
         * 다형성 : 속성과 기능이 상황에 따라 여러가지 형태를 가질 수 있음
         * 
         * SOLID원칙
         * S : 단일 책임 원칙 : 클래스는 단 하나의 책임만 가져야 한다.
         * O : 개방 폐쇄 원칙 : 확장에 열려있어야 하고 수정에는 닫혀있어야 한다.
         * L : 리스코프 치환 원칙 : 자식 객체는 언제나 부모 타입으로 교체될 수 있어야 한다.
         * I : 인터페이스 분리 원칙 : 하나의 큰 인터페이스 보다 용도에 맞는 인터페이스를 잘게 분리해야 한다.
         * D : 의존 역전 원칙 : 고수준의 모듈은 저수준 모듈의 구현에 의존해서는 안된다.
         * 
         * 변수의 접근 범위와 생존 범위
         *      
                       │ 메모리영역 │ 접근 범위     │ 생존 범위
            ─────────  ┼────────────┼──────────── ┼───────────────────────────
            정적변수    │ 데이터영역  │ 모든 범위   │ 프로그램 시작에서 끝까지
            ────────   ┼────────────┼────────────┼───────────────────────────
            지역변수    │ 스택영역   │ 블록 내부   │ 블록 시작에서 끝까지
            매개변수    │            │            │
            ───────────┼────────────┼────────────┼───────────────────────────
            클래스      │ 힙영역     │ 참조가능한  │ 인스턴스 생성에서
            인스턴스    │            │ 모든 범위  │ 더이상 사용하지 않을때까지

         * 
         * 힙 영역 
         * 클래스 인스턴스가 보관하는 영역
         * 프로그램은 가비지 콜렉터를 통해 더이상 사용하지 않는 인스턴스를 추가함
         */
        class HeapClass { }

        
            // 함수 시작시
            // 지역변수 local 이 스택 영역에 저장됨

            //HeapClass local;              // 함수 시작시 이미 메모리에 할당되어 있음
            //local = new HeapClass();      // 인스턴스를 힙영역에 생성하고 주소값을 local에 보관

            // 함수 종료시
            // 지역변수 local 이 함수 종료와 함께 소멸됨
            // 인스턴스 new HeapClass() 는 함수 종료와 함께 더이상 참조하는 변수가 없음
            // 인스턴스 new HeapClass() 는 가비지가 되어 가비지 컬렉터가 동작할 때 소멸됨

            /*
                       ┌─────────────┐                   ┌─────────────┐
                       │             │                   │             │
                       │             │              0x56 ├─────────────┤
                       │             │               ┌──→│ HeapClass   │
                       │             │               │   │ 인스턴스     │
                       │             │               │   ├─────────────┤
                       │             │               │   │             │
                       │             │               │   │             │
                       │             │               │   │             │
                       ├─────────────┤               │   ├─────────────┤
                       | local(null) |               └───│ local(0x56) │
            함수시작 →  └─────────────┘   인스턴스 생성 →  └─────────────┘
                                         
                       ┌─────────────┐                   ┌─────────────┐
                       │             │                   │             │
                       ├─────────────┤                   │             │
               더이상  │ HeapClass   │                   │              │
              참조없음 │ 인스턴스     │                    │              │
                       ├─────────────┤                   │             │
                       │             │                   │             │
                       │             │                   │             │
                       │             │                   │             │
                       │             │                   │             │
                       │             │   가비지 콜렉터   │              │
            함수종료 → └─────────────┘       동작시    → └───────────────┘
        */
            /*
             * 데이터 영역
             * 정적 변수를 저장하는 영역
             * 프로그램은 시작시 데이터 영역을 생성하며 종료시 데이터 영역을 해제함
             * 
             * 정적(static)
             * 프로그램의 시작과 함께 할당, 프로그램 종료시에 소멸, 프로그램이 동작하는 동안 항상 고정된 위치에 존재
             * 정적변수 : 클래스의 이름을 통해 접근하는 변수
             * 정적함수 : 클래스의 이름을 통해 접근하는 함수
             * 정적클래스 : 정적변수와 정적함수만을 포함하는 클래스
             * 
             * 
             */
            class Student
        {
            public static int count; // 중추적인 역할을 하는 변수에 씀
            public int id;

            public int GetId()
            {
                Console.WriteLine($"현재 학생 수는 {id} 입니다.");
                return id;
            }


            public static int GetCount()
            {
                Console.WriteLine($"현재 학생 수는 {count} 입니다.");
                return count;
            }
        }
        public static int num;

        static class MyClass
        {
            public static void Foo()
            {
                num++; // a
            }

        }

        struct MyStruct
        {
            public static int num = 10; 
        }



        //static void Main(string[] arg)
        //{
        //    MyClass myClass = new MyClass(); // 정적 클래스의 인스턴스는 만들 수 없음

        //    num = 1;

        //    MyStruct myStruct;

        //    MyStruct.num = 2; 



        //    Student.count = 0; // 시작부터 있어서 객체를 안만들어도 사용 가능 - 클래스 안에 있는 static 변수 
        //                       //


        //    Student student1 = new Student() { id = 1 };
        //    Student student2 = new Student() { id = 2 };
        //    Student student3 = new Student() { id = 3 };
        //    // student1.count 접근 불가

        //    Console.WriteLine($"학생1의 ID : {student1.id}");
        //    Console.WriteLine($"학생2의 ID : {student2.id}");
        //    Console.WriteLine($"학생3의 ID : {student3.id}");

        //    student1.GetId();
        //    Student.GetCount(); // 클래스 이름으로 사용 위는 변수가 함수를 사용함

        //}
        class GameSetting
        {
            public static int volume;
        }
        static class Calculator
        {
            public static double Add(double left, double right) //여러개 만들 필요 없는것
            {
                return left + right;
            }
        }

        /*
         * 클래스 생성자
         * 반환형이 없는 클래스 이름의 함수를 생성자라고 함 클래스의 인스턴스를 만들 때 호출되는 역할로 사용
         * 인스턴스의 생성자는 new 키워드를 통해서 사용
         * 
         */

        class Monster
        {
            public string name;
            public int curHP;
            public int maxHP;

            //public Monster()
            //{
            //    name = "몬스터";
                
            //}
            
            public Monster(string _name, int _maxHP)
            {
                this.name = name; // 클래스 멤버변수를 쓰게할 수 있음
                maxHP = _maxHP;
                curHP = _maxHP;

            }



            public void PrintInfo()
            {
                Console.WriteLine($"{name} 이름의 몬스터 : 체력은 {maxHP}");
            }

            struct Point
            {
                public int x;
                public int y;

                public Point(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
                
            }

           
        }

        static void Main(string[] arg)
        {
            Monster monster = new Monster("슬라임",50);
            monster.PrintInfo();

            Point playerPos = new Point(1,2);
            Point monsterPos = new Point(); // 구조체는 기본생성자는 무조건 만듬
        }

        /*
         * 클래스와 static
         * static은 프로그램이 종료될 때 까지 할당해제 되지 않고 고정된 메모리의 공간을 할당함(메모리상주)
         * 생성자가 없으면 기본생성자는 기본 으로 생성, 매개변수 있는 생성자만 만들면 기본생성자는 비활성화
         * 생성자는 퍼블릭이 아닌 변수도 초기화가 가능하다.
         */



        /*
         * 클래스와 생성자
         * 
         * 
         */

    }


}

