//using System;
//using System.IO;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//delegate void TokenDelegate(Token token);
//delegate void DaneDoAutoryzacjiAplikacjiDelegate(string urlDoAkceptacjiAplikacji, bool rezultat);

//[DataContract]
//[Serializable]
//public class Token
//{
//    private Token() { }
//    [DataMember(Name = "access_token")]
//    public string TokenDostępu { get; set; }
//    [DataMember(Name = "refresh_token")]
//    public string TokenOdświeżający { get; set; }
//    [DataMember(Name = "token_type")]
//    public string TypTokenu { get; set; }
//    [DataMember(Name = "expires_in")]
//    public long WażnośćTokenu { get; set; }
//    [DataMember(Name = "scope")]
//    public string Zakres { get; set; }
//    [DataMember(Name = "jti")]
//    public string IdentyfikatorTokenu { get; set; }
//    [IgnoreDataMember]
//    public string NagłówekAutoryzacji => "Bearer " + TokenDostępu;
//    [IgnoreDataMember]
//    public string NagłówekOdświeżający => "refresh_token=" + TokenOdświeżający;
//    public override string ToString()
//    {
//        return "TokenOauth";
//    }
//}

//public class Odpowiedź
//{
//    public static Odpowiedź Inicjacja(HttpStatusCode status, bool rezultat, Stream strumień) => new Odpowiedź(status, rezultat, strumień);

//    public Stream Strumień { get; private set; }
//    public HttpStatusCode Status { get; private set; }
//    public bool RezultatOk { get; private set; }

//    private Odpowiedź(HttpStatusCode status, bool rezultat, Stream strumień)
//    {
//        Status = status;
//        Strumień = strumień;
//        RezultatOk = rezultat;
//    }
//}

//[DataContract]
//class DaneDoAutoryzacji
//{
//    private DaneDoAutoryzacji() { }
//    [DataMember(Name = "user_code")]
//    public string UserCode { get; set; }
//    [DataMember(Name = "device_code")]
//    public string DeviceCode { get; set; }
//    [DataMember(Name = "expires_in")]
//    public int ExpiresIn { get; set; }
//    [DataMember(Name = "interval")]
//    public int Interval { get; set; }
//    [DataMember(Name = "verification_uri")]
//    public string VerificationUri { get; set; }
//    [DataMember(Name = "verification_uri_complete")]
//    public string VerificationUriComplete { get; set; }
//}

//class MenadżerTokenów
//{
//    private SynchronizationContext sync;
//    internal Token Token { set; get; }
//    public MenadżerTokenów() => sync = SynchronizationContext.Current;

//    public async Task<bool> AutoryzujAplikacjęTypuDeviceFlow(string idKlienta, string sekretneIdKlienta, DaneDoAutoryzacjiAplikacjiDelegate daneDoAutoryzacjiCallBack, TokenDelegate tokenCallback)
//    {
//        bool rezultat = false;
//        var odp = await autoryzujAplikacjęTypuDeviceFlowAsync(idKlienta, sekretneIdKlienta);
//        if (odp.RezultatOk)
//        {
//            var objJson = deserializujJson<DaneDoAutoryzacji>(odp.Strumień);
//            sync.Send((o) => daneDoAutoryzacjiCallBack.Invoke(objJson.VerificationUriComplete, true), null);
//            Token = await odpytajSerwerOtoken(idKlienta, sekretneIdKlienta, objJson);
//            if (Token != null)
//            {
//                sync.Send((o) => tokenCallback.Invoke(Token), null);
//                rezultat = true;
//            }
//        }
//        else sync.Send((o) => daneDoAutoryzacjiCallBack.Invoke(null, false), null);
//        return rezultat;
//    }


//    private async Task<Odpowiedź> autoryzujAplikacjęTypuDeviceFlowAsync(string idKlienta, string sekretneIdKlienta)
//    {
//        var url = new Uri("https://allegro.pl/auth/oauth/device");
//        var pOauth = pobierzParametryAutoryzacji(idKlienta, sekretneIdKlienta);
//        var odp = await wyślijŻądanie(url, pOauth, "application/x-www-form-urlencoded", "client_id=" + idKlienta);
//        return odp;
//    }

//    private string pobierzParametryAutoryzacji(string idKlienta, string sekretneIdKlienta)
//    {
//        string idks = idKlienta + ":" + sekretneIdKlienta;
//        byte[] bajty = Encoding.UTF8.GetBytes(idks);
//        return "Basic " + Convert.ToBase64String(bajty);
//    }

//    private async Task<Token> odpytajSerwerOtoken(string idKlienta, string sekretneIdKlienta, DaneDoAutoryzacji dda)
//    {
//        return await Task.Run(async () =>
//        {
//            Token token = null;
//            Thread.Sleep(1000 * 15);
//            var rtdf = "https://allegro.pl/auth/oauth/token?grant_type=urn%3Aietf%3Aparams%3Aoauth%3Agrant-type%3Adevice_code&device_code=";
//            var url = new Uri(rtdf + dda.DeviceCode);
//            var oAuth = pobierzParametryAutoryzacji(idKlienta, sekretneIdKlienta);
//            while (true)
//            {
//                var odp = await wyślijŻądanie(url, oAuth, "application/json", "");

//                if (odp.RezultatOk)
//                {
//                    token = deserializujJson<Token>(odp.Strumień);
//                    break;
//                }
//                Thread.Sleep(1000 * dda.Interval);
//            }
//            return token;
//        });
//    }

//    private async Task<Odpowiedź> wyślijŻądanie(Uri url, string nagłówekAutoryzacji, string nagłówekAllegro, string dane)
//    {
//        HttpClient klient = new HttpClient();
//        klient.DefaultRequestHeaders.Clear();
//        klient.DefaultRequestHeaders.Add("Authorization", nagłówekAutoryzacji);
//        klient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("pl-PL"));
//        HttpResponseMessage odp = await post(klient, url, nagłówekAllegro, dane);
//        var odpowiedź = Odpowiedź.Inicjacja(odp.StatusCode, odp.IsSuccessStatusCode, odp.Content.ReadAsStreamAsync().Result);
//        return odpowiedź;
//    }

//    private async Task<HttpResponseMessage> post(HttpClient klient, Uri url, string nagłówekAllegro, string dane)
//    {
//        var content = new StringContent(dane, Encoding.UTF8, nagłówekAllegro);
//        return await klient.PostAsync(url, content);
//    }

//    #region serializacja i deserializacja JSON

//    private T deserializujJson<T>(Stream strumień)
//    {
//        var set = new DataContractJsonSerializerSettings
//        {
//            DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss.SSSZ"),
//        };
//        var serializator = new DataContractJsonSerializer(typeof(T), set);
//        T obiekt = (T)serializator.ReadObject(strumień);
//        strumień.Flush();
//        strumień.Close();
//        return obiekt;
//    }

//    #endregion
//}