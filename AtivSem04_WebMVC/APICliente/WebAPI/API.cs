using System.IO;
using System.Net;

namespace APICliente.WebAPI
{
    public class API
    {
        private readonly static string URI = "https://localhost:44325/api/LimiteCliente/";

        //Método responsável pelo "GET"
        public static string RequestGET(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI+id);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        //Método responsável pelo "PATCH"
        public static string RequestPATCH(int id, double valor)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI+id+"/decrementa/"+valor);
            request.Method = "PATCH";
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
