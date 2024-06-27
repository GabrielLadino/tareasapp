namespace tarea.Models
{
    public class ResultadoModel<T>
    {

        public bool Ok { get; set; }
        public int Codigo { get; set; }
        public string MensajeError { get; set; } = "";
        public T Data { get; set; }


        public static ResultadoModel<T> Success(T data, string mensajeError = "")
        {
            if (data == null)
            {
                return Error("Ocurrio un error");
            }
            return new ResultadoModel<T> { Data = data, MensajeError = mensajeError, Ok = true, Codigo = 200 };
        }


        public static ResultadoModel<T> Error(string mensaje, int codigo = 400, T data = default)
        {
            return new ResultadoModel<T> { Data = data, MensajeError = mensaje, Ok = false, Codigo = codigo };
        }
    }
}
