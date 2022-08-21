using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public int Order1(int or1)
        {


            string cutNumber = coast1.Text.Substring(0, coast1.Text.Length - 3);
            int nunber;
            int.TryParse(cutNumber, out nunber);


            return or1 * nunber;
        }
        public int Order2(object or2)
        {
            string cutNumber = coast1.Text.Substring(0, coast2.Text.Length - 3);
            int nunber;
            int.TryParse(cutNumber, out nunber);


            int a = Convert.ToInt32(or2);

            return nunber * a;
        }
        public int Order3(object or3)
        {
            string cutNumber = coast1.Text.Substring(0, coast2.Text.Length - 3);
            int nunber;
            int.TryParse(cutNumber, out nunber);


            int a = Convert.ToInt32(or3);

            return nunber * a;
        }
        public int AllResult(Task[] tasks)
        {

            int result = 0;
            for (int i = 0; i < tasks.Length; i++)
            {
                var t3 = tasks[i] as Task<int>;
                result += t3.Result;

            }
            //  Task.WaitAll(tasks);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (numericUpDown1.Value != 0 || numericUpDown2.Value !=0 || numericUpDown3.Value !=0 )
            {

                TaskFactory taskF = new TaskFactory();

                Task[] tasM = {  Task.Factory.StartNew(() => Order1((int)numericUpDown1.Value)),
                                 Task.Factory.StartNew(() => Order2((int)numericUpDown2.Value)),
                                 Task.Factory.StartNew(() => Order3((int)numericUpDown3.Value)),

                };
               Task.WaitAll(tasM);

                TextBox[] tbAll = new TextBox[tasM.Length];
                tbAll[0] = textBox1;
                tbAll[1] = textBox2;
                tbAll[2] = textBox3;

                for (int i = 0; i < tasM.Length; i++)
                {

                    var t3 = tasM[i] as Task<int>;
                    tbAll[i].Text = t3.Result.ToString();
                }
               
                textBox4.Text = taskF.ContinueWhenAll(tasM, (p) => AllResult(tasM)).Result.ToString();


            }
            else 
            {
                label8.Text = "Please, choise your pizza!!!!!";
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
