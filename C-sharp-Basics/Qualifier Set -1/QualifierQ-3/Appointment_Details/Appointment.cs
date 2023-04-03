using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Details
{
    public class Appointment
    {
        public string PatientName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }

        public Appointment(string patientName, string date, string time, string reason)
        {
            this.PatientName = patientName;
            this.Date = date;
            this.Time = time;
            this.Reason = reason;
        }
    }
}
