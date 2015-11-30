using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    int productID;
    public int ProductID
    {
        get { return productID; }
        set { productID = value; }
    }

    string productName;
    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }

    float productPrice;
    public float ProductPrice
    {
        get { return productPrice; }
        set { productPrice = value; }
    }

    int productQuantity;
    public int ProductQuantity
    {
        get { return productQuantity; }
        set { productQuantity = value; }
    }
    
	public Product(int productid, string productname, float productprice, int productquantity)
	{
        productID = productid;
        productName = productname;
        productPrice = productprice;
        productQuantity = productquantity;
	}

    

}