using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace ExequteQuery.Models
{
    public class Context
    {
        IGridFSBucket GridFS;
        IMongoCollection<Product> ProductsList { get; set; }
        IMongoCollection<Category> CategoriesList { get; set; }
       
        private string _ConnectionString;
        public string ConnectionString
        {
            set
            {
                if (value.Length != 0)
                {
                    _ConnectionString = value;
                }
            }
            get
            {
                return _ConnectionString;
            }
        }
        public Context()
        {
            GetConnection();
            var connention = new MongoUrlBuilder(ConnectionString);
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(connention.DatabaseName);
            GridFS = new GridFSBucket(db);
            ProductsList = db.GetCollection<Product>("Products");
            CategoriesList = db.GetCollection<Category>("Categories");
        }
        public void GetConnection()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDbConnectionString"].ConnectionString;

        }
        public void InsertCategory(Category cat)
        {
           var f =  Task.Factory.StartNew(() => CategoriesList.InsertOneAsync(cat));
            f.Wait();
            //CategoriesList.InsertOneAsync(cat);
        }
        public List<Category> GetAllCategories()
        {
            var query = CategoriesList.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        } 
        public Category GetCategoryById(string id)
        {
           var Category = CategoriesList.Find(new BsonDocument { { "_id", new ObjectId(id) } })
                    .FirstAsync();
            Category.Wait();
            return Category.Result;
        }
        public void UpdateProduct(string id, Category category)
        {
            category.id = new ObjectId(id);
            var filter = Builders<Category>.Filter.Eq(s => s.id, category.id);
            CategoriesList.ReplaceOneAsync(filter, category);
        }
        public void RemoveCategory(string id)
        {
            Category category = new Category();
            category.id = new ObjectId(id);
            var filter = Builders<Category>.Filter.Eq(s => s.id, category.id);
            CategoriesList.DeleteManyAsync(filter);
        }
        public void AddProduct(Product product)
        {
           
        }
        public List<Product> GetAllProducts()
        {
            var query = ProductsList.Find(new BsonDocument()).ToListAsync();
            return query.Result;
           // var query = (from a in ProductsList.AsQueryable<Product>().Select() select a).Join(from b in CategoriesList.AsQueryable<Category>() select b);

            
        }
    }
}