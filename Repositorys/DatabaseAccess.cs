using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularWebApp.Learninghelp;
using AngularWebApp.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApp.Repositorys
{
    public class DatabaseAccess
    {
        private readonly string Project = "angularcore-37326";

        public DatabaseAccess() {
            CreateDbConnection();
        }

        private void CreateDbConnection()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"angularcore.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        }

        public async Task<List<CalculationDetailDTO>> GetCalculation()
        {
            FirestoreDb db = FirestoreDb.Create(Project);
            CollectionReference collection = db.Collection("Calculations");
            QuerySnapshot snapshot = await collection.GetSnapshotAsync();
            if(snapshot == null)
            {
                throw new ArgumentException("No Calculations found");
            }
            else
            {
                var response = new List<CalculationDetailDTO>();
                var documentsLength = snapshot.Documents.Count;
                for (var index = 0; index < documentsLength; index++)
                {
                    var item = snapshot.Documents[index].ConvertTo<CalculationDetailDTO>();
                    item.Id = snapshot[index].Id;
                    response.Add(item);
                }
                return response;
            }
        }

        // some methods are not finished yet.
        // this will be done soon
        public async Task<CalculationDetailDTO> GetCalculationById(string Id)
        {
            FirestoreDb db = FirestoreDb.Create(Project);
            DocumentReference document = db.Collection("Calculations").Document(Id);
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();
            return snapshot.ConvertTo<CalculationDetailDTO>();
        }
        public async Task<CalculationDetailDTO> AddCalculation(CalculationDbDTO calculation)
        {
            FirestoreDb db = FirestoreDb.Create(Project);
            CollectionReference collection = db.Collection("Calculations");
            DocumentReference document = await collection.AddAsync(calculation);
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();
            var output = snapshot.ConvertTo<CalculationDetailDTO>();
            output.Id = document.Id;
            return output;
        }
        public async Task<CalculationDetailDTO> ChangeCalculationById(string Id, CalculationDbDTO calculation)
        {
            FirestoreDb db = FirestoreDb.Create(Project);
            DocumentReference calcRef = db.Collection("Calculations").Document(Id); 
             await calcRef.SetAsync(calculation);
            DocumentSnapshot snapshot = await calcRef.GetSnapshotAsync();
            return snapshot.ConvertTo<CalculationDetailDTO>();


        }
        public async Task DeleteCalculationWithId(string Id)
        {
            FirestoreDb db = FirestoreDb.Create(Project);
            DocumentReference document = db.Collection("Calculations").Document(Id);
            await document.DeleteAsync();
            
        }

        public async Task<Hint> CheckDbForHint(string[] searchterms)
        {

            //logic to search in cloud for any matches
            //just placeholder for now
            return new Hint();
        }
    }
}
