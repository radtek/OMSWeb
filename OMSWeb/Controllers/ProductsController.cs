﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSWeb.Api.Models.Products;

//using Microsoft.EntityFrameworkCore;
//using OMSWeb.Model;
//using OMSWeb.Data;
using OMSWeb.Data.Access.DAL;
using OMSWeb.Data.Model;
using OMSWeb.Queries.Queries;
using AutoMapper.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsQueryProcessor _query;
        private readonly IMapper _mapper;

        public ProductsController(IProductsQueryProcessor query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        //GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<GetProductModel>> GetProducts()
        {
            var items =
                _mapper.Map<IEnumerable<Product>, List<GetProductModel>>(_query.Get());
            return items;
        }

        //GET: api/product/5
        [HttpGet("{id}")]
        public ActionResult<GetProductModel> GetProduct(int id)
        {
            var product = _mapper.Map<Product, GetProductModel>(_query.Get(id));
            return product;
        }


    }

    //public class ProductsController : ControllerBase
    //{
    //    private readonly NorthwindContext _context;

    //    public ProductsController(NorthwindContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/products
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
    //    {
    //        return await _context.Query<Products>().ToListAsync();
    //    }

    //    //GET: api/product/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Products>> GetProduct(int id)
    //    {
    //        var product = await _context.Products.FindAsync(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return product;
    //    }

    //    // POST: api/products
    //    [HttpPost]
    //    public async Task<ActionResult<Products>> PostProduct(Products item)
    //    {
    //        _context.Products.Add(item);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction(nameof(GetProduct),
    //            new
    //            {
    //                id = item.ProductId,
    //                ProductName = item.ProductName
    //            },
    //            item);
    //    }

    //    // PUT: api/products/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutProduct(int id, Products item)
    //    {
    //        if (id != item.ProductId)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(item).State = EntityState.Modified;
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    // DELETE: api/products/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteProduct(int id)
    //    {
    //        var todoItem = await _context.Products.FindAsync(id);

    //        if (todoItem == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Products.Remove(todoItem);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }
    //}
}