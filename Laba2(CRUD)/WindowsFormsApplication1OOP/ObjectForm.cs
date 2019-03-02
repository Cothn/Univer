using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace CRUD_OOP2
{
    class ObjectForm : Form
    {
        private Object GObj;
        private List<Object> GObjectList;
        //Форма редактирования обьекта
        public ObjectForm(Object Obj, List<Object> ObjectList)
        {
            //список всех полей объекта
            FieldInfo[] fields = Obj.GetType().GetFields(); ;

            //создание пустой формы для редактирования полей
            base.Text = Obj.GetType().ToString();
            base.Size = new System.Drawing.Size(500, 60 + 25 * (fields.Length + 2));

            //создание полей
            for (int i = 0; i < fields.Length; i++)
            {
                //надпись содержащая тип и имя поля
                Label label = new Label
                {
                    Location = new Point(15, 25 * (i + 1)),
                    //Width = string.Concat(fields[i].FieldType.Name, " ", fields[i].Name).Length * 7,
                    Width = base.Width / 2,
                    Text = string.Concat(fields[i].Name, " - ", fields[i].FieldType.Name, ": ")
                };
                base.Controls.Add(label);

                //Создание чекбоксов
                if (fields[i].FieldType == typeof(bool))
                {
                    CheckBox check = new CheckBox()
                    {
                        Name = fields[i].Name,
                        Location = new Point(15 + label.Width, 25 * (i + 1)),
                        //Width = base.Width - (label.Location.X + label.Width + 30),
                        //Text = fields[i].GetValue(Obj).ToString()
                        Checked = (bool)fields[i].GetValue(Obj)
                    };
                    base.Controls.Add(check);
                } //Создание для стандартных типов значений текстовых полей ввода, и их заполнение
                else if (((fields[i].FieldType.IsPrimitive) && (!fields[i].FieldType.IsEnum))
                  || (fields[i].FieldType == typeof(string)))
                {
                    TextBox text = new TextBox
                    {
                        Name = fields[i].Name,
                        Location = new Point(15 + label.Width, 25 * (i + 1)),
                        Width = base.Width - (label.Location.X + label.Width + 30),
                        Text = fields[i].GetValue(Obj).ToString()
                    };
                    base.Controls.Add(text);

                }//Создание выпадающих списков для перечислимых типов
                else if (fields[i].FieldType.IsEnum)
                {
                    ComboBox combobox = new ComboBox
                    {
                        Name = fields[i].Name,
                        SelectionStart = 0,
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Location = new Point(15 + label.Width, 25 * (i + 1)),
                        Width = base.Width - (label.Location.X + label.Width + 30)
                    };
                    combobox.Items.AddRange(fields[i].FieldType.GetEnumNames());
                    combobox.SelectedIndex = (int)(fields[i].GetValue(Obj));
                    base.Controls.Add(combobox);

                }

                //Создание выпадающих списков для вложенных членов
                else if ((!fields[i].FieldType.IsPrimitive) && (!fields[i].FieldType.IsEnum) && (!(fields[i].FieldType == typeof(string))))
                {
                    ComboBox combobox = new ComboBox
                    {
                        Name = fields[i].Name,
                        SelectionStart = 0,
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Location = new Point(15 + label.Width, 25 * (i + 1)),
                        Width = base.Width - (label.Location.X + label.Width + 30)
                    };

                    //список объектов удовлетворяющих типу поля
                    List<object> SuitableItems = ObjectList.Where(WField => (WField.GetType() == fields[i].FieldType)).ToList();

                    //заполнение списка
                    for (int j = 0; j < SuitableItems.Count; j++)
                    {
                        var ObjField = SuitableItems[j].GetType().GetField("Identifer");
                        if (ObjField != null)
                            combobox.Items.Add(ObjField.GetValue(SuitableItems[j]));
                    }

                    //Установка связанного обьекта
                    var buf = fields[i].GetValue(Obj);
                    int index = -1;

                    if (buf != null)
                    {
                        for (int j = 0; j < SuitableItems.Count; j++)
                        {
                            if (buf.Equals(SuitableItems[j]))
                            {
                                index = j; break;
                            }
                        }
                        combobox.SelectedIndex = index;
                    }

                    base.Controls.Add(combobox);
                }
            }

            //кнопка сохранения
            Button SaveBut = new Button
            {
                Name = "SaveBut",
                Text = "Save",
                Location = new Point(base.Width / 2 - (base.Width / 8), (fields.Length + 1) * 25),
                Width = base.Width / 4,
                DialogResult = DialogResult.OK,
            };

            GObj = Obj;
            GObjectList = ObjectList;
            SaveBut.Click += SaveAction;

            base.Controls.Add(SaveBut);

            //return form;
        }

        //сохранение значений полей обьекта
        private void SaveAction(object sender, EventArgs e)
        {
            if ((GObj == null) || (GObjectList == null))
                return;

            FieldInfo[] fields = GObj.GetType().GetFields();

            //Сохранение значений чекбоксов
            foreach (var control in base.Controls.OfType<CheckBox>().ToList())
            {
                FieldInfo FI = fields.ToList().Where(field => field.Name == control.Name).First();
                FI.SetValue(GObj, Convert.ChangeType(control.Checked, FI.FieldType));
            }
            //Преобразование текста в значение
            foreach (var control in base.Controls.OfType<TextBox>().ToList())
            {
                if (fields.ToList().Where(field => field.Name == control.Name).Count() != 0)
                {
                    FieldInfo FI = fields.ToList().Where(field => field.Name == control.Name).First();
                    var FIValye = FI.GetValue(GObj);
                    try
                    {
                        FI.SetValue(GObj, Convert.ChangeType(control.Text, FI.FieldType));
                    }
                    catch
                    {
                        //Восстанавливаем старое значение
                        FI.SetValue(GObj, FIValye);
                        MessageBox.Show(FI.Name + " Error: field text value");
                    }
                }
            }

            //Сохранение значений выпадающих списков
            foreach (var control in base.Controls.OfType<ComboBox>().ToList())
            {
                if (fields.ToList().Where(field => field.Name == control.Name).Count() != 0)
                {
                    FieldInfo FI = fields.ToList().Where(field => field.Name == control.Name).First();
                    var FIValye = FI.GetValue(GObj);

                    if (control.SelectedIndex == -1)
                        continue;

                    if (FI.FieldType.IsEnum)
                    {
                        try
                        {
                            FI.SetValue(GObj, control.SelectedIndex);
                        }
                        catch
                        {
                            FI.SetValue(GObj, FIValye);
                            MessageBox.Show(FI.Name + " Error: field enum value");
                        }
                    }
                    else
                    {
                        List<object> SuitableItems = GObjectList.Where(sitem => (sitem.GetType() == FI.FieldType)).ToList();
                        try
                        {
                            FI.SetValue(GObj, SuitableItems[control.SelectedIndex]);
                        }
                        catch
                        {
                            FI.SetValue(GObj, FIValye);
                            MessageBox.Show(FI.Name + " Error: field object value");
                        }
                    }
                }
            }
        }

    }
}
