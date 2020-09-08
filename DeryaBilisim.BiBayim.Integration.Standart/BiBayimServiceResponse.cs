using System.Collections.Generic;

namespace DeryaBilisim.BiBayim.Integration.Standart
{
    public partial class BiBayimServiceResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string internalMessage { get; set; }
        public T data { get; set; }
        public List<object> errors { get; set; }

        public BiBayimServiceResponse()
        {
            errors = new List<object>();
        }
    }
}