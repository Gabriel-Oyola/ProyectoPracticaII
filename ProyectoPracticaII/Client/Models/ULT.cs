namespace ProyectoPracticaII.Client.Models
{
    public class ULT
    {
        public string correo { get; set; }


        public void GuardarDato(string dato)
        {
            correo = dato;
        }

        public string ObtenerDato()
        {
            return correo;
        }
    }
}
