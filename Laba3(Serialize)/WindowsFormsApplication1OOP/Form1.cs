using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;

namespace CRUD_OOP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private int ClassId = 1;

        private List<Object> ObjectList = new List<Object>();

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
        //private List<Type> AllList = Assembly.GetAssembly(typeof(TransportSerialize)).GetTypes().Where(type => type.IsSubclassOf(typeof(TransportSerialize))).ToList();

        private List<string> SerialList = new List<string>()
        {
            "json",
            "jcot",
            "bin"

        };


        private void Form1_Load(object sender, EventArgs e)
        {
            ListView1.MultiSelect = false;
            // Типы

            foreach (var ser in SerialList)
            {
                SerializeBox.Items.Add(ser);
            }
            SerializeBox.SelectedIndex = 0;
            SerializeBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // Создаем список выбора обьекта
            foreach (var obj in AllTypeObjList)
            {
                ObjectList.Add(obj.GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes)); //первичный набор классов
                ObjectBox.Items.Add(obj.Name);
            }
            ObjectBox.SelectedIndex = 0;
            ObjectBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ListRedraw(ListView1, ObjectList);

            //плагины
            string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
            DirectoryInfo pluginDirect = new DirectoryInfo(pluginPath);
            if (!pluginDirect.Exists)
            { pluginDirect.Create(); }

            //берем все dll
            var pluginFiles = Directory.GetFiles(pluginPath, ".dll");
            foreach(var file in pluginFiles)
            {
                //загружаем сборку
                Assembly asm

            }

        }

        private void Create_Click(object sender, EventArgs e)
        {
            //Вызов конструктора выбранного обьекта
            ObjectList.Add(AllTypeObjList[ObjectBox.SelectedIndex].GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes));
            Form EForm = new ObjectForm(ObjectList[(ObjectList.Count - 1)], ObjectList);
            EForm.ShowDialog();
            EForm.Dispose();
            ListRedraw(ListView1, ObjectList);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //получаем индекc выделенного пункта
            int itemNum;
            if (ListView1.SelectedIndices.Count != 0)
                itemNum = ListView1.SelectedIndices[0];
            else
                return;

            //Создаем форму редактирования обьекта
            Form EForm = new ObjectForm(ObjectList[itemNum], ObjectList);
            EForm.ShowDialog();
            EForm.Dispose();

            ListRedraw(ListView1, ObjectList);
        }

        // метод удаления обьектов
        private void Delete_Action(Object DelObject, List<object> ObjectList)
        {
            //удаление
            //список объектов которые могут использовать удаляемый обьект
            var ownerList = ObjectList.Where(item => (item.GetType().GetFields().Where(field => (field.FieldType == DelObject.GetType()))).ToList().Count > 0);
            foreach (var owner in ownerList)
            {
                foreach (var field in owner.GetType().GetFields().Where(field => (field.FieldType == DelObject.GetType())).ToList())
                {
                    if (field.GetValue(owner) != null)
                    {
                        if (field.GetValue(owner).Equals(DelObject))
                        {
                            field.SetValue(owner, null);
                        }
                    }
                }
            }

            //Непосредственное удаление обьекта
            ObjectList.Remove(DelObject);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if ((ListView1.SelectedIndices.Count != 0) && (ListView1.SelectedIndices[0] < ObjectList.Count))
            {
                int itemNum = ListView1.SelectedIndices[0];

                Delete_Action(ObjectList[itemNum], ObjectList);
            }
            ListRedraw(ListView1, ObjectList);
        }

        //Перерисовка списка объектов в соответсвии со списком обьектов
        private void ListRedraw(ListView listView, List<Object> ObjectList)
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

        private void SaveButt_Click(object sender, EventArgs e)
        {
            TransportSerialize TSerial;
            switch (SerializeBox.SelectedIndex)
            {
                case 0:
                    TSerial = new JsonSerial();
                    break;

                case 1:
                    TSerial = new JcotSerial();
                    break;

                default:
                    TSerial = new BinSerial();
                    break;
            }

            saveFileDialog1.Filter = SerialList[SerializeBox.SelectedIndex] + " files(*"+ TSerial.FileExtens + ") | *" + TSerial.FileExtens + "|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            FileStream fs = new FileStream(filename, FileMode.Create);
            TSerial.Serialize(fs, ObjectList);
            fs.Close();
            MessageBox.Show("Файл сохранен");
        }

        private void LoadButt_Click(object sender, EventArgs e)
        {
            TransportSerialize TSerial;
            switch (SerializeBox.SelectedIndex)
            {
                case 0:
                    TSerial = new JsonSerial();
                    break;

                case 1:
                    TSerial = new JcotSerial();
                    break;

                default:
                    TSerial = new BinSerial();
                    break;
            }

            openFileDialog1.Filter = SerialList[SerializeBox.SelectedIndex] + " files(*" + TSerial.FileExtens + ") | *" + TSerial.FileExtens + "|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            //string fileExtens = null;

            ////если переключили фильтр
            //if (openFileDialog1.FilterIndex != 0)
            //{
            //    int i = filename.Length -1;
            //    fileExtens = "";
            //    do
            //    {
            //        fileExtens = filename[i] + fileExtens;
            //        i--;
            //    } while (fileExtens[0] != '.');
            //    switch (SerializeBox.SelectedIndex)
            //    {
            //        case 0:
            //            TSerial = new JsonSerial();
            //            break;

            //        case 1:
            //            TSerial = new JcotSerial();
            //            break;

            //        case 2:
            //            TSerial = new BinSerial();
            //            break;
            //        default:
            //            break;
            //    }

            //}
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            ObjectList = (List<Object>)TSerial.DeSerialize(fs);
            fs.Close();
            ListRedraw(ListView1, ObjectList);
            MessageBox.Show("Файл загружен");
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
