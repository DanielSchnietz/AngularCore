using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularWebApp.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApp.Repositorys
{
    public class DatabaseAccess
    {
        private readonly string Project;

        public DatabaseAccess() {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"angularcore.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            Project = "angularcore-37326";
        }

        public async Task<List<CalculationDetailDTO>> GetCalculation()
        {
            List<CalculationDetailDTO> output = new List<CalculationDetailDTO>();
            FirestoreDb db = FirestoreDb.Create(Project);
            CollectionReference collection = db.Collection("Calculations");
            QuerySnapshot snapshot = await collection.GetSnapshotAsync();
            var index = 0;
            foreach ( DocumentSnapshot document in snapshot.Documents)
            {
                var item = document.ConvertTo<CalculationDetailDTO>();
                item.Id = snapshot[index].Id;
                output.Add(item);
                index++;
            }
            return output;
        }

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
    }
}
