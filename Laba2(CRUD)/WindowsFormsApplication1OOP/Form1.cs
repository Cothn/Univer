using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace CRUD_OOP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<object> ObjectList = new List<object>();

        // Все пользовательские типы
        /*
        private List<Type> AllTypeObjList = new List<Type>()
        {
            typeof(pilot),
            typeof(AirCraft),
            typeof(Helicopter),
            typeof(SailsShip),
            typeof(MotorShip),
            typeof(Train),
            typeof(RacingCar),
            typeof(CargoCar)
        };
        */
        private List<Type> AllTypeObjList = Assembly.GetAssembly(typeof(UserClass)).GetTypes().Where(type => type.IsSubclassOf(typeof(UserClass))).ToList();

        private void Form1_Load(object sender, EventArgs e)
        {
            ListView1.MultiSelect = false;

            // Создаем список выбора обьекта
            foreach (var obj in AllTypeObjList)
            {
                ObjectList.Add(obj.GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes)); //первичный набор классов
                ObjectBox.Items.Add(obj.Name);
            }
            ObjectBox.SelectedIndex = 0;
            ObjectBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ListRedraw(ListView1, ObjectList);
        }

        private void Create_Click(object sender, EventArgs e)
        {
            //Вызов конструктора выбранного обьекта
            ObjectList.Add(AllTypeObjList[ObjectBox.SelectedIndex].GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes));
            ListRedraw(ListView1, ObjectList);
            ListViewItem LVI = ListView1.Items[(ObjectList.Count - 1)];
            if (LVI != null)
            {
                ListView1.Focus();
                LVI.Selected = true;
                Edit.PerformClick();
            }
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
            Form EForm = new ObjectForm(Obj, ObjectList);
            EForm.ShowDialog();
            EForm.Dispose();

            ListRedraw(ListView1, ObjectList);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if ((ListView1.SelectedIndices.Count != 0) && (ListView1.SelectedIndices[0] < ObjectList.Count))
            {
                int itemNum = ListView1.SelectedIndices[0];

                //список объектов которые могут использовать удаляемый обьект
                var ownerList = ObjectList.Where(item => (item.GetType().GetFields().Where(field => (field.FieldType == ObjectList[itemNum].GetType()))).ToList().Count > 0);
                foreach (var owner in ownerList)
                {
                    foreach (var field in owner.GetType().GetFields().Where(field => (field.FieldType == ObjectList[itemNum].GetType())).ToList())
                    {
                        if (field.GetValue(owner) != null)
                        {
                            if (field.GetValue(owner).Equals(ObjectList[itemNum]))
                            {
                                field.SetValue(owner, null);
                            }
                        }
                    }
                }

                //Непосредственное удаление обьекта
                ObjectList.Remove(ObjectList[itemNum]);
            }
            ListRedraw(ListView1, ObjectList);
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
                    var ObjIdentiferField = ObjectList[i].GetType().GetField("Identifer");
                    ObjSerialNumber = ObjIdentiferField.GetValue(ObjectList[i]);
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
