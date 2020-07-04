using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WhaterMark
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Font waterMarkFont;
        float fontSize = 8.0f;
        float fontSizeShift = 0.0f;
        string filePath;
        Color waterMarkColor;

        /// <summary>
        /// Конструктор класса формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // Hook up the Elapsed event for the timer. 
            fontSizeChangeTimer.Tick += new EventHandler(OnTimedEvent);
            // Заполняем комбобокс массивом доступных шрифтов
            fontsCbx.Items.AddRange(FontFamily.Families.Select(x => x.Name).ToArray());
            // Выбранным будет первый элемент списка
            fontsCbx.SelectedIndex = 0;
            // Вводим тект ватермарки по умолчанию
            waterMarkTextTxt.Text = "Nataly";
        }

        /// <summary>
        /// Обработчик нажатия кнопки Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
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
                            SaveBtn_Click(sender, e);
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

        /// <summary>
        /// Обработчик нажатия кнопки Choose folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseFolderBtn_Click_1(object sender, EventArgs e)
        {
            // Диалоговое окно выбора папки
            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };

            // Если пользователь нажал ок
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // Заносим путь к папке с именем выбранной папки в соответствующую надпись на форме
                folderNameLbl.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки выбора изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseImgBtn_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *png; *.gif; *.bmp)|*.jpg; *.jpeg; *png; *.gif; *.bmp";
            // Если всё прошло хорошо, и пользователь нажал ОК
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Вносим в нашу переменную для работы с изображением выбранный рисунок
                image = new Bitmap(open.FileName);
                // Вносим в соответствующую надпись на форме имя файла без пути
                imageNameLbl.Text = open.SafeFileName;
                // Показываем изображение на пикчербоксе
                pictureBox1.Image = image;
                // Запоминаем путь к выбранному изображению
                filePath = open.FileName;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetBtn_Click(object sender, EventArgs e)
        {
            // Если ничего не выбрано
            if(image == null && String.IsNullOrEmpty(folderNameLbl.Text))
            {
                var dialogResult = MessageBox.Show("Please, choose an image or a folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                    return;
            }
            // Если изображение выбрано
            if (image != null)
            {
                // Позиция ватермарки (берется из ползунков)
                PointF waterMarkLocation = new PointF(horizontalTrBar.Value, verticalTrBar.Value);

                string waterMarkText = waterMarkTextTxt.Text;

                waterMarkFont = new Font(fontsCbx.Text, fontSize);

                using (Graphics graphics = Graphics.FromImage(image))
                {
                    // Пишем строку
                    graphics.DrawString(waterMarkText, waterMarkFont, new SolidBrush(waterMarkColor), waterMarkLocation);
                }
                pictureBox1.Image = image;
                saveBtn.Enabled = true;
            }

            // Если папка выбрана
            if (!String.IsNullOrEmpty(folderNameLbl.Text))
            {
                foreach (var imgPath in Directory.EnumerateFiles(folderNameLbl.Text, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".gif")))
                {
                    //SetWaterMartk(imgPath);
                }
            }
        }

        /// <summary>
        /// Метод реализующий нанесение текста на изображение
        /// </summary>
        /// <param name="image"></param>
        private Bitmap SetWaterMartk(string imgPath)
        {
            var img = new Bitmap(imgPath);
            // Позиция ватермарки (берется из ползунков)
            PointF waterMarkLocation = new PointF(horizontalTrBar.Value, verticalTrBar.Value);

            string waterMarkText = waterMarkTextTxt.Text;

            waterMarkFont = new Font(fontsCbx.Text, fontSize);

            using (Graphics graphics = Graphics.FromImage(img))
            {
                // Пишем строку
                graphics.DrawString(waterMarkText, waterMarkFont, new SolidBrush(waterMarkColor), waterMarkLocation);
            }

            return img;
        }

        /// <summary>
        /// Обработчик изменения текста в текстбоксе с текстом ватермарки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaterMarkTextTxt_TextChanged(object sender, EventArgs e)
        {
            // Если текст пуст и шрифт не выбран
            if (String.IsNullOrEmpty(waterMarkTextTxt.Text) && fontsCbx.SelectedIndex < 0)
            {
                // Запрещаем кнопке установки надписи взаимодействовать (клик)
                setBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Обработчик выбора нового значения в комбобоксе со шрифтами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontsCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если выбрано валидное значение и текст не пустой
            if (fontsCbx.SelectedIndex > -1 && !String.IsNullOrEmpty(waterMarkTextTxt.Text))
            {
                // Устанавливаем выбранный шрифт в текстбокс с текстом ватермарки (учитывая размер шрифта)
                waterMarkTextTxt.Font = new Font(fontsCbx.Text, fontSize);
                // Делаем кнопку установки надписи открытой для взаимодействаия (клик)
                setBtn.Enabled = true;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontPlusBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // Вводим в переменную сдвига зармера шрифта значение 0,1
            fontSizeShift = 0.1f;
            // Включаем таймер, который каждый тик будет изменять значение переменной fontSize
            // На величину указанную в переменной fontSizeShift
            fontSizeChangeTimer.Enabled = true;
            fontSizeChangeTimer.Start();
        }

        /// <summary>
        /// Обработчик тика таймера
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(Object source, EventArgs e)
        {
            // Изменяем значение переменной fontSize
            // На величину указанную в переменной fontSizeShift
            fontSize += (Single)Math.Round(fontSizeShift, 2);
            // Округляем fontSize до одного знака после точки
            fontSize = (Single)Math.Round(fontSize, 2);
            // Вбиваем значение переменной в текстбокс
            fontSizeTxt.Text = fontSize.ToString();
        }

        /// <summary>
        /// Обработчик нажатия кнопки -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSizeMinusBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // Вводим в переменную сдвига зармера шрифта значение -0,1
            fontSizeShift = -0.1f;
            // Включаем таймер, который каждый тик будет изменять значение переменной fontSize
            // На величину указанную в переменной fontSizeShift
            fontSizeChangeTimer.Enabled = true;
            fontSizeChangeTimer.Start();
        }

        /// <summary>
        /// Обработчик разжатия с кнопок +-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSizeBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Останавливаем таймер
            fontSizeChangeTimer.Enabled = false;
            fontSizeChangeTimer.Stop();
        }

        /// <summary>
        /// Обработчик клика на кнопку +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontPlusBtn_Click(object sender, EventArgs e)
        {
            // Прибавляем 0,1 к текущему размеру шрифта
            fontSize += (Single)Math.Round(0.1f, 2);
            // Округляем размер шрифта до одного знака после точки
            fontSize = (Single)Math.Round(fontSize, 2);
            // Вбиваем значение переменной в текстбокс
            fontSizeTxt.Text = fontSize.ToString();
        }

        /// <summary>
        /// Обработчик клика на кнопку -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSizeMinusBtn_Click(object sender, EventArgs e)
        {
            // Отнимаем 0,1 от текущего размера шрифта
            fontSize -= (Single)Math.Round(0.1f, 2);
            // Округляем размер шрифта до одного знака после точки
            fontSize = (Single)Math.Round(fontSize, 2);
            // Вбиваем значение переменной в текстбокс
            fontSizeTxt.Text = fontSize.ToString();
        }

        /// <summary>
        /// Обработчик нажатия клавиши во время работы с текстбоксом размера шрифта
        /// Нужен для того, что бы не допустить ввода ненумерных знаков и двух точек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSizeTxt_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// Обработчик изменения текста в текстбоксе с размером шрифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSizeTxt_TextChanged(object sender, EventArgs e)
        {
            // Заносим значение из текстбокса в переменную,
            // предварительно округлив его до одного знака после запятой
            fontSize = (Single)Math.Round(Convert.ToSingle(fontSizeTxt.Text), 2);
        }

        /// <summary>
        /// Обработчик скроллинга горизонтально ползунока
        /// Его значение используется для размещения ватермарки по оси X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalTrBar_Scroll(object sender, EventArgs e)
        {
            waterMarkLocationLbl.Text = "WaterMark location: " + (sender as TrackBar).Value + ", " + verticalTrBar.Value;
        }

        /// <summary>
        /// Обработчик скроллинга вертикального ползунока
        /// Его значение используется для размещения ватермарки по оси Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerticalTrBar_Scroll(object sender, EventArgs e)
        {
            waterMarkLocationLbl.Text = "WaterMark location: " + horizontalTrBar.Value + ", " + (sender as TrackBar).Value;
        }

        /// <summary>
        /// Обработчик нажатия кнопки выбора цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorBtn_Click(object sender, EventArgs e)
        {
            // Keeps the user from selecting a custom color.
            colorDialog1.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            colorDialog1.ShowHelp = true;
            // Sets the initial color select to the current text color.
            colorDialog1.Color = colorBtn.BackColor;

            // Update the text box color if the user clicks OK 
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                waterMarkColor = colorBtn.BackColor = colorDialog1.Color;
        }
    }
}
