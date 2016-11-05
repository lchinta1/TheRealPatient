using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

namespace TheRealPatient
{
    class UserInfo : TableEntity
    {
        public String userName { get; set; }
        public String password { get; set; }
        public List<PatientBasicInfo> memberList = new List<PatientBasicInfo>();

        public void addPatientInfo(PatientBasicInfo patientInfo)
        {
            memberList.Add(patientInfo);
        }

        public List<PatientBasicInfo> getPatientsList()
        {
            return memberList;
        }

        public UserInfo()
        {
            this.PartitionKey = "userPartition";
            this.RowKey = userName;
            System.Diagnostics.Debug.WriteLine("User RowKey : " + this.RowKey);
        }

    }
}
