using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace City_Course
{
    class FormOut
    {
        public class Form1 : Form
        {
            public ListBox listPeoples;
            public ListBox listSibilings;
            public TextBox fieldBirthDate;
            public Label infoDate;
            public DataGrid tableSibilings;


            public Person[] dataBase_inner;
            public void initializeForm()
            {
                fieldBirthDate = new TextBox();
                listPeoples = new ListBox();
                infoDate = new Label();
                listSibilings = new ListBox();
                tableSibilings = new DataGrid();

                fieldBirthDate.Location = new Point(200, 25);
                fieldBirthDate.Size = new Size(75, 50);
                tableSibilings.Location = new Point(200, 150);

                listPeoples.Location = new Point(25, 25);
                listPeoples.Size = new Size(150, 200);

                infoDate.Text = "Дата рождения";
                infoDate.Location = new Point(200, 10);

                listSibilings.Location = new Point(200, 50);


                this.Text = "Город";
                this.Size = new Size(400, 300);

                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.Controls.Add(listSibilings);
                this.Controls.Add(listPeoples);
                this.Controls.Add(fieldBirthDate);
                this.Controls.Add(infoDate);
                this.Controls.Add(tableSibilings);
            }
            public Form1(Person[] dataBase)
            {
                infoDate = new Label();
                dataBase_inner = dataBase;
                dataBase = null;
                initializeForm();
                foreach (var people in dataBase_inner) listPeoples.Items.Add(people.FName + ' ' + people.LName);
                listPeoples.SelectedIndexChanged += new EventHandler(List1_SelectedIndexChanged);
                listSibilings.SelectedIndexChanged += new EventHandler(listSiblings_SelectedIndexChanged);
            }

            private void List1_SelectedIndexChanged(object sender, EventArgs e)
            {
                listSibilings.Items.Clear();
                fieldBirthDate.Text = (dataBase_inner[listPeoples.SelectedIndex].birthDate).ToShortDateString();
                int num = 0;
                foreach (var people in dataBase_inner)
                {
                    if (dataBase_inner[listPeoples.SelectedIndex].LName == people.LName && listPeoples.SelectedIndex != num)
                    listSibilings.Items.Add(people.FName + ' ' + people.LName);
                    num++;
                }
            }
            private void listSiblings_SelectedIndexChanged(object sender, EventArgs e)
            {

            }
        }
    }
}
