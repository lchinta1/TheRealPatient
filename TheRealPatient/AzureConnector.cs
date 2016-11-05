using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

namespace TheRealPatient
{
    class AzureConnector
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse
("DefaultEndpointsProtocol=https;AccountName=lalithsnosql;AccountKey=2Hx5jyzmbSA0UP+zIK+wbmWef4kbw2qUG3MCgKydD1opkC311V0eje9qTZ+97ND99FZwGgahyQZ0MTzXAw63bA==");

        

        public void store(PatientBasicInfo patientInfo)
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("patientinfo");
            table.CreateIfNotExistsAsync();

            TableOperation insertOperation = TableOperation.Insert(patientInfo);
            table.ExecuteAsync(insertOperation);

        }

        //0f9c53f1-0790-46a6-9578-8761740b8706
        public void get(String partitionKey)
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("patientinfo");

            TableOperation getOperation = TableOperation.Retrieve("memberPartition", "0f9c53f1-0790-46a6-9578-8761740b8706");

           // TableResult result = table.ExecuteAsync(getOperation);

        }


        public void saveUser(UserInfo user)
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("users");
            table.CreateIfNotExistsAsync();

            TableOperation ifExistsOperation = TableOperation.Retrieve<UserInfo>(user.PartitionKey, user.RowKey);
            //table.ExecuteAsync(ifExistsOperation);
            
            try
            {

                TableOperation insertOperation = TableOperation.Insert(user);
                table.ExecuteAsync(insertOperation);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error while saving the user");
                throw e;
            }
            //



            

        }

        public List<PatientBasicInfo> getAllPatients(String partitionKey)
        {

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("patientinfo");
            TableQuery<PatientBasicInfo> query = new TableQuery<PatientBasicInfo>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

           
            

            return null;
            
        }

    }
}
