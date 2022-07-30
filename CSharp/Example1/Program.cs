using System;
// 1. Orc 클래스 작성
//     멤버변수 : 이름, 키, 몸무게, 나이, 성별문자, 컨트롤가능한지여부
//     멤버 함수 : 휘두르기(Smash), 점프하기(Jump) (콘솔창에 휘둘렀다 /점프했다 등의 출력만 함)
// 2. Orc 객체 생선하는 코드 작성
//    메인함수 내에 오크 객체 두개 생성
// 3. Orc 객체 멤버 변수 값 할당하는 코드작성
//    첫번째호크
//    이름 : 상급오크
//    키 : 240f
//    몸무게 : 200f
//    나이 : 3
//    성별문자 : 남
//    컨트롤가능여부 : Y
//    두번째호크
//    이름 : 하급오크
//    키 : 300f
//    몸무게 : 150f
//    나이 : 21
//    성별문자 : 여
//    컨트롤가능여부 : N
// 4. 오크 객체 멤버 함수 호출하는 코드 작성
//    상급오크는 휘두르기, 하급오크는 점프하기를 메인함수에서 실행
//   출력예시 : 상급오크가 (이)가 휘둘렀다....!
//              하급오크가 (이)가 점프했다....!
namespace Example1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc orc1 = new Orc("상급오크", 240.0f, 200.0f, 3, '남', true);
            Orc orc2 = new Orc("하급오크", 300.0f, 150.0f, 21, '여', false);
            orc1.Smash();
            orc2.Jump();

            Console.WriteLine(orc1._name);
            Console.WriteLine(Orc._tribe);
            Orc.PrintTribe();
        }
    }
    public class Orc
    {
        public static string _tribe;

        public string _name;   // public : 외부에서 접근/호출 가능. 
        private float _height;
        private float _weight;
        private int _age;
        private char _gender;
        private bool _controllable;


        //생성자
        public Orc()
        {

        }
        //함수 오버로딩
        //동일함 이름이어도 다른 파라미터를 가지는 함수들에 대해서 정의할 수 있는 기능
        //객체지향컨셉의 다형성 요소 중 하나
        public Orc(string name, float height, float weight, int age, char gender, bool controllable)
        {
            //this._tribe=tribe 는 못함!   _tribe=tribe 만 가능.  static 때문에
            //private ---: 인스턴스의 멤버변수 ,   public --- : 클래스의 멤버변수
            //메인함수에서 출력할때 : Console.WriteLine(orc1._name); Console.WriteLine(Orc._tribe);
            this._name = name;
            this._height = height;
            this._weight = weight;
            this._age = age;
            this._gender = gender;
            this._controllable = controllable;
            

        }


        public void Smash()
        {
            Console.WriteLine($"{this._name} (이)가 휘둘렀다..!");
        }
        
       
        //_name앞에 this 생략되어있음.
        // this 키워드 : 객체 자기자신의 참조 반환하는 키워드
        public void Jump()
        {
            Console.WriteLine($"{this._name} (이)가 점프했다..!");
        }
    
        //static 함수는 인스턴스를 통해서 호출할 수 있는 함수가 아님. 클래스를 통해서 호출함.
        public static void PrintTribe()
        {
            Console.WriteLine(_tribe); //this 못씀.
        }
    }

}
