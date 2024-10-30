using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using MongoDB.Bson;
using TAQUI.Model;


namespace _2TDPM.Services.Recommendation
{
    public class RecommendationEngine
    {
        private readonly MLContext _mlContext = new MLContext();
        private ITransformer _model;


        public void PrepareTrainModel(IEnumerable<ClienteView> allclienteViews)
        {
            var productViewing = new List<ViewedProduct>();
            foreach (var clienteView in allclienteViews)
            {
                productViewing.Add(new ViewedProduct
                {
                    ClienteId = clienteView.ClienteId,
                    ProdutoId = clienteView.ProdutoId,
                    ViewRelevance = 1
                });
            }

            Train(productViewing);
        }

        private void Train(List<ViewedProduct> productViewing)
        {
            IDataView trainingData = _mlContext.Data.LoadFromEnumerable(productViewing);

            var pipeline = _mlContext
                            .Transforms
                            .Conversion
                            .MapValueToKey(outputColumnName: "clienteIdEncoded", inputColumnName: nameof(ViewedProduct.ClienteId))
                            .Append(
                                _mlContext
                                .Transforms
                                .Conversion
                                .MapValueToKey(outputColumnName: "productIdEncoded", inputColumnName: nameof(ViewedProduct.ProdutoId)))
                            .Append(_mlContext
                                    .Recommendation()
                                    .Trainers
                                    .MatrixFactorization(
                                        labelColumnName: nameof(ViewedProduct.ViewRelevance),
                                        matrixColumnIndexColumnName: "clienteIdEncoded",
                                        matrixRowIndexColumnName: "productIdEncoded"));

            _model = pipeline.Fit(trainingData);
        }

        public float Predict(ObjectId clienteId, ObjectId productId)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ViewedProduct, ProductPrediction>(_model);

            var prediction = predictionEngine.Predict(new ViewedProduct
            {
                ClienteId = clienteId.ToString(),
                ProdutoId = productId.ToString()
            });

            return prediction.Score;
        }

        class ProductPrediction
        {
            public float Score { get; set; }
        }
    }
}
