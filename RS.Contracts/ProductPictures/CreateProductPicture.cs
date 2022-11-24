﻿using AppFramework.Application;
using Microsoft.AspNetCore.Http;
using RS.Contracts.Products;
using System.ComponentModel.DataAnnotations;

namespace RS.Contracts.ProductPictures;

public class CreateProductPicture
{
    [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
    public long ProductId { get; set; }

    [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
    public IFormFile Picture { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string PictureAlt { get; set; }
    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string PictureTitle { get; set; }
    public List<ProductViewModel> Products { get; set; }
}
