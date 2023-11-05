namespace PriceHunterFilter.Services
{
    internal interface IRabbitMqService
    {
        void Consume(HandleProduct handleProductDel);
    }
}