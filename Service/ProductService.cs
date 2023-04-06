using CW16.Entity;
using System.Xml.Linq;

namespace CW16.Service
{
	public class ProductService:IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public void Create(Product product)
		{
			_productRepository.Create(product);
		}

		public void Edit(int id, string name, int quantity, string color, int unitPrice)
		{
			_productRepository.Edit(id,name,quantity,color,unitPrice);
		}

		public void Delete(int id)
		{
			_productRepository.Delete(id);
		}

		public Product? GetById(int id)
		{
			return _productRepository.GetById(id);
		}

		public List<Product> GetAll()
		{
			return _productRepository.GetAll();
		}
	}
}
