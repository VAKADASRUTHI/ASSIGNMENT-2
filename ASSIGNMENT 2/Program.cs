using System;
using System.Collections.Generic;

namespace INVENTORYMANAGEMENTSYSTEM
{

    class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Item(int id, string name, decimal price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Display()
        {
            Console.WriteLine($"Name:   {Name},  Price:    ₹{Price:C},    Quantity:{Quantity}");
        }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
    }


    class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine("Item added successfully.");
        }

        public void DisplayAllItems()
        {
            foreach (Item item in items)
            {
                item.Display();
            }
        }

        public Item FindItemById(int id)
        {
            return items.Find(item => item.ID == id);
        }

        public void UpdateItem(int id, decimal newPrice, int newQuantity)
        {
            Item itemToUpdate = FindItemById(id);
            if (itemToUpdate != null)
            {
                itemToUpdate.UpdatePrice(newPrice);
                itemToUpdate.UpdateQuantity(newQuantity);
                Console.WriteLine("Item updated successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void DeleteItem(int id)
        {
            Item itemToDelete = FindItemById(id);
            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();


            inventory.AddItem(new Item(1, "BATTERIES", 32000, 6));
            inventory.AddItem(new Item(2, "IPHONES  ", 83645, 1));
            inventory.AddItem(new Item(3, "COMPUTER ", 54656, 2));
            inventory.AddItem(new Item(4, "LAPTOPS  ", 32478, 1));


            Console.WriteLine("All Items:");
            inventory.DisplayAllItems();


            Console.WriteLine("\nUpdating item 'TV':");
            inventory.UpdateItem(1, 35000m, 7);
            inventory.DisplayAllItems();


            Console.WriteLine("\nDeleting item 'COMPUTER':");
            inventory.DeleteItem(3);
            inventory.DisplayAllItems();
        }
    }
}
