using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace TAQUI.Model
{
    [Collection("clienteView")]
    public class ClienteView
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ClienteId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProdutoId { get; set; }

        public DateTime ViewedAt { get; set; } = DateTime.Now;

    }
}
