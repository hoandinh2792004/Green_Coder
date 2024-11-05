﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_bestcoder.Areas.Admin.Models;
using Web_bestcoder.Areas.Admin.ViewModels;
using Web_bestcoder.Data; // Assuming this is your DbContext namespace

namespace Web_bestcoder.Areas.Admin.Controllers
{
    [Area("Admin")]
<<<<<<< HEAD

    public class QuanLySanPham : Controller
=======
    public class QuanLySanPhamController : Controller
>>>>>>> d6d01be3197c6e58492f99b63f7258d16b832c53
    {
        private readonly GreenCoderContext _context; // Replace with your actual DbContext

        public QuanLySanPhamController(GreenCoderContext context) // Constructor for Dependency Injection
        {
            _context = context;
        }

        // GET: /Admin/QuanLySanPham/
        public IActionResult Index()
        {
            // Fetch the product data from your data source, for example:
            var products = _context.Products.ToList();

            // Map to ProductViewModel
            var productViewModels = products.Select(product => new ProductViewModel
            {
                Product = product,
               
            }).ToList();
            // Pass the correctly typed model to the view
            return View(products);
        }


        // GET: /Admin/QuanLySanPham/ThemSanPham
        public IActionResult ThemSanPham()
        {
            var viewModel = new ProductViewModel
            {
                ProductCategories = _context.ProductCategories.ToList(),
                Suppliers = _context.Suppliers.ToList(),
                Product = new Product() // Initialize a new product instance
            };

            return View(viewModel); // Pass the view model to the view
        }

        // POST: /Admin/QuanLySanPham/ThemSanPham
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public async Task<IActionResult> ThemSanPham(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                

                Product product = new Product
                {
                    ProductId = model.Product.ProductId,
                    ProductName = model.Product.ProductName,
                    SellingPrice = model.Product.SellingPrice,
                    CostPrice = model.Product.CostPrice,
                    Image = model.Product.Image,
                    Description = model.Product.Description,
                    Quantity = model.Product.Quantity,
                    Status = model.Product.Status,
                    CategoryId = model.Product.CategoryId,
                    SupplierId = model.Product.SupplierId,
                };

                // Save the new product to the database
                _context.Products.Add(product);
               await _context.SaveChangesAsync();
                return RedirectToAction("Index"); // Redirect to the product list
            }

            // If validation fails, reload categories and suppliers
            model.ProductCategories = _context.ProductCategories.ToList();
            model.Suppliers = _context.Suppliers.ToList();
            return View(model);
        }

        // GET: /Admin/QuanLySanPham/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id); // Find the product by ID
            if (product == null)
            {
                return NotFound(); // Return 404 if the product does not exist
            }

            var viewModel = new ProductViewModel
            {
                Product = product,
                ProductCategories = _context.ProductCategories.ToList(),
                Suppliers = _context.Suppliers.ToList()
            };

            return View(viewModel); // Pass the view model to the edit view
        }

        // POST: /Admin/QuanLySanPham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Update the existing product in the database
                _context.Products.Update(model.Product);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the product list
            }

            // If validation fails, reload categories and suppliers
            model.ProductCategories = _context.ProductCategories.ToList();
            model.Suppliers = _context.Suppliers.ToList();
            return View(model);
        }

        // GET: /Admin/QuanLySanPham/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if the product does not exist
            }

            return View(product); // Pass the product to the delete view
        }

        // POST: /Admin/QuanLySanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product); // Remove the product from the database
                _context.SaveChanges();
            }

            return RedirectToAction("Index"); // Redirect to the product list
        }

        // GET: /Admin/QuanLySanPham/ThemDanhMuc
        public IActionResult ThemDanhMuc()
        {
            return View(); // Show the view for adding a category
        }

        // POST: /Admin/QuanLySanPham/ThemDanhMuc
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public IActionResult ThemDanhMuc(Data.ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.ProductCategories.Add(category); // Add the new category to the database
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the product list
            }

            return View(category); // Return the view with the model if validation fails
        }

        // GET: /Admin/QuanLySanPham/ThemNhaCungCap
        public IActionResult ThemNhaCungCap()
        {
            return View(); // Show the view for adding a supplier
        }

        // POST: /Admin/QuanLySanPham/ThemNhaCungCap
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public IActionResult ThemNhaCungCap(Data.Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier); // Add the new supplier to the database
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the product list
            }

            return View(supplier); // Return the view with the model if validation fails
        }

        // Similar methods can be created for managing categories and suppliers
    }
}
