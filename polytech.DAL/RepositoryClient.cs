using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using polytech.DAL.model;
namespace polytech.DAL
{
    public class RepositoryClient
    {
        private readonly string path;
        public RepositoryClient(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) 
                    throw new ArgumentNullException("Путь к базе данных не может быть пустым.");
            
            this.path = path;
        }
        public ReturnResultClient GetAllClient()
        {
            ReturnResultClient result = new ReturnResultClient();
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    result.Clients = db.GetCollection<Client>("Client").FindAll().ToList();
                }
            }
            catch(LiteException ex) 
                when(string.IsNullOrWhiteSpace(path))
            {
                result.Exception = ex;
                result.IsError = true;
            }
            catch (Exception ex)
            {
                result.Exception=ex;
                result.IsError = true;
            }
            return result;
        }
        public ReturnResultClient GetClientById(int Id)
        {
            ReturnResultClient result = new ReturnResultClient();
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    result.Client = db.GetCollection<Client>("Client")
                        .FindById(Id);
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.IsError = true;
            }
            return result;
        }

        public ReturnResultClient CreateClient(Client client)
        {
            ReturnResultClient result = new ReturnResultClient();
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    var cl = db.GetCollection<Client>("Client");
                    cl.Insert(client);
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.IsError = true;
            }
            return result;
        }

        public ReturnResultClient GetClient(string email, string password)
        {
            ReturnResultClient result = new ReturnResultClient();
            try
            {
                using (LiteDatabase db = new LiteDatabase(path))
                {
                    result.Client =
                    db.GetCollection<Client>("Client").FindAll()
                        .First(f => f.Email == email && f.Password == password);

                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.IsError = true;
            }
            return result;
        }
    }
}
