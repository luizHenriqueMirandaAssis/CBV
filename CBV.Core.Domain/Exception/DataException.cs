namespace CBV.Core.Domain.Exception
{
    public class DataException
    {
        public static void ThrowInsertException(string table, string error, string data)
        {
            throw new InsertException($"Não foi possível inserir na tabela: {table}, com o erro: {error} e os dados: {data}");
        }
    }

    public class InsertException : System.Exception
    {
        public InsertException(string message) : base(message)
        {

        }
    }
}
