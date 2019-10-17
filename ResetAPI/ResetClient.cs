using System;
using System.IO;
using System.Net;

namespace ResetAPI
{   // класс перечесления для команд которые высыляют на сервер
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum autenfikationType
    {
        Basic,
        NTLM
    }
    public enum autenfikationTechnique
    {
        RollYourOwn,
        NetworkCredential
    }

    class ResetClient
    {
        // создаение переменной для адрисса 
        public string endPoint { get; set; }
        // создание переменной для метода енум перечесления команд
        public httpVerb httpMethod { get; set; }
        public autenfikationType authType { get; set; }
        public autenfikationTechnique autTrech { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }


        // конструктор
        public ResetClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.POST;
        }
        //метод связи с базой данных
        public string makeRequest()
        { 
            //создаем перемменную типа стринг с пустой строкой
            string strResponseValue = string.Empty;
            //создаем перемменную типа веб рекюст и вставляем ендпоинт это адрес сайта конвентируем в перемменную 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            
            //присваеваем в переменную запрос GET на сервера
            request.Method = httpMethod.ToString();
            //присваеваем переменной логин и пороль конвентируем в байс64 
            String authHeaer = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(userName + ":" + userPassword));
            // присваеваем все знаяения в переменную и высылаем на сервер
            request.Headers.Add("Authorization:"+ authType.ToString() +" " + authHeaer);

            //значение using для сравненеие создаем переменной типа HttpWebResponse и присваеваем значение с сервера
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                
                //создаем переменную типа Stream и подоем в нее сообщение полученное из сервера в байтах
                using (Stream responseStream = response.GetResponseStream())
                {// проверка если переммкнная не пустая тогда заходим в код
                    if (responseStream != null)
                    {//создаем перемменную типа StreamReader который считываес последовательно все байты и передаем в нее responseStream который явояется тип Stream
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            //присваеваем стринговой переменной значение считанное из сервера
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            // возврат считанной информации обратно в форму
         return strResponseValue;
        }
    }
}
