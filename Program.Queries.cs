﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkingWithEFCore;

partial class Program
{
    static void QueryingCategories()
    {
        using(Northwind db = new Northwind())
        {
            SectionTitle("Categories and how many products they have:");

            //a query to get all categories and their related products
            IQueryable<Category>? categories = db.Categories?
                .Include(c => c.Products);

            if((categories is null) || (!categories.Any()))
            {
                Fail("No categories found.");
                return;
            }

            // execute query and enumerate results
            foreach(Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            }
        }

        
    }
    static void QueryingCategoriesWithStock()
    {
        using (Northwind db = new())
        {
            SectionTitle("Products with a minimun number of units");

            string? input;
            int stock;

            do
            {
                Write("Enter a minimum for units of stock: ");
                input = ReadLine();
            } while (!int.TryParse(input, out stock));

            IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));

            if ((categories is null) || (!categories.Any()))
            {
                Fail("No categories found.");
                return;
            }
            foreach (Category c in categories)
            {
                WriteLine(
                    $"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock}units in stock.");

                foreach (Product p in c.Products)
                {
                    WriteLine(
                        $"  {p.ProductName} has {p.Stock} units in stock.");

                }
            }
        }
    }
    static void QueryingProducts()
    {
        using(Northwind db = new())
        {
            SectionTitle("Products that cost more than a pice, highest at the top");

            string? input;
            int price;

            do
            {
                Write("Enter a product price: ");
                input = ReadLine();
            } while (!int.TryParse(input, out price));

            IQueryable<Product>? products = db.Products?.Where(product => product.Cost > price).OrderByDescending(product => product.Cost);
            if ((products is null) || (!products.Any()))
            {
                Fail("No products found.");
                return;
            }
            Info($"ToQueryString: {products.ToQueryString()}");
            foreach (Product p in products)
            {
                WriteLine(
                "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
                p.ProductId, p.ProductName, p.Cost, p.Stock);
            }
        }
    }
}
