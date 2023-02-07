using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using MongoDB.Bson;
using MongoDB.Driver;
using UserInformation.Models;

namespace UserInformation.Controllers
{
	public class UsersController : Controller
	{
        private readonly IMongoCollection<BsonDocument> _userService;
        private readonly IMongoCollection<User> _users;

        public UsersController(IUserDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userService = database.GetCollection<BsonDocument>(settings.CollectionName);
			_users = database.GetCollection<User>(settings.CollectionName);
        }
		// GET: UsersController

		public ActionResult Index()
		{
			string dateTime = DateTime.Now.ToString();
			string ipAddress = Response.HttpContext.Connection.RemoteIpAddress.ToString();
			var userInfo = new BsonDocument { { "dateTime", dateTime }, { "ipAddress", ipAddress } };
			_userService.InsertOne(userInfo);            
			return View();
		}

		public ActionResult Privacy()
		{
            var userInfo = _users.Find(user => true).ToList();
            //var userInfo = _users.Find(user => user.DateAndTime).ToList();
            return View(userInfo);
		}
	}
}
