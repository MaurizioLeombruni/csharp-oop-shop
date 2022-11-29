//Esercizio

using CSharpShop;

Product lavatrice = new("Valatrice", "Una lavatrice, ma al contrario.", 250);
Product microonde = new("Cuociferro", "Cuoce anche i metalli! (Just kidding it doesn't)", 100);
Product forno = new("Appedali", "Si, è un forno a pedali. Fattene una ragione.", 3500);
Product qualcosa = new("Qualcosa", "Nessuno ha mai spiegato cos'è sta roba.", 20);

Product exampleProduct = new("Prodotto", "Questa è una descrizione", 50);

List<Product> electronicsShop = new()
{
    lavatrice,
    microonde,
    forno,
    qualcosa
};

//Stampa in ordine i nomi dei prodotti di un negozio di elettronica di dubbia qualità.

foreach (Product product in electronicsShop)
{
    Console.WriteLine(product.GetProductName());
}

//Stampo un prodotto e poi ne modifico alcune proprietà.

Console.WriteLine("Stampo un prodotto esempio: ");
exampleProduct.PrintProductDetails();

Console.WriteLine("Cambio un po' di cose con i metodi e ristampo: ");
exampleProduct.SetProductDescription("Descrizione cambiata");
exampleProduct.SetProductName("Nomignolo");
exampleProduct.SetProductPriceBase(100);
exampleProduct.SetProductVAT(0.18f);

exampleProduct.PrintProductDetails();
