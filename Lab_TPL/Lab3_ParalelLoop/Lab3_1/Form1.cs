using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        string base64Text;
        public Form1()
        {
            InitializeComponent();
        }

        public void UploadImage()
        {
            WebRequest request = WebRequest.Create("https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Clear_sky_Mountain.jpg/1200px-Clear_sky_Mountain.jpg");
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
        }

        public void UploadImage2()
        {
            WebRequest request = WebRequest.Create("https://www.ixbt.com/img/n1/news/2021/10/2/22459ff25f8eff76bddf34124cc2c85b16f4cd4a_large.jpg");
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    pictureBox2.Image = Image.FromStream(stream);
                }
            }

        }



        private void btnLoad_Click(object sender, EventArgs e)
        {

            if (txtLoad.Text == "" || txtLoad.Text == null || txtLoad.Text == String.Empty)
            {
                label1.Text = "Input the link Image!!! Or Click button upload All";
            }
            else
            {

                WebRequest request = WebRequest.Create(txtLoad.Text);


                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        pictureBox2.Image = Image.FromStream(stream);   /////////////////output URL

                      
                        var webClient = new WebClient();
                        byte[] imageBytes = webClient.DownloadData(txtLoad.Text); //dounload to byte
                        string imreBase64Data = Convert.ToBase64String(imageBytes);
                        string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);


                        richTextBox1.Text = imgDataURL;
                        pictureBox1.Image = ConvertBase64ToImage(imreBase64Data);


                        

                    }
                }
            }
        }






////////////////////////////////////////////////////////////

        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }


        //////////////////////////Browse (File)////////////////
        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
            "|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;

                byte[] imageArray = File.ReadAllBytes(dialog.FileName);
                base64Text = Convert.ToBase64String(imageArray); //base64Text must be global but I'll use  richtext
                richTextBox1.Text = base64Text;
            }

        }







        public string ConvertImageToBase64(Image file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, file.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }





        private void txtLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(
             () => UploadImage(),
             () => UploadImage2());

        }

      
    }
}
