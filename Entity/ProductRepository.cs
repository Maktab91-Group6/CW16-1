using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace CW16.Entity
{
	public class ProductRepository:IProductRepository
	{
		private readonly string connectionString;

		public ProductRepository(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("ConnectionOne");
		}

		public void AddToCartProduct(int id)
		{
			string queryString = "Insert Into ProductCart Values(@CustomerId, @ProductId)";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();
				SqlCommand command = new SqlCommand(queryString, connection);
				command.Parameters.Add(new SqlParameter("CUstomerId", 1));
				command.Parameters.Add(new SqlParameter("ProductId", id));



				SqlDataReader reader = command.ExecuteReader();



				reader.Close();
			}

		}

		public void Create(Product product)
		{
			List<Product> products = new List<Product>();

			string queryString = "Insert Into Products Values(@name, @quantity, @color, @unitPrice)";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();
				SqlCommand command = new SqlCommand(queryString, connection);
				command.Parameters.Add(new SqlParameter("name", product.Name));
				command.Parameters.Add(new SqlParameter("quantity", product.Quantity));
				command.Parameters.Add(new SqlParameter("color", product.Color));
				command.Parameters.Add(new SqlParameter("unitPrice", product.UnitPrice));



				SqlDataReader reader = command.ExecuteReader();



				reader.Close();
			}



		}

		public void Delete(int id)
		{
			List<Product> products = new List<Product>();

			string queryString = "Delete FROM Products Where Id=@id ";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();
				SqlCommand command = new SqlCommand(queryString, connection);
				command.Parameters.Add(new SqlParameter("id", id));
				SqlDataReader reader = command.ExecuteReader();
				reader.Close();
			}

		}
		//ADO.NET Method
		//public void Edit(int id, string name, int quantity, string color, int unitPrice)
		//{

		//	string queryString = "Update Products Set Name=@name, Quantity=@quantity, Color=@color, UnitPrice=@unitPrice Where Id=@id";

		//	using (SqlConnection connection = new SqlConnection())
		//	{
		//		connection.ConnectionString = connectionString;
		//		connection.Open();
		//		SqlCommand command = new SqlCommand(queryString, connection);
		//		command.Parameters.Add(new SqlParameter("id", id));
		//		command.Parameters.Add(new SqlParameter("name", name));
		//		command.Parameters.Add(new SqlParameter("quantity", quantity));
		//		command.Parameters.Add(new SqlParameter("color", color));
		//		command.Parameters.Add(new SqlParameter("unitPrice", unitPrice));



		//		SqlDataReader reader = command.ExecuteReader();



		//		reader.Close();
		//	}

		//}


		//Dapper Method
		public void Edit(int id, string name, int quantity, string color, int unitPrice)
		{

			string commandString = "Update Products Set Name=@name, Quantity=@quantity, Color=@color, UnitPrice=@unitPrice Where Id=@id";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();

				connection.Query(commandString,
					new {id=id ,name = name, quantity = quantity, color = color, unitPrice = unitPrice });

			}

		}


		public List<Product> GetAll()
		{
			List<Product> products = new List<Product>();

			string queryString = "SELECT * FROM Products";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();
				SqlCommand command = new SqlCommand(queryString, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					products.Add(new Product()
					{
						Id = Convert.ToInt32(reader["Id"]),
						Name = reader["Name"].ToString(),
						Color = reader["Color"].ToString(),
						Quantity = Convert.ToInt32(reader["Quantity"]),
						UnitPrice = Convert.ToInt32(reader["UnitPrice"])

					});



				}

				reader.Close();
			}

			return products;
		}

		public Product? GetById(int id)
		{

			List<Product> products = new List<Product>();

			string queryString = "SELECT * FROM Products Where Id=@id";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();
				SqlCommand command = new SqlCommand(queryString, connection);
				command.Parameters.Add(new SqlParameter("id",id));
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					products.Add(new Product()
					{
						Id = Convert.ToInt32(reader["Id"]),
						Name = reader["Name"].ToString(),
						Color = reader["Color"].ToString(),
						Quantity = Convert.ToInt32(reader["Quantity"]),
						UnitPrice = Convert.ToInt32(reader["UnitPrice"])

					});



				}

				reader.Close();
			}

			return products.FirstOrDefault();
		}

		public List<Product> GetProductForCart()
		{
			List<Product> products = new List<Product>();

			string queryString = "SELECT * FROM Products p JOIN ProductCart pc ON p.Id=pc.ProductId";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();
				SqlCommand command = new SqlCommand(queryString, connection);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					products.Add(new Product()
					{
						Id = Convert.ToInt32(reader["Id"]),
						Name = reader["Name"].ToString(),
						Color = reader["Color"].ToString(),
						Quantity = Convert.ToInt32(reader["Quantity"]),
						UnitPrice = Convert.ToInt32(reader["UnitPrice"])
					});
				}

				reader.Close();
			}
			return products;
		}

		public void DeleteFromCart(int id)
		{
			string queryString = "DELETE FROM ProductCart WHERE ProductId=@id";

			using (SqlConnection connection = new SqlConnection())
			{
				connection.ConnectionString = connectionString;
				connection.Open();
				SqlCommand command = new SqlCommand(queryString, connection);
				command.Parameters.Add(new SqlParameter("id", id));
				SqlDataReader reader = command.ExecuteReader();
				reader.Close();
			}
		}

	}
}
