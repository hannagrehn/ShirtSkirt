using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace ShirtSkirt.Repositories
{
    public class ProductRepo(DataContext context) : BaseRepo<ProductEntity>(context)
    {
        private readonly DataContext _context;

        public override IEnumerable<ProductEntity> GetAll()
        {

            try
            {
                return _context.Products
                    .Include(x => x.ManufactureEntity)
                    .Include(x => x.DescriptionEntity)
                    .Include(x => x.ReviewEntity)
                    .Include(x => x.PricelistEntity)
                    .Include(x => x.CategoryEntity)
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return new List<ProductEntity>();
            }
        }

        public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
        {
            try
            {
                return _context.Products
                    .Include(x => x.ManufactureEntity)
                    .Include(x => x.DescriptionEntity)
                    .Include(x => x.ReviewEntity)
                    .Include(x => x.PricelistEntity)
                    .Include(x => x.CategoryEntity)
                    .FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return null!;
            }
        }
    }
}
