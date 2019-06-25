using CBV.Core.Application.Interfaces.Handle;
using Newtonsoft.Json;
using System;

namespace CBV.Infra.Json.Handle
{
    public class JsonHandle: IJsonHandle
    {
        public T DeserializeObject<T>(string stringJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(stringJson);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }    
    }
}
