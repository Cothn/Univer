using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_OOP2
{
    public class UserClass
    {   public string Identifer;
        public UserClass()
        {
            Identifer = "000";
        }
    }
    public class Transport : UserClass
    {
        public string ModelName;
        public int AvrSpeed_Km_h;
        public int Weight_Kg;
        public int NumOfPlaces;
        public int maxSpeed_Km_h;
        public int dlin_m;
        public int width_m;
        public int heigh_m;
        public int MaxWeighOfCargo_Kg;
        //private static string TransType = "Transport";

        //virtual public string getTransportType()
        //{
        //        return TransType;
        //}
        //конструктор 0
        public Transport()
        {
            Identifer = "T0";
            ModelName = "Transport";
            AvrSpeed_Km_h = 50;
            Weight_Kg = 150;
            NumOfPlaces = 1;
            maxSpeed_Km_h = 120;
            dlin_m = 5;
            width_m = 3;
            heigh_m = 2;
            MaxWeighOfCargo_Kg = 75;
        }
    }

    public enum TPilotClass { SPL = 0, PPL = 1, CPL, ATPL, CFI };
    public class pilot : UserClass
    {
        public string name;
        public int KolOfArraiv;
        public int HoursOfFlight;
        public TPilotClass PilotClass;
        public string SertificatSerialNumber;
        public pilot()
        {
            Identifer = "P0";
            name = "Иван";
            SertificatSerialNumber = "PPL000";
            KolOfArraiv = 50;
            HoursOfFlight = 320;
            PilotClass = (TPilotClass)1;

        }
    }
    public class AirTransport : Transport
    {
        public int AvrFlightHeight_m;
        public pilot FirstPilot;
        public pilot Copilot;
        public bool NeadOfRanway;
        public int minFlightHeight_m;
        public int MaxFlightDistance_Km;
        public int HeigAclerationSpeed_s;
        //private static string TransType = "Air";

        //конструктор
        public AirTransport()
        {
            Identifer = "AT0";
            ModelName = "AirTransport";
            AvrFlightHeight_m = 1500;
            NeadOfRanway = true;
            minFlightHeight_m = 600;
            MaxFlightDistance_Km = 700;
            HeigAclerationSpeed_s = 60;
        }
        //override public string getTransportType()
        //{
        //        return TransType;
        //}
    }

    public class AirCraft : AirTransport
    {
        //public pilotRq PilotReq;
        public int PilotMinKolOfArraiv;
        public int PilotMinHoursOfFlight;
        public TPilotClass RequiredPilotClass;
        public int MaxVerticalAngle;
        public int maxFlightHeight_m;
        public int SpeedAclerationTime_s; //time to 100km/h
        //private static string TransType = "-AirCraft";

        //конструктор
        public AirCraft()
        {
            Identifer = "AC0";
            ModelName = "AirCraft";
            PilotMinKolOfArraiv = 50;
            PilotMinHoursOfFlight = 320;
            MaxVerticalAngle = 50;
            maxFlightHeight_m = 2000;
            SpeedAclerationTime_s = 35; 
            RequiredPilotClass = (TPilotClass)0;
        }

        //override public string getTransportType()
        //{
        //    return base.getTransportType() + TransType;
        //}

    }

    public class Helicopter : AirTransport
    {
        public int CirkleSpeed_Kol_m;
        public int VertikalSpeed_Km_h;
        public bool weapon;

        //private static string TransType = "-Helicopter";

        //конструктор
        public Helicopter()
        {
            Identifer = "H0";
            ModelName = "Helicopter";
            CirkleSpeed_Kol_m = 50;
            VertikalSpeed_Km_h = 50;
            weapon = false;
            NeadOfRanway = false;
        }

        //public override string getTransportType()
        //{
        //    return base.getTransportType() + TransType;
        //}
        /*public int getLiftingSpeed()
        {
            return LiftingSpeed;
        }
        //public int getMinFlightHeight()
        //{
        //return minFlightHeight;
        //}
        public void setLiftingSpeed(int Speed)
        {
            LiftingSpeed = Speed;
        }
        public void setMinFlightHeight(int FlightHeight)
        {
            //minFlightHeight = FlightHeight;
        }*/

    }

    public class WaterTransport : Transport
    {
        public float DeadweightSize_m_3;
        public int Draught_m;
        //private static string TransType = "Water";
        public WaterTransport()
        {
            Identifer = "WT0";
            ModelName = "WaterTransport";
            DeadweightSize_m_3 = 500;
            Draught_m = 25;
        }

       // public override string getTransportType()
       // {
        //        return TransType;
        //}
        public float getSizeOfShip()
        {
            return base.dlin_m * base.width_m * base.heigh_m;
        }
    }

    public class SailsShip : WaterTransport
    {
        public int SailsArea_m_2;
        public byte WindAngle;
        public int MastHeigh_m;
        //private static string TransType = "-SailsShip";

        //конструктор
        public SailsShip()
        {
            Identifer = "SS0";
            ModelName = "SailsShip";
            SailsArea_m_2 = 300;
            WindAngle = 50;
            MastHeigh_m = 25;
        }
        //public override string getTransportType()
       // {
        //    return base.getTransportType() + TransType;
        //}
    }
    public class MotorShip : WaterTransport
    {
        public int MoterPower_KJ;
        public int FuelConsumption_l;
        //private static string TransType = "-MotorShip";

        //конструктор
        public MotorShip()
        {
            Identifer = "MS0";
            ModelName = "MotorShip";
            MoterPower_KJ = 500;
            FuelConsumption_l = 500;
        }

    }

    public enum TFuelType { Craft = 0, Аи_80 = 1, Аи_92, Аи_95, Аи_98, ДТ, Газ, Электричество};
    public class LandTransport : Transport
    {
        public int NumOfWheel;
        public TFuelType FuelType;
        //private static string TransType = "Land";

        //конструктор 0
        public LandTransport()
        {
            Identifer = "LT0";
            ModelName = "LandTransport";
            NumOfWheel = 4;
            FuelType = (TFuelType)0;
        }

        //override public string getTransportType()
        //{
        //        return TransType;
        //}
    }

    public class Train : LandTransport
    {
        public int kolOfRailwayAxle;
        public int MaxTimeOfJob_h;
        //private static string TransType = "-Train";
        public Train()
        {
            Identifer = "Tr0";
            ModelName = "Train";
            NumOfWheel = 20;
            kolOfRailwayAxle = 10;
            MaxTimeOfJob_h = 48;
            FuelType = (TFuelType)7;
        }
        //override public string getTransportType()
        //{
        //    return base.getTransportType() + TransType;
        //}
        //public float getSizeOfTrain()
        //{
        //    return base.dlin_m * base.width_m * base.heigh_m;
        //}

    }

    public class Car : LandTransport
    {
        public float Clerance_cm;
        public int WheelDiameter_cm;
        public int MoterPower_KJ;
        public float FuelConsumption_L_100Km;
        //private static string TransType = "-Car";
        public Car()
        {
            Identifer = "C0";
            ModelName = "Car";
            Clerance_cm = 20;
            WheelDiameter_cm = 40;
            MoterPower_KJ = 50;
            FuelConsumption_L_100Km = (float)7.6;
        }
        //override public string getTransportType()
        //{
        //    return base.getTransportType() + TransType;
        //}
    }

    public class RacingCar : Car
    {
        public float CoefStreamlining;
        public float CoefSkid;
        private static string TransType = "-Racing";
        public RacingCar()
        {
            Identifer = "RC0";
            ModelName = "RacingCar";
            CoefStreamlining = (float)0.6;
            CoefSkid = (float)0.7;
        }
        //override public string getTransportType()
        //{
        //    return base.getTransportType() + TransType;
        //}
    }

    public class CargoCar : Car
    {
        public bool Trailer;
        public int MaxTrailerWeigh_Kg;
        public int MaxDistance_Km;
        //private static string TransType = "-Cargo";
        public CargoCar()
        {
            Identifer = "CC0";
            ModelName = "CargoCar";
            Trailer = true;
            MaxTrailerWeigh_Kg = 1000;
            MaxDistance_Km = 2000;
        }
        //public override string getTransportType()
        //{
        //    return base.getTransportType() + TransType;
        //}
        public float getSize()
        {
            return base.dlin_m * base.width_m * base.heigh_m;
        }
    } 

}
