using _01_Framework.Domain;
using DiscountManagment.Application.Contract.CollegueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagment.Domain.CollegueDiscount
{
    public interface ICollegueDiscountRepository:IRepository<long,CollegueDiscount>
    {
        EditCollegueDiscount? GetDetails(long id);
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel);
    }
}
