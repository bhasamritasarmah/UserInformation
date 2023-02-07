namespace UserInformation.Models
{
	public interface IUserDatabaseSettings
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
		string CollectionName { get; set; }
	}
}
