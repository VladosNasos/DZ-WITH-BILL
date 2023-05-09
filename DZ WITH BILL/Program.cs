using System;

struct Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }

    public double TotalCost()
    {
        return (Price - Discount) * Quantity;
    }
}

struct Receipt
{
    public Item[] Items { get; set; }

    public double TotalCost()
    {
        double total = 0;

        foreach (Item item in Items)
        {
            total += item.TotalCost();
        }

        return total;
    }

    public void Print()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("-------------------------------");
        Console.WriteLine("|        MY STORE RECEIPT     |");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("| Name         | Qty |  Price |");
        Console.WriteLine("-------------------------------");

        foreach (Item item in Items)
        {
            Console.WriteLine($"| {item.Name,-12} | {item.Quantity,3} | {item.Price,6:F2} |");
        }

        Console.WriteLine("-------------------------------");
        Console.WriteLine($"| Total Cost:   {TotalCost(),13:F2} |");
        Console.WriteLine("-------------------------------");
        Console.ResetColor();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Item item1 = new Item { Name = "Product 1", Quantity = 2, Price = 10.50, Discount = 1.50 };
        Item item2 = new Item { Name = "Product 2", Quantity = 1, Price = 5.00, Discount = 0 };

        Receipt myReceipt = new Receipt { Items = new Item[] { item1, item2 } };

        myReceipt.Print();
    }
}