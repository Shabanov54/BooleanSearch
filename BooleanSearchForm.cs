using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanSearch
{
    public partial class BooleanSearchForm : Form
    {
        string deletedValue = "-inurl:dir -vacancies -companies -courses -resumes?";
        string habr = "site:moikrug.ru OR site:career.habr.com";
        string link = "site:linkedin.com/in OR site:linkedin.com/pub";
        string vk = "site:vk.com";
        string github = "site:github.com";
        string fb = "site:fb.com";
        public BooleanSearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> positionList = new List<string>();
            List<string> extraVAlList = new List<string>();
            List<string> cityList = new List<string>();
            string telegram = "";
            string mail = "";
            string open = "";
            string citystring = "";
            string etraVAl = "";
            string stringPosition = "";


            while (true)
            {
                var selectItemComboboxIndex = comboBox1.SelectedIndex;
                string selectItemCombobox = "";
                if (selectItemComboboxIndex == 0)
                {
                    selectItemCombobox = link;
                }
                if (selectItemComboboxIndex == 1)
                {
                    selectItemCombobox = fb;
                }
                if (selectItemComboboxIndex == 2)
                {
                    selectItemCombobox = habr;
                }
                if (selectItemComboboxIndex == 3)
                {
                    selectItemCombobox = vk;
                }
                if (selectItemComboboxIndex == 4)
                {
                    selectItemCombobox = github;
                }
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Забыли выбрать рессурс");
                    break;
                }
                if (textBox1.Text != "")
                {
                    var splitposition = textBox1.Text.Split(new Char[] { ',' });
                    foreach (var splited in splitposition)
                    {
                        positionList.Add($"\"{splited}\"");
                    }
                    stringPosition = string.Join(" ", positionList.ToList());
                }
                if (textBox3.Text != "")
                {
                    var spletExtraVAl = textBox3.Text.Split(new Char[] { ',' });
                    foreach (var splited in spletExtraVAl)
                    {
                        extraVAlList.Add($"\"{splited}\"");
                    }
                    etraVAl = string.Join(" ", extraVAlList.ToList());
                }
                if (textBox2.Text!="")
                {
                    var splitedCity = textBox2.Text.Split(new Char[] { ',' });
                    foreach (var splited in splitedCity)
                    {
                        cityList.Add($"\"{splited}\"");
                    }
                    citystring = string.Join(" ", cityList.ToList());
                }


                if (checkBox1.Checked == true)
                {
                    telegram = "\"Telegram: @\"";
                }
                if (checkBox2.Checked == true)
                {
                    mail = "(\"@gmail.com\" OR \"@mail.ru\" OR \"@yandex.ru\" OR \"@outlook.com\" OR \"@rambler.ru \")";
                }
                if (checkBox3.Checked == true)
                {
                    open = "\"открыт к предложениям\"";
                }
                textBox4.Text = $"{selectItemCombobox} {deletedValue} {etraVAl} {stringPosition} {citystring} {telegram} {mail} {open}";

                break;
            }

        }

        private void textBox4_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Clipboard.SetText(textBox4.Text);
            }
        }
    }
}
