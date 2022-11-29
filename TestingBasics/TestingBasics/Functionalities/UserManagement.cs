namespace TestingBasics.Functionalities
{
    //public record User(string FirstName, string LastName)
    //{
    //    public int Id { get; init; }
    //    public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
    //    public string Phone { get; set; } = "+44 ";
    //    public bool VerifiedEmail { get; set; } = false;
    //}

    //public class UserManagement
    //{
    //    private readonly List<User> users = new();
    //    private int idCounter = 1;

    //    public IEnumerable<User> AllUsers => users; 

    //    public void Add(User user)
    //    {
    //        users.Add(user with { Id = idCounter++ });
    //    }

    //    public void UpdatePhone(User user)
    //    {
    //        User dbUser = users.First(x => x.Id == user.Id);
    //        dbUser.Phone = user.Phone;
    //    }

    //    public void VerifyEmail(int id)
    //    {
    //        User dbUser = users.First(x => x.Id == id);
    //        dbUser.VerifiedEmail = true;
    //    }
    //}

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
