using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

namespace TheRealPatient
{
    class PatientBasicInfo : TableEntity
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public String SSN { get; set; }
        public Decimal height { get; set; }
        public Decimal weight { get; set; }
        public String gender { get; set; }
        public PatientBasicInfo()
        {
            this.PartitionKey = "memberPartition";
            this.RowKey = System.Guid.NewGuid().ToString();
            System.Diagnostics.Debug.WriteLine("Patient RowKey : " + this.RowKey);
        }

    }

}
