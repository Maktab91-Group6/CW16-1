using System.Numerics;

namespace CW16.Entity
{
	public static class DataStorage
	{

		public static List<Product> Products { get; set; }


		static DataStorage()
		{
			Products = new List<Product>();
			Products.Add(new Product()
			{
				Name = "کالای شماره یک",
				Color = "قرمز",
				Quantity = 10,
				UnitPrice = 1000
			});
			Products.Add(new Product()
			{
				Name = "کالای شماره دو",
				Color = "آبی",
				Quantity = 30,
				UnitPrice = 500
			});
			Products.Add(new Product()
			{
				Name = "کالای شماره سه",
				Color = "مشکی",
				Quantity = 5,
				UnitPrice = 700
			});
			Products.Add(new Product()
			{
				Name = "کالای شماره چهار",
				Color = "زرشکی",
				Quantity = 20,
				UnitPrice = 100
			});



		}
	}
}