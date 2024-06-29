using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjercitacionMVC.Services
{

    public interface IFormatNumber
    {
        string GetFormattedNumber(int number);
    }

    public class FormatNumber : IFormatNumber
    {
        public string GetFormattedNumber(int number)
        {
            return number.ToString("N");
        }
    }
}
