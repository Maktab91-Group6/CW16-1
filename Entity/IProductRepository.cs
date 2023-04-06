namespace CW16.Entity
{
	public interface IProductRepository
	{


		public void Create(Product product);

		public void Edit(int id, string name, int quantity, string color, int unitPrice);

		public void Delete(int id);

		public Product? GetById(int id);

		public List<Product> GetAll();




	}
}
