namespace TestingBasics.Functionalities
{
    public record Product(int Id, string Name, double price);

    public interface IDbService
    {
        bool SaveShoppingCartItem(Product product);
        bool RemoveShoppingCartItem(int? id);
    }

   public class ShoppingCard
    {
        private IDbService _dbservice;

        public ShoppingCard(IDbService dbservice)
        {
            _dbservice = dbservice;
        }

        public bool AddProduct(Product product)
        {
            if (product == null || product.Id == 0) return false;
            _dbservice.SaveShoppingCartItem(product);
            return true;
        }

        public bool RemoveProduct(int? id)
        {
            if (id == null || id == 0) return false;
            _dbservice.RemoveShoppingCartItem(id);
            return true;
        }
    }
}
