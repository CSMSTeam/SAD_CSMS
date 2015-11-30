using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    List<Product> products;
    public List<Product> Products
    {
        get { return products; }
        set { products = value; }
    }

    string custOrderCode;
    public string CustOrderCode
    {
        get { return custOrderCode; }
        set { custOrderCode = value; }
    }

    DateTime orderDate;
    public DateTime OrderDate
    {
        get { return orderDate; }
        set { orderDate = value; }
    }

    string orderAddress;
    public string OrderAddress
    {
        get { return orderAddress; }
        set { orderAddress = value; }
    }

    string cusPhone;
    public string CusPhone
    {
        get { return cusPhone; }
        set { cusPhone = value; }
    }


	public Order()
	{
        products = new List<Product>();
        custOrderCode = genCode();
        orderDate = DateTime.Now;
        orderAddress = null;
        cusPhone = null;
	}

    public string genCode()
    {
        return String.Format("CUS{0}", DateTime.Now.Ticks % 10000);
    }
    public float getTotal()
    {
        float total = 0;
        foreach (Product product in products)
        {
            total = total + product.ProductPrice * product.ProductQuantity;
        }
        return total;
    }
    public void AddProductToOrder(Product product)
    {
        products.Add(product);
    }
   
}