using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApplication1OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<object> ObjectList = new List<object>()
        {
            new pilot()
            {name = "Алексей", SerialNumber = "P1"},
            new AirCraft()
            {SerialNumber = "AC0" },
            new Helicopter()
            {SerialNumber = "H0" },
            new MotorShip()
            {SerialNumber = "MS0" },
            new SailsShip()
            {SerialNumber = "SS0" },
            new Train()
            {SerialNumber = "T0" },
            new RacingCar()
            {SerialNumber = "RC0" },
            new CargoCar()
            {SerialNumber = "CC0" }
        };

        public List<MyCreator> MyCreatorList = new List<MyCreator>() {
            new AirCraftCreator(),
            new HelicopterCreator(),
            new SailsShipCreator(),
            new MotorShipCreator(),
            new TrainCreator(),
            new RacingCarCreator(),
            new CargoCarCreator(),
            new pilotCreator()
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            ListView1.MultiSelect = false;
            // Создаем список выбора обьекта
            foreach (var creator in MyCreatorList)
                ObjectBox.Items.Add(creator.GetType().Name);
            ObjectBox.SelectedIndex = 0;
            ObjectBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ListRedraw( ListView1, ObjectList);
        }

        private void Create_Click(object sender, EventArgs e)
        {
            
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //получаем индекc выделенного пункта
            int itemNum;
            if (ListView1.SelectedIndices.Count != 0)
                itemNum = ListView1.SelectedIndices[0];
            else
                return;

            //Получаем редактируемый объект
            object Obj = ObjectList[itemNum];

            //Получаем список всех полей объекта
            FieldInfo[] fields = Obj.GetType().GetFields(); ;

            //Создаем форму редактирования обьекта
            //СForm = CreateForm(Obj, ObjectList);
            //СForm.ShowDialog();
            //СForm.Dispose();

            ListRedraw(ListView1, ObjectList);
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }
        //Перерисовка списка объектов в соответсвии со списком обьектов
        public void ListRedraw(ListView listView, List<Object> ObjectList)
        {
            listView.Clear();
            for (int i = 0; i < ObjectList.Count; i++)
            {
                var listItem = new ListViewItem();
                Type ObjectType = ObjectList[i].GetType();
                object ObjSerialNumber;
                try
                {
                    var ObjSerialNumberField = ObjectList[i].GetType().GetField("SerialNumber");
                    ObjSerialNumber = ObjSerialNumberField.GetValue(ObjectList[i]);
                }
                catch
                {
                    ObjSerialNumber = "";
                }
                listItem.Text = ObjectType.Name + "  " + ObjSerialNumber;
                listView.Items.Add(listItem);
            }
        }


    }
}
