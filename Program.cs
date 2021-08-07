using System;
using System.Threading;
using Create_Delete_Profile_test.Create_Delete_Profile;
using Create_Delete_Profile_test.Interfaces;
using static System.Console;

namespace Create_Delete_Profile_test
{
    class Program
    {
        static void Main()
        {
            IMetode objStart = new CreateAcc();
            IMetode objDelAcc = new DeleteProfile();
            
            objStart.InitCreateDelAcc();
            objStart.ResultsAll();
            WriteLine("Start next test case");
            ReadKey();
            WriteLine("");

            objStart.InitCreateDelAccHalfData();
            objStart.ResultsIncomplete();
            WriteLine("Start next test case");
            ReadKey();
            WriteLine("");

            objDelAcc.InitCreateDelAcc();
            objDelAcc.ResultsAll();

        }
    }
}
