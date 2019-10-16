using System;
using System.Windows.Forms;

namespace ResetAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void StartButton_Click(object sender, EventArgs e)
        {   // создаем переменную типа ресетклиента 
            ResetClient rClient = new ResetClient();
            // присвоение адреса сайта в переменную
            rClient.endPoint = textBox2.Text;
            // запускаем метод и передаем текст в него
            debugOuput("Rest Client Created");// клиент ресет создан
            //создаем перемменную и присваеваем пустую строчку
            string strResponse = string.Empty;
            //присваеваем перемменной значение ответ который пришол из сервера
            strResponse = rClient.makeRequest();
            //запускаем вывод в консоль в текст бокс полученную информацию из сервера
            debugOuput(strResponse);

        }
        //метод вывода текста на форму
        private void debugOuput (string strDebagText)
        {
            try//проверка на ошибку
            {   // проверка и отладка кода полученного с сервера
                System.Diagnostics.Debug.Write(strDebagText + Environment.NewLine);
                // 
                textResponse.Text = textResponse.Text + strDebagText + Environment.NewLine;
                textResponse.SelectionStart = textResponse.TextLength;
                textResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }

        }


    }
}
