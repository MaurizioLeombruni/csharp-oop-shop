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
        private string productCodeCompiled;
        private string productName;
        private string productDescription;
        private float productPriceBase;
        private float productPriceVAT;

        //COSTRUTTORE: Il prodotto viene dichiarato immettendone nome, descrizione e prezzo di base.
        //Il codice e la sua versione compilata vengono instanziati in automatico, e il valore IVA (VAT in inglese) è di default messo a 0.22 (22% è l'IVA standard italiana,
        //almeno a quanto dice Wikipedia kek)

        public Product(string name, string description, float basePrice)
        { 
            this.productName = name;    
            this.productDescription = description;
            this.productPriceBase = basePrice;
            this.productPriceVAT = 0.22f;

            productCode = GenerateProductCode();
            productCodeCompiled = GeneratePaddedCode(productCode);
        }

        //Funzioni getter. Restituiscono il valore della loro proprietà.
        public int GetProductCode()
        {
            return productCode;
        }

        public string GetPaddedCode()
        {
            return productCodeCompiled;
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

        //Ritorna un nome esteso concatenando il codice prodotto e il suo nome.
        public string GetExtendedName()
        {
            return productCodeCompiled + productName;
        }

        //Il prezzo totale viene calcolato moltiplicando il prezzo base per 1 + IVA. Restituisce il prezzo con il markup indicato.
        //Un casting float impedisce alla funzione di sbarellare e restituire un double.
        public float GetProductPriceTotal()
        {
            float tempPrice;

            tempPrice = (float)(productPriceBase * (1 + productPriceVAT) );
            return tempPrice;
        }

        //Stampa il prezzo base del prodotto.
        public void PrintBasePrice()
        {
            Console.WriteLine("Il prezzo base del prodotto è: " + productPriceBase + " euro");
        }

        //Stampa il prezzo totale del prodotto. L'IVA viene stampata insieme al prezzo finale, in forma percentuale.
        public void PrintPriceTotal()
        {
            int percentVAT = (int)(productPriceVAT * 100);
            float priceTotal = GetProductPriceTotal();

            Console.WriteLine("Con un'IVA del " + percentVAT + "%, il prezzo totale è: " + String.Format("{0:.00}", priceTotal) + " euro");
        }

        public void PrintProductDetails()
        {
            Console.WriteLine("Nome prodotto: " + GetProductName());
            Console.WriteLine("Codice prodotto: " + GetProductCode());
            Console.WriteLine("Nome esteso: " + GetExtendedName());
            Console.WriteLine("Codice prodotto compilato: " + GetPaddedCode());
            Console.WriteLine("Descrizione prodotto: " + GetProductDescription());
            PrintBasePrice();
            PrintPriceTotal();
        }

        //Questa funzione permette di modificare il codice prodotto con uno inserito dall'utente.
        //L'input viene sanificato (niente 0, numeri negativi, i numeri con più di 9 cifre) per impedire il set a un codice invalido.
        /*
         * Mi sono accorto dopo che il codice è sola lettura lolololol
        public void SetProductCode(int num)
        {
            if(num <= 0 || num.ToString().Length > 9)
            {
                //Un failsafe che entra in azione se il product code ancora non esiste (generalmente impossibile dato che viene generato nel constructor,
                //ma non si sa mai...). Se l'input è invalido e il product code esiste, termina la funzione senza fare nulla.

                if(productCode == 0)
                {
                    Console.WriteLine("Invalid user input, generating default solution...");
                    productCode = GenerateProductCode();
                } else
                {
                    Console.WriteLine("Invalid user input, skipping command...");
                }
            }
            else
            {
                //Sostituisce il codice con quello dell'utente, e ne crea subito il codice compilato.
                //Scrive in console il codice precedente, per comodità dell'utente.

                Console.WriteLine("Product code reset. Old code was: " + productCode);
                productCode = num;
                productCodeCompiled = GeneratePaddedCode(productCode);
            }
        } */

        //Le funzioni setter permettono di cambiare le proprietà del prodotto.
        //Quelle che lo richiedono fanno anche sanificazione dell'input.
        public void SetProductName(string name)
        {
            this.productName = name;
        }

        public void SetProductDescription(string description)
        {
            this.productDescription = description;
        }

        public void SetProductPriceBase(float priceBase)
        {
            if(priceBase <= 0)
            {
                Console.WriteLine("Products ain't free, bud.");
            }
            else
            {
                this.productPriceBase = priceBase;
            }
        }

        public void SetProductVAT(float newVAT)
        {
            if(newVAT < 0)
            {
                Console.WriteLine("The VAT can't be a negative number.");
            }
            else
            {
                this.productPriceVAT= newVAT;
            }
        }

        //Genera randomicamente un integer da utilizzare come codice base.
        private static int GenerateProductCode()
        {
            Random rnd = new();
            int rndCode = rnd.Next(1, 9999999);

            return rndCode;
        }

        //Ritorna una stringa che consiste del codice base e un padding di 0 a sinistra, se il codice è più corto di 9 cifre.
        private static string GeneratePaddedCode(int code)
        {
            string paddedCode;

            paddedCode = string.Format("{0:000000000}", code);

            return paddedCode;
        }
    }
}
