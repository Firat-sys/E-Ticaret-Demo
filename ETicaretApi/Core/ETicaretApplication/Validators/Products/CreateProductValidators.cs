using ETicaretApplication.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Validators.Products
{
    public class CreateProductValidators:AbstractValidator<VM_CreateProduct>
    {
        public CreateProductValidators() {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Ürün adını boş geçmeyin.")
                    .MaximumLength(20).MinimumLength(5).WithMessage("Ürünün ismi 20 den büyük veya 2 den küçük olamaz.");

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Lütfen Ürünün stok sayısını boş geçemezsin.");
              RuleFor(p => p.Stock).Must(s=> s >= 0).WithMessage("Ürün  stok bilgisi negatif olamaz");

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Lütfen Ürünün fiyatını boş geçmeyin.");
             RuleFor(p => p.Price).Must(s => s >= 0).WithMessage("Ürünün fiyat bilgisi negatif olamaz");
        }
    }
}
