using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator__classic_
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        string[] dictionary = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "*", "+", "-", "/", ")" }; 
        
        List<string> list = new List<string>() { "" }; //бесполезный лист
        double n1 = 0;
        double n2 = 0;
        string act = "";
        double n_rec;
        double memory = 0;
        bool procent = false;
        bool reciproc = false;
        string a;
        bool clean = false; //очистка всякая после тупых действий
        bool enter = true; //является ли число в label2 результатом нажатия или вычислений, false если это результат вычислений
        bool comma = false; //проверка на действительное число;
        char sign = '='; // сохранение знака после равно
        bool blocked = false; //отвечает за блокировку дальнейших действий
        public void None(string a) //проверка на тип числа (введен самостоятельно, нуль или результат вычислений)
        {
            if (label1.Text == "0") //какое-то исключение 
            {
                label1.Text = "";
            }
            if (act != "")
            {
                if (label1.Text.Length != act.Length)
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - act.Length);
                }
                else
                {
                    label1.Text = "0";
                }
            }
            if (label2.Text == "0" || enter == false || label2.Text == "-0")
            {
                label2.Text = a;
                enter = true;
            }
            else
            {
                label2.Text += a;
            }
            
            reciproc = false;
            act = ""; //?
            
        }
        
        public void CommaInTheEnd()
        {
            if (label2.Text[label2.Text.Length - 1] == ',')
            {
                label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
            }
        }
        public void SignCheck() //проверка на получение ожидаемого знака
        {
            if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == '+')
            {
                button29.PerformClick();
            }
            if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == '-')
            {
                button24.PerformClick();
            }
            if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == '*')
            {
                button19.PerformClick();
            }
            if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == '/')
            {
                button14.PerformClick();
            }

        }
        public void Max_length() // максимальная длина в label2
        {
            int labelLength = label2.Text.Length;
            int max = 16;
            if (labelLength > max)
            {
                this.label2.Text = label2.Text.Substring(0, 16);
            }
        }
        public void MaxSize ()
        {
            int max = 30;
            if (label1.Text.Length > max)
            {
                string labelhelp = "«";
                int len = label1.Text.Length - max;
                //label1.Text = label1.Text.Substring(1, label1.Text.Length);
                for (int i = label1.Text.Length - max - 1; i < label1.Text.Length; i++)
                {
                    labelhelp += label1.Text[i];
                }
                label1.Text = labelhelp;

            }
        }
        /*private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ContainKey(e.KeyData, Keys.E) && ContainKey(e.KeyData, Keys.Shift))
                MessageBox.Show("!");
        }*/

        bool ContainKey(Keys source, Keys key)
        {
            return (source & key) == key;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //работа ввода с клавиатуры
        {
            if (keyData == (Keys.D1))
            {
                button21.PerformClick();
            }
            else if(keyData == (Keys.D2))
            {
                button22.PerformClick();
            }
            else if(keyData == (Keys.D3))
            {
                button23.PerformClick();
            }
            else if(keyData == (Keys.D4))
            {
                button16.PerformClick();
            }
            else if (keyData == (Keys.D5))
            {
                button17.PerformClick();
            }
            else if (keyData == (Keys.D6))
            {
                button20.PerformClick();
            }
            else if (keyData == (Keys.D7))
            {
                button10.PerformClick();
            }
            else if (keyData == (Keys.D8))
            {
                button11.PerformClick();
            }
            else if (keyData == (Keys.D9))
            {
                button13.PerformClick();
            }
            else if (keyData == (Keys.D0))
            {
                button28.PerformClick();
            }
            else if (keyData == (Keys.Oemcomma))
            {
                button26.PerformClick();
            }
            else if (keyData == (Keys.Oemplus)) //=
            {
                button25.PerformClick();
            }
            else if (keyData == (Keys.Enter)) //=
            {
                button25.PerformClick();
            }
            else if (keyData == (Keys.Oem2)) // /
            {
                button14.PerformClick();
            }
            else if (ContainKey(keyData, Keys.Oemplus)&& ContainKey(keyData, Keys.Shift) && !ContainKey(keyData, Keys.Oem2)) //+
            {
                button29.PerformClick();
            }
            else if ((ContainKey(keyData, Keys.Shift) && ContainKey(keyData, Keys.D8) && !ContainKey(keyData, Keys.Oem2))) //*
            {
                button19.PerformClick();
            }
            else if (keyData == (Keys.OemMinus)) //-
            {
                button24.PerformClick();
            }
            else if ((ContainKey(keyData, Keys.D5) && ContainKey(keyData, Keys.Shift) && !ContainKey(keyData, Keys.Oem2))) //%
            {
                button15.PerformClick();
            }
            else if ((ContainKey(keyData, Keys.Q) && ContainKey(keyData, Keys.Control)))//m-
            {
                button5.PerformClick();
            }
            else if ((ContainKey(keyData, Keys.P) && ContainKey(keyData, Keys.Control)))//m+
            {
                button4.PerformClick();
            }
            else if ((ContainKey(keyData, Keys.M) && ContainKey(keyData, Keys.Control)))//ms
            {
                button3.PerformClick();
            }
            else if ((ContainKey(keyData, Keys.R) && ContainKey(keyData, Keys.Control)))//mr
            {
                button2.PerformClick();
            }
            else if ((ContainKey(keyData, Keys.L) && ContainKey(keyData, Keys.Control)))//mc
            {
                button1.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                if (reciproc == false)
                {
                    n_rec = Convert.ToDouble(label2.Text);
                    reciproc = true;
                }
                else
                {
                    reciproc = false;
                }
                if (act == "")
                {
                    act = " reciproc(" + label2.Text + ')';
                }
                else
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - act.Length);
                    act = " reciproc(" + act + ')';
                }
                n2 = 1 / Convert.ToDouble(label2.Text);
                if (reciproc == false)
                {
                    n2 = n_rec;
                }
                label1.Text += act;
                label2.Text = Convert.ToString(n2);
                enter = false;
                a = label1.Text;
                clean = true;
                //MaxSize();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {if (blocked == false)
            {
                None("1");
                Max_length();
            }
        }


        private void button22_Click(object sender, EventArgs e)
        {if (blocked == false)
            {
                None("2");
                Max_length();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {if (blocked == false)
            {
                None("3");
                Max_length();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {if (blocked == false)
            {
                None("4");
                Max_length();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {if (blocked == false)
            {
                None("5");
                Max_length();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {if (blocked == false)
            {
                None("6");
                Max_length();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                None("7");
                Max_length();
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                None("8");
                Max_length();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                None("9");
                Max_length();
            }

        }

        private void button28_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        private void SizeTextChanging (object sender)
        {
            float p = 7;
            Font f = new Font(((Label)sender).Font.Name, p);
            ((Label)sender).Font = f;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                if (label1.Text == "") //тут для непрерывного действия после равно
                {
                    if (sign == '+')
                    {
                        n1 = Convert.ToDouble(label2.Text) + n2;
                        label2.Text = Convert.ToString(n1);
                    }
                    else if (sign == '-')
                    {
                        n1 = Convert.ToDouble(label2.Text) - n2;
                        label2.Text = Convert.ToString(n1);
                    }
                    else if (sign == '*')
                    {
                        n1 = Convert.ToDouble(label2.Text) * n2;
                        label2.Text = Convert.ToString(n1);
                    }
                    else if (sign == '/')
                    {
                        n1 = Convert.ToDouble(label2.Text) / n2;
                        label2.Text = Convert.ToString(n1);
                    }
                    else
                    {
                        label2.Text = label2.Text;
                    }
                }
                else if (label1.Text.Length == act.Length) //проверка на соло действие act
                {
                    label1.Text = "";
                    n1 = n2;
                }
                // чтоб работало если есть act и обычные знаки
                else if (label1.Text[label1.Text.Length - 1] == '+' || (label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - act.Length).Length] == '+' && label1.Text[label1.Text.Length - 1] == ')'))
                {
                    n2 = Convert.ToDouble(label2.Text);
                    label1.Text = "";
                    n1 = n1 + n2;
                    label2.Text = Convert.ToString(n1);
                    sign = '+';
                }
                else if (label1.Text[label1.Text.Length - 1] == '-' || (label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - act.Length).Length] == '-' && label1.Text[label1.Text.Length - 1] == ')'))
                {
                    n2 = Convert.ToDouble(label2.Text);
                    label1.Text = "";
                    n1 = n1 - n2;
                    label2.Text = Convert.ToString(n1);
                    sign = '-';
                }
                else if (label1.Text[label1.Text.Length - 1] == '*' || (label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - act.Length).Length] == '*' && label1.Text[label1.Text.Length - 1] == ')'))
                {
                    n2 = Convert.ToDouble(label2.Text);
                    label1.Text = "";
                    n1 = n1 * n2;
                    label2.Text = Convert.ToString(n1);
                    sign = '*';
                }
                else if (label1.Text[label1.Text.Length - 1] == '/' || (label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - act.Length).Length] == '/' && label1.Text[label1.Text.Length - 1] == ')'))
                {
                    n2 = Convert.ToDouble(label2.Text);
                    label1.Text = "";
                    n1 = n1 / n2;
                    label2.Text = Convert.ToString(n1);
                    sign = '/';
                }
                else //операция равно после знака процента
                {
                    if (label1.Text!="0" && label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - label2.Text.Length).Length] == '+')
                    {
                        n2 = Convert.ToDouble(label2.Text);
                        label1.Text = "";
                        n1 = n1 + n2;
                        label2.Text = Convert.ToString(n1);
                        sign = '+';
                    }
                    else if (label1.Text != "0" && label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - label2.Text.Length).Length] == '-')
                    {
                        label1.Text = "";
                        n1 = n1 - n2;
                        label2.Text = Convert.ToString(n1);
                        sign = '-';
                    }
                    else if (label1.Text != "0" && label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - label2.Text.Length).Length] == '*')
                    {
                        label1.Text = "";
                        n1 = n1 * n2;
                        label2.Text = Convert.ToString(n1);
                        sign = '*';
                    }
                    else if (label1.Text != "0" && label1.Text[label1.Text.Substring(0, label1.Text.Length - 1 - label2.Text.Length).Length] == '/')
                    {
                        label1.Text = "";
                        n1 = n1 / n2;
                        label2.Text = Convert.ToString(n1);
                        sign = '/';
                    }
                    else //временный элс
                    {
                        label1.Text = "";
                        label2.Text = Convert.ToString(n1);
                    }
                }
                enter = false; //ЭТО РЕЗУЛЬТАТ ВЫЧИСЛЕНИЙ
                reciproc = false;
                procent = false;
                a = "";

                for (int i = 0; i < label2.Text.Length - 1; i++)
                {
                    if (label2.Text[i] == ',') comma = true;
                }

                if (Convert.ToString(label2.Text[label2.Text.Length - 1]) == "о")
                {
                    label2.Text = "Результат не определен";
                    label2.Font = new Font(label1.Font.Name, 8, label1.Font.Style);
                    blocked = true;
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            list.Clear();
            label2.Text = "0";
            label1.Text = "";
            n1 = 0;
            n2 = 0;
            act = "";
            comma = false;
            blocked = false;
            procent = false;
            label2.Font = new Font(label1.Font.Name, 13, label1.Font.Style);
            a = "";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                CommaInTheEnd();
                comma = false;
                if (label1.Text == "0" && procent == false)
                {
                    label1.Text = "";
                }
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] != '+') SignCheck();
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == ')') //если скобка
                {
                    label1.Text += " " + '+';
                }
                if (enter == false && label1.Text != "" && label1.Text[label1.Text.Length - 3] != ')') //для изменения знака на нужный, очень странно работает для скобочных операций
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                    label1.Text += '+';
                }
                else
                {
                    n2 = Convert.ToDouble(label2.Text);
                    if (label1.Text == "") { n1 = n2; }
                    else { n1 = n1 + n2; }
                    list.Add("");
                    if (act == "")
                    {
                        if (procent == true)
                        {
                            label1.Text += "  " + '+';
                            procent = false;
                        }
                        else
                        {
                            label1.Text += label2.Text + " " + '+';
                        }
                    }
                }
                label2.Text = Convert.ToString(n1);
                enter = false;
                reciproc = false;
                act = "";
                a = label1.Text;
                MaxSize();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                None("0");
                Max_length();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
            comma = false;
            procent = false;
            if (blocked == true)
            {
                button8.PerformClick();
            }
            a = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                CommaInTheEnd();
                comma = false;
                if (label1.Text == "0" && procent == false)
                {
                    label1.Text = "";
                }
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] != '*') SignCheck();
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == ')') //если скобка
                {
                    label1.Text += " " + '*';
                }
                if (enter == false && label1.Text != "" && label1.Text[label1.Text.Length - 3] != ')') //для изменения знака на нужный, очень странно работает для скобочных операций
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                    label1.Text += '*';
                }
                else
                {
                    n2 = Convert.ToDouble(label2.Text);
                    if (label1.Text == "") { n1 = n2; }
                    else { n1 = n1 * n2; }
                    list.Add("");
                    if (act == "")
                    {
                        if (procent == true)
                        {
                            label1.Text += "  " + '*';
                            procent = false;
                        }
                        else
                        {
                            label1.Text += label2.Text + " " + '*';
                        }
                    }
                }
                label2.Text = Convert.ToString(n1);
                enter = false;
                reciproc = false;
                act = "";
                a = label1.Text;
                MaxSize();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                CommaInTheEnd();
                comma = false;
                if (label1.Text == "0" && procent == false)
                {
                    label1.Text = "";
                }
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] != '-') SignCheck();
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == ')') //если скобка
                {
                    label1.Text += " " + '-';
                }
                if (enter == false && label1.Text != "" && label1.Text[label1.Text.Length - 3] != ')') //для изменения знака на нужный, очень странно работает для скобочных операций
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                    label1.Text += '-';
                }
                else
                {
                    n2 = Convert.ToDouble(label2.Text);
                    if (label1.Text == "") { n1 = n2; }
                    else { n1 = n1 - n2; }
                    list.Add("");
                    if (act == "")
                    {
                        if (procent == true)
                        {
                            label1.Text += "  " + '-';
                            procent = false;
                        }
                        else
                        {
                            label1.Text += label2.Text + " " + '-';
                        }
                    }
                }
                label2.Text = Convert.ToString(n1);
                enter = false;
                act = "";
                reciproc = false;
                a = label1.Text;
                MaxSize();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {


                CommaInTheEnd();
                comma = false;
                if (label1.Text == "0" && procent == false)
                {
                    label1.Text = "";
                }
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] != '/') SignCheck();
                if (label1.Text != "" && label1.Text[label1.Text.Length - 1] == ')') //если скобка
                {
                    label1.Text += " " + '/';
                }
                if (enter == false && label1.Text != "" && label1.Text[label1.Text.Length - 3] != ')') //для изменения знака на нужный
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                    label1.Text += '/';
                }
                else
                {
                    n2 = Convert.ToDouble(label2.Text);
                    if (label1.Text == "") { n1 = n2; }
                    else { n1 = n1 / n2; }
                    list.Add("");
                    if (act == "")
                    {
                        if (procent == true)
                        {
                            label1.Text += "  " + '/';
                            procent = false;
                        }
                        else
                        {
                            label1.Text += label2.Text + " " + '/';
                        }
                    }
                }
                label2.Text = Convert.ToString(n1);
                enter = false;
                act = "";
                reciproc = false;
                a = label1.Text;
                MaxSize();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                string labelsave = label2.Text;
                if (labelsave[0] == '-')
                {
                    label2.Text = label2.Text.Substring(1, label2.Text.Length - 1);
                }
                else
                {
                    label2.Text = "-" + labelsave;
                }
                MaxSize();
            }
                
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            { 
                if (enter == false)
                {
                    label2.Text = "0,";
                    comma = true;
                    enter = true;
                }
                else if (comma == false)
                {
                    if (label1.Text != "" && (label1.Text[label1.Text.Length - 1] != '+' &&
                        label1.Text[label1.Text.Length - 1] != '-' &&
                        label1.Text[label1.Text.Length - 1] != '*' &&
                        label1.Text[label1.Text.Length - 1] != '/'))
                    {
                        label1.Text = label1.Text.Substring(0, label1.Text.Length - label2.Text.Length);
                        label2.Text = "0,";
                        comma = true;
                    }
                    else
                    {
                        label2.Text += ',';
                        comma = true;
                    }
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                n2 = Convert.ToDouble(label2.Text);
                n2 = n1 * n2 / 100;
                label1.Text = a + Convert.ToString(n2);
                label2.Text = Convert.ToString(n2);
                procent = true;
                MaxSize();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                clean = true;
                if (act == "")
                {
                    act = " sqrt(" + label2.Text + ')';
                }
                else
                {
                    this.label1.Text = label1.Text.Substring(0, label1.Text.Length - act.Length);
                    act = " sqrt(" + act + ')';
                }

                n2 = Math.Sqrt(Convert.ToDouble(label2.Text));
                label1.Text += act;
                label2.Text = Convert.ToString(n2);
                enter = false;
                a = label1.Text;
                //MaxSize();
            }      
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (enter!=false && blocked == false)
            {
                if (label2.Text.Length == 1)
                {
                    label2.Text = "0";
                }
                else if (label2.Text.Length == 2 && label2.Text[0]=='-')
                {
                    label2.Text = "0";
                }
                else
                {
                    if (label2.Text[label2.Text.Length - 1] == ',') comma = false;
                    label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                label4.Text = "";
                memory = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                label4.Text = "M";
                memory = Convert.ToDouble(label2.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                label4.Text = "M";
                memory = Convert.ToDouble(label2.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                label4.Text = "";
                memory = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (blocked == false)
            {
                label2.Text = Convert.ToString(memory);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }
    }
}


