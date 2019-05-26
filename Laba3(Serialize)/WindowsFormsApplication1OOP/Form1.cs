using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using CompressPluginInterface;

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
        private List<IPlugin> PluginsList;

        private List<TransportSerialize> SerialList = new List<TransportSerialize>()
        {
            new JsonSerial(),
            new JcotSerial(),
            new BinSerial()

        };

        private List<IPlugin> CreatePluginList()
        {
            List<IPlugin> PluginsList = new List<IPlugin>();
            NonePlugin NPlugin = new NonePlugin();
            PluginsList.Add(NPlugin);
            //плагины
            string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
            DirectoryInfo pluginDirect = new DirectoryInfo(pluginPath);
            if (!pluginDirect.Exists)
            { pluginDirect.Create(); }

            //берем все dll
            var pluginFiles = Directory.GetFiles(pluginPath, ".dll");
            foreach (var file in pluginFiles)
            {
                //загружаем сборку
                Assembly asm = Assembly.LoadFrom(file);
                //Ищем типы
                var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(j => j.FullName == typeof(IPlugin).FullName).Any());



                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                    PluginsList.Add(plugin);
                }
            }
            return PluginsList;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListView1.MultiSelect = false;

            // Типы
            foreach (var ser in SerialList)
            {
                SerializeBox.Items.Add(ser.name);
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

            //список плагинов
            PluginsList = CreatePluginList();
            foreach (var plugin in PluginsList)
            {
                PluginsBox.Items.Add(plugin);
            }
            PluginsBox.SelectedIndex = 0;
            PluginsBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            TransportSerialize TSerial = SerialList[SerializeBox.SelectedIndex];
            IPlugin plugin = (IPlugin)PluginsBox.SelectedItem;

            saveFileDialog1.Filter = SerialList[SerializeBox.SelectedIndex] + " files(*"+ TSerial.FileExtens + plugin.FileExtens + ") | *" + TSerial.FileExtens + plugin.FileExtens + "|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            FileStream fileStream = new FileStream(filename + ".temp", FileMode.Create);
            TSerial.Serialize(fileStream, ObjectList);
            fileStream.Flush();

            //Обработка плагином
            fileStream.Seek(0, SeekOrigin.Begin);
            FileStream WriteStream = new FileStream(filename, FileMode.Create);
            plugin.Shifr(fileStream, WriteStream);
            fileStream.Close();
            WriteStream.Close();

            if (plugin.ToString() != "none")
            {
                File.Delete(filename + ".temp");
            }
            else
            {
                File.Delete(filename);
                File.Move(filename + ".temp", filename);
            }

            MessageBox.Show("Файл сохранен");
        }

        private void LoadButt_Click(object sender, EventArgs e)
        {
            TransportSerialize TSerial = SerialList[SerializeBox.SelectedIndex];
            IPlugin plugin = (IPlugin)PluginsBox.SelectedItem;

            openFileDialog1.Filter = SerialList[SerializeBox.SelectedIndex] + " files(*" + TSerial.FileExtens + plugin.FileExtens + ") | *" + TSerial.FileExtens + plugin.FileExtens + "|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            //string fileExtens = null;


            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            ObjectList = (List<Object>)TSerial.DeSerialize(plugin.DeShifr(fs));
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
