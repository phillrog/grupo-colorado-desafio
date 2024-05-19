using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Client.Web.Utils
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        public static void GravarMensagem(this ITempDataDictionary tempData, string tipo, string mensagem)
        {
            tempData.Put<Message>("StatusMessage", new Message { Tipo = tipo, Mensagem = mensagem });
        }

        public static void Limpar(this ITempDataDictionary tempData)
        {
            foreach (var key in tempData.Keys.ToList())
            {
                tempData.Remove(key);
            }
            tempData.Clear();
        }
    }
}
