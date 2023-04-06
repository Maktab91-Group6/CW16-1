using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CW16.Entity
{
	public class Product
	{
		[Display(Name = "نام یکتا")]
		public int Id { get; set; }
		[Display(Name = "نام محصول")]
		public string Name { get; set; }
		[Display(Name = "تعداد محصول")]
		public int Quantity { get; set; }
		[Display(Name = "رنگ محصول")]
		public string Color { get; set; }
		[Display(Name = "قیمت واحد")]
		public int UnitPrice { get; set; }




	}
}
