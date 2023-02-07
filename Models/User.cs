using MongoDB.Bson.Serialization.Attributes;

namespace UserInformation.Models
{
	[BsonIgnoreExtraElements]
	public class User
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("dateTime")]
		public string DateAndTime { get; set; }

		[BsonElement("ipAddress")]
		public string IpAddress { get; set; }
	}
}
