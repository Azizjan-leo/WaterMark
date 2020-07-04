using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhaterMark
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Font waterMarkFont;
        Single fontSize = 8.0f;
        Single fontSizeShift = 0.0f;
        string filePath;
        ImageFormat imageFormat;
        public int MyProperty { get; set; }
        public Form1()
        {
            InitializeComponent();
            // Hook up the Elapsed event for the timer. 
            fontSizeChangeTimer.Tick += new EventHandler(OnTimedEvent);
            
            fontsCbx.Items.AddRange(FontFamily.Families.Select(x => x.Name).ToArray());
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png",
                Title = "Save an Image File",
                FileName = imageNameLbl.Text
            };
            saveFileDialog.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (!String.IsNullOrEmpty(saveFileDialog.FileName))
            {
                using (var bmp = new Bitmap(image))
                {
                    // Пользователь пытается сохранить картинку под тем же именем туда же
                    if (saveFileDialog.FileName == filePath)
                    {
                        var dialogResult = MessageBox.Show("Please, enter new name of choose different location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                        {
                            saveBtn_Click(sender, e);
                            return;
                        }

                    }

                    // Удалить файл, если такой уже имеется
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }

                    switch (saveFileDialog.FilterIndex)
                    {
                        case 0:
                            bmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                            break;
                        case 1:
                            bmp.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                            break;
                        case 2:
                            bmp.Save(saveFileDialog.FileName, ImageFormat.Gif);
                            break;
                        case 3:
                            bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
                            break;
                    }

                    // Скажем пользователю, что сохранение прошло успешно :)
                    MessageBox.Show("Image saved successfuly", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void chooseImgBtn_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(open.FileName);
                imageNameLbl.Text = open.SafeFileName;
                pictureBox1.Image = image;
                filePath = open.FileName;
                
            }
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            if(image == null)
            {
                var dialogResult = MessageBox.Show("Please, choose an image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                    return;
            }
            PointF waterMarkLocation = new PointF(horizontalTrBar.Value, verticalTrBar.Value);
            string waterMarkText = waterMarkTextTxt.Text;
          
            waterMarkFont = new Font(fontsCbx.Text, fontSize);
            
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.DrawString(waterMarkText, waterMarkFont, new SolidBrush(colorBtn.BackColor), waterMarkLocation);
            }
            pictureBox1.Image = image;
            saveBtn.Enabled = true;
        }

        private void waterMarkTextTxt_TextChanged(object sender, EventArgs e)
        {
            if (waterMarkTextTxt.Text != "" && fontsCbx.SelectedIndex > -1)
            {
                setBtn.Enabled = true;
            }
        }

        private void fontsCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontsCbx.SelectedIndex > -1 && waterMarkTextTxt.Text != "")
            {
                waterMarkTextTxt.Font = new Font(fontsCbx.Text, 8);
                setBtn.Enabled = true;
            }
        }

        private void fontPlusBtn_MouseDown(object sender, MouseEventArgs e)
        {
            fontSizeShift = 0.1f;
            fontSizeChangeTimer.Enabled = true;
            fontSizeChangeTimer.Start();
        }

        private void OnTimedEvent(Object source, EventArgs e)
        {
            fontSize += (Single)Math.Round(fontSizeShift, 2);
            fontSize = (Single)Math.Round(fontSize, 2);
            fontSizeTxt.Text = fontSize.ToString();
        }
            
        private void fontSizeMinusBtn_MouseDown(object sender, MouseEventArgs e)
        {
            fontSizeShift = -0.1f;
            fontSizeChangeTimer.Enabled = true;
            fontSizeChangeTimer.Start();
        }

        private void fontSizeBtn_MouseUp(object sender, MouseEventArgs e)
        {
            fontSizeChangeTimer.Enabled = false;
            fontSizeChangeTimer.Stop();
        }

        private void fontPlusBtn_Click(object sender, EventArgs e)
        {
            fontSize += (Single)Math.Round(0.1f, 2);
            fontSize = (Single)Math.Round(fontSize, 2);
            fontSizeTxt.Text = fontSize.ToString();
        }

        private void fontSizeMinusBtn_Click(object sender, EventArgs e)
        {
            fontSize += (Single)Math.Round(-0.1f, 2);
            fontSize = (Single)Math.Round(fontSize, 2);
            fontSizeTxt.Text = fontSize.ToString();
        }

        private void fontSizeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                return;
            }

        }

        private void fontSizeTxt_TextChanged(object sender, EventArgs e)
        {
            fontSize = (Single)Math.Round(Convert.ToSingle(fontSizeTxt.Text), 2);
        }

        private void horizontalTrBar_Scroll(object sender, EventArgs e)
        {
            waterMarkLocationLbl.Text = "WaterMark location: " + (sender as TrackBar).Value + ", " + verticalTrBar.Value;
        }

        private void verticalTrBar_Scroll(object sender, EventArgs e)
        {
            waterMarkLocationLbl.Text = "WaterMark location: " + horizontalTrBar.Value + ", " + (sender as TrackBar).Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Keeps the user from selecting a custom color.
            colorDialog1.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            colorDialog1.ShowHelp = true;
            // Sets the initial color select to the current text color.
            colorDialog1.Color = colorBtn.BackColor;

            // Update the text box color if the user clicks OK 
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                colorBtn.BackColor = colorDialog1.Color;
        }
    }
}
