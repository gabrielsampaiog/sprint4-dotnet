namespace _2TDPM.Services.Recommendation
{

    public class ViewedProduct
    {
        public string ClienteId { get; set; }
        public string ProdutoId { get; set; }
        public float ViewRelevance { get; set; }
    }
}
