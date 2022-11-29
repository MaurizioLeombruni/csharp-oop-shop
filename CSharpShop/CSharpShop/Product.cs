using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShop
{
    public class Product
    {
        private int productCode;
        private string productName = "none";
        private string productDescription = "none";
        private float productPriceBase;
        private float productPriceVAT = 0.22f;

        public int GetProductCode()
        {
            return productCode;
        }

        public string GetProductName()
        {
            return productName;
        }

        public string GetProductDescription()
        {
            return productDescription;
        }

        public float GetProductPriceBase()
        {
            return productPriceBase;
        }

        public float GetProductPriceVAT()
        {
            return productPriceVAT;
        }
        public float GetProductPriceTotal()
        {
            float tempPrice;

            tempPrice = (float)(productPriceBase * productPriceVAT);
            return tempPrice;
        }

        public void SetProductCode(int num)
        {
            if(num <= 0 || num.ToString().Length > 9)
            {
                if(productCode == 0)
                {
                    Console.WriteLine("Invalid user input, generating default solution...");
                    //Generate random code
                } else
                {
                    Console.WriteLine("Invalid user input, skipping command...");
                }
            }
            else
            {
                if(productCode!= 0)
                {
                    Console.WriteLine("Product code reset. Old code was: " + productCode);
                    productCode = num;
                    //Generate padding
                }
            }
        }
    }
}
