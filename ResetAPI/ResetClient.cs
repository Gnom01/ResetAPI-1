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

    class ResetClient
    {
        // создаение переменной для адрисса 
        public string endPoint { get; set; }
        // создание переменной для метода енум перечесления команд
        public httpVerb httpMethod { get; set; }
        // конструктор
        public ResetClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }
        //метод связи с базой данных
        public string makeRequest()
        { 
            //создаем перемменную типа стринг с пустой строкой
            string strResponseValue = string.Empty;
            //создаем перемменную типа веб рекюст и вставляем ендпоинт это адрес сайта конвентируем в перемменную 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            //присваеваем в переменную запрос GET с сервера
            request.Method = httpMethod.ToString();
            
            //значение using для сравненеие создаем переменной типа HttpWebResponse и присваеваем значение с сервера
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {   // проверка если ответ с серверра о статусе не ОК тогда выводим сообщение об ошибки
                if (response.StatusCode != HttpStatusCode.OK)
                {// вывод исключения и сообщение полученное из сервера
                    throw new ApplicationException("error code: " + response.StatusCode.ToString());
                }
                //создаем переменную типа Stream и подоем в нее сообщение полученное из сервера в байтах
                using (Stream responseStream = response.GetResponseStream())
                {// проверка если переммкнная не пустая тогда заходим в код
                    if(responseStream != null)
                    {//создаем перемменную типа StreamReader который считываес последовательно все байты и передаем в нее responseStream который явояется тип Stream
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            //присваеваем стринговой переменной значение считанное из сервера
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            // возврат считанной информации обратно в форму
         return strResponseValue;
        }
    }
}
