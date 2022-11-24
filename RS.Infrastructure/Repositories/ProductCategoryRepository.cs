﻿using AppFramework.Application;
using AppFramework.Infrastructure;
using RS.Contracts.ProductCategories;
using RS.Domain.Entities.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace RS.Infrastructure.Repositories;

public class ProductCategoryRepository : BaseRepository<long, ProductCategory>, IProductCategoryRepository
{
    private readonly RealStateContext _shopContext;

    public ProductCategoryRepository(RealStateContext context) : base(context)
    {
        _shopContext = context;
    }

    public EditProductCategory GetDetails(long id)
    {
        return _shopContext.ProductCategories
            .Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
    }

    public List<ProductCategoryViewModel> GetProductCategories()
    {
        return _shopContext.ProductCategories.Select(c => new ProductCategoryViewModel
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }

    public string GetSlugById(long id)
    {
        return _shopContext.ProductCategories
            .Select(x => new { x.Id, x.Slug })
            .FirstOrDefault(x => x.Id == id).Slug;
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
    {
        var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            Picture = x.Picture,
            CreationDate = x.CreationDate.ToFarsi()
        });
        if (!string.IsNullOrWhiteSpace(searchModel.Name))
            query = query.Where(x => x.Name.Contains(searchModel.Name));
        return query.OrderByDescending(x => x.Id).ToList();
    }
}
