using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TAQUI.Model
{
    [Collection("cliente")]
    public class Cliente
    {

        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("ds_user")]
        public string DsUser { get; set; }

        [BsonElement("ds_senha")]
        public string DsSenha { get; set; }

        [BsonElement("ds_email")]
        public string DsEmail { get; set; }

        [BsonElement("ds_cpf")]
        public string DsCpf { get; set; }

        [BsonElement("nm_logradouro")]
        public string NmLogradouro { get; set; }

        [BsonElement("nr_cep")]
        public string NrCep { get; set; }

        [BsonElement("nm_bairro")]
        public string NmBairro { get; set; }

        [BsonElement("localidade")]
        public string Localidade { get; set; }

        [BsonElement("sg_estado")]
        public string SgEstado { get; set; }

        [BsonElement("nm_estado")]
        public string NmEstado { get; set; }
    }
}
