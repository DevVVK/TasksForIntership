using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Users.BLL.BusinessModels.Date
{
    public class DateForm
    {
        public int Year { get; set; }

        public string Month { get; set; }

        public int Day { get; set; }

        public DateForm()
        {
            
        }
    }
}