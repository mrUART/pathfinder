using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pathfinder
{
    
    class Program  
    {
        static string MapBuilder(int desiredFloor, int desiredSection, int startingFloor, int startingSection) // Это все конечно же безумный костыль, и не имеет четкого соответствия тестовому заданию, но я очень старался)
        {
            string fastestPath = "";  // обьявленна переменная которую будет выдавать метод
            int minToCrossSectionByElev = 1;  // все переменные объявленные тут созданны для большей информативности
            int elevatorWaitingTime = 1;
            int minPerFloorBySteps = 2;
            int stairTime = minPerFloorBySteps*(Math.Abs(desiredFloor-startingFloor));  
            int minPerFloorByElevator = 1;
            
            int elevator1SectionNumberIs = 1;  // я понимаю что не очень правильно использовать такие параметры, но в данном случае они очень удобны.
            int elevator2SectionNumberIs = 2;
            int elevatorTime = 0;

            if ((desiredFloor % 2) == 0 && desiredFloor != 0)
            {
                elevatorTime = (Math.Abs(desiredFloor - startingFloor) * minPerFloorByElevator + elevatorWaitingTime + Math.Abs(elevator1SectionNumberIs - startingSection) * minToCrossSectionByElev + Math.Abs(elevator1SectionNumberIs - desiredSection) * minToCrossSectionByElev);
                fastestPath = "E1";
            }
            if ((desiredFloor % 2) != 0 && desiredFloor != 0)
            {
                elevatorTime = (Math.Abs(desiredFloor - startingFloor) * minPerFloorByElevator + elevatorWaitingTime + Math.Abs(elevator2SectionNumberIs - startingSection) * minToCrossSectionByElev + Math.Abs(elevator2SectionNumberIs - desiredSection) * minToCrossSectionByElev);
                fastestPath = "E2";
            }
            if (desiredFloor == 0) // не уверен что эта часть необхолдима, но на инфографике оба лифта могут приезжать на 0й этаж
            {
                int elevator1ToZeroFloorTime = (Math.Abs(desiredFloor - startingFloor) * minPerFloorByElevator + elevatorWaitingTime + Math.Abs(elevator1SectionNumberIs - startingSection) * minToCrossSectionByElev + Math.Abs(elevator1SectionNumberIs - desiredSection) * minToCrossSectionByElev);
                int elevator2ToZeroFloorTime = (Math.Abs(desiredFloor - startingFloor) * minPerFloorByElevator + elevatorWaitingTime + Math.Abs(elevator2SectionNumberIs - startingSection) * minToCrossSectionByElev + Math.Abs(elevator2SectionNumberIs - desiredSection) * minToCrossSectionByElev);
                if (elevator1ToZeroFloorTime > elevator2ToZeroFloorTime)
                {
                    elevatorTime = elevator2ToZeroFloorTime;
                    fastestPath = "E2";
                }
                if (elevator1ToZeroFloorTime < elevator2ToZeroFloorTime)
                {
                    elevatorTime = elevator1ToZeroFloorTime;
                    fastestPath = "E1";
                }
                if (elevator1ToZeroFloorTime == elevator2ToZeroFloorTime)
                {
                    elevatorTime = elevator2ToZeroFloorTime;
                    fastestPath = "E2 or E1";
                }

            }
            if (stairTime <= elevatorTime)
            {
                fastestPath = "S";
            }

            return fastestPath;


        }
        static void Main(string[] args)
        {
            int defFloor = 0;
            int defSec = 1;
            int _desiredFloor;
            int _desiredSection;
            Console.WriteLine("Enter planned floors and sections."); // наверное более правильно собирать и выдавать данные в виде массива, но я уже не успею.
            while (true)
            {
                Console.Write("Desired Floor: ");
                string dFloor = (Console.ReadLine());
                int anyparsedstuffloor;
                if (int.TryParse(dFloor, out anyparsedstuffloor)&& anyparsedstuffloor < 6 && anyparsedstuffloor >= 0)
                {
                    _desiredFloor = anyparsedstuffloor;
                    Console.WriteLine();
                
                }
                else
                {
                    Console.WriteLine("Wrong floor input");
                    continue;
                }
                Console.Write("Desired Section: ");
                string dSection = (Console.ReadLine());
                int anyparsedstuffSection;
                if (int.TryParse(dSection, out anyparsedstuffSection) && anyparsedstuffSection < 3 && anyparsedstuffSection >= 1)
                {
                    _desiredSection = anyparsedstuffSection;
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Wrong section input");
                    continue;
                }
                Console.WriteLine(MapBuilder(_desiredFloor, _desiredSection, defFloor, defSec));
                defFloor = _desiredFloor;
                defSec = _desiredSection;



            }
            
            

            
        }
    }
}
