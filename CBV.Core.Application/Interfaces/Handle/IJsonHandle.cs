namespace CBV.Core.Application.Interfaces.Handle
{
    public interface IJsonHandle
    {
        T DeserializeObject<T>(string stringJson);
        string SerializeObject(object obj);
    }
}
