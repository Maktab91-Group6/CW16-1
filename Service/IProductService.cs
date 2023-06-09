﻿using CW16.Entity;

namespace CW16.Service
{
	public interface IProductService
	{

		public void Create(Product product);

		public void Edit(int id, string name, int quantity, string color, int unitPrice);

		public void Delete(int id);

		public Product? GetById(int id);

		public List<Product> GetAll();

		public void AddToCart(int id);

		public List<Product> GetProductsForCart();

		public void DeleteFromCart(int id);


	}
}
