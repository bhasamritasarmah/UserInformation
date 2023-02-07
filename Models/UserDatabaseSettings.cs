using MongoDB.Driver.Core.Configuration;

namespace UserInformation.Models
{
	public class UserDatabaseSettings : IUserDatabaseSettings
	{
		public string ConnectionString { get; set; } = String.Empty;
		public string DatabaseName { get; set; } = String.Empty;
		public string CollectionName { get; set; } = String.Empty; 
	}
}
