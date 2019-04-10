using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1OOP
{
    public class AllUserClass
    {   public string Identifer;
        public AllUserClass()
        {
            Identifer = "XXX";
        }
    }
    public class Transport : AllUserClass
    {
        public string SerialNumber;
        public string Name;
        public int AvrSpeed;
        public int Weight;
        private int NumOfPlaces;
        public int maxSpeed;
        public int dlin;
        public int width;
        public int heigh;
        public int MaxWeighOfCargo;
        private static string TransType = "";

        virtual public string getTransportType()
        {
                return TransType;
        }
        //конструктор 0
        public Transport()
        {
            SerialNumber = "XXX";
            Name = "noname";
        }

        public int getNumOfPlaces()
        {
            return NumOfPlaces;
        }
        public void setNumOfPlaces(int Num)
        {
            NumOfPlaces = Num;
        }
    }

    public class AirTransport : Transport
    {
        public int AvrFlightHeight;
        public bool NeadOfRanway;
        public int minFlightHeight;
        public int MaxDistance;
        private static string TransType = "Air";

        //конструктор
        public AirTransport()
        {

        }
        override public string getTransportType()
        {
                return TransType;
        }
    }

    public enum TPilotClass { SPL = 0, PPL = 1, CPL, ATPL, CFI};
    public class pilot : AllUserClass
    {
        public string name;
        public int KolOfArraiv;
        public int HoursOfFlight;
        public TPilotClass PilotClass;
        public string SerialNumber;
        public pilot()
        {
            name = "Иван";
            PilotClass = (TPilotClass)0;
            SerialNumber = "XXX";
        }
    }

    public class AirCraft : AirTransport
    {
        //public pilotRq PilotReq;
        public int PilotMinKolOfArraiv;
        public int PilotMinHoursOfFlight;
        public TPilotClass RequiredPilotClass;
        public pilot FirstPilot;
        public pilot Copilot;
        public int MaxVerticalAngle;
        public int maxFlightHeight;
        public int HeigAclerationSpeed;
        public int SpeedAclerationTime; //time to 100km/h
        private static string TransType = "-AirCraft";

        //конструктор
        public AirCraft()
        {
            RequiredPilotClass = (TPilotClass)0;
        }
        //public int getMaxFlightHeight()
        //{
        //    return maxFlightHeight;
        //}
        //public void setMaxFlightHeight(int FlightHeight)
        //{
        //    maxFlightHeight = FlightHeight;
        //}

        override public string getTransportType()
        {
            return base.getTransportType() + TransType;
        }
        //public bool Podh()
        //{
        //    return true;
        //}
    }

    public class Helicopter : AirTransport
    {
        public int LiftingSpeed;
        public int TimeSpidAcleration;
        public bool weapon;
        private static string TransType = "-Helicopter";

        //конструктор
        public Helicopter()
        {

        }

        public override string getTransportType()
        {
            return base.getTransportType() + TransType;
        }
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
        public int MaxWeighInDeadweight;
        public float DeadweightSize;
        public int Draught;
        public int Crew;
        private static string TransType = "Water";
        public WaterTransport()
        {

        }

        public override string getTransportType()
        {
                return TransType;
        }
        public float getSizeOfShip()
        {
            return base.dlin * base.width * base.heigh;
        }
    }

    public class SailsShip : WaterTransport
    {
        public int SailsArea;
        public byte WindAngle;
        public int MastHeigh;
        private static string TransType = "-SailsShip";

        //конструктор
        public SailsShip()
        {

        }
        public override string getTransportType()
        {
            return base.getTransportType() + TransType;
        }
    }
    public class MotorShip : WaterTransport
    {
        public int MoterPower;
        public int FuelConsumption;
        private static string TransType = "-MotorShip";

        //конструктор
        public MotorShip()
        {

        }

    }

    public enum TFuelType { Craft = 0, Аи_80 = 1, Аи_92, Аи_95, Аи_98, ДТ, Газ, Электричество};
    public class LandTransport : Transport
    {
        public int NumOfWheel;
        public TFuelType FuelType;
        private static string TransType = "Land";

        //конструктор 0
        public LandTransport()
        {
            FuelType = (TFuelType)0;
        }

        override public string getTransportType()
        {
                return TransType;
        }
    }

    public class Train : LandTransport
    {
        public int kolOfRailwayAxle;
        private int MaxTimeOfJob;
        private static string TransType = "-Train";
        public Train()
        {
            FuelType = (TFuelType)7;
        }
        override public string getTransportType()
        {
            return base.getTransportType() + TransType;
        }
        public float getSizeOfTrain()
        {
            return base.dlin * base.width * base.heigh;
        }
        public int getMaxTimeOfJob()
        {
            return MaxTimeOfJob;
        }
        public void setMaxTimeOfJob(int BMaxTimeOfJob)
        {
            MaxTimeOfJob = BMaxTimeOfJob;
        }
    }

    public class Car : LandTransport
    {
        public int Clerance;
        public int WheelDiameter;
        public int MoterPower;
        public int FuelConsumption;
        private static string TransType = "-Car";
        public Car()
        {

        }
        override public string getTransportType()
        {
            return base.getTransportType() + TransType;
        }
    }

    public class RacingCar : Car
    {
        public int TimeSpidAcleration;
        private static string TransType = "-Racing";
        public RacingCar()
        {

        }
        override public string getTransportType()
        {
            return base.getTransportType() + TransType;
        }
    }

    public class CargoCar : Car
    {
        public bool Pricep;
        public int MaxPricepWEigh;
        public int MaxDistance;
        private static string TransType = "-Cargo";
        public CargoCar()
        {

        }
        public override string getTransportType()
        {
            return base.getTransportType() + TransType;
        }
        public float getSize()
        {
            return base.dlin * base.width * base.heigh;
        }
    } 

}
