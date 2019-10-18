using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ResetAPI
{
    class getMainCategories
    {
        public string MainCategories(string resClien)
        {
            string strResponseValue = string.Empty;
            string uriCategories = "https://api.allegro.pl.allegrosandbox.pl/sale/categories";
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(uriCategories);
            //присваеваем переменной логин и пороль конвентируем в байс64 

            var newClient = jesonFormatter.

            // присваеваем все знаяения в переменную и высылаем на сервер
            request2.Headers.Add($"Authorization: Bearer {resClien} " +
                                 " Accept: application/vnd.allegro.public.v1+xml");
            //request2.Headers.Add($"Authorization: Bearer {resClien}", "Accept: application/vnd.allegro.public.v1+json");
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request2.GetResponse();

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
            return strResponseValue;
        }
    }
}
