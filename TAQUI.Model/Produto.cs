using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TAQUI.Model
{
    [Collection("produto")]
    public class Produto
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("nome")]
        [Required]
        public string Nome { get; set; }

        [BsonElement("preco")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Preco { get; set; }

        [BsonElement("estoque")]
        public int Estoque { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; }
    }
}
