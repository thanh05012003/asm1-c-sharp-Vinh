using asm1_c_sharp.Models;
using asm1_c_sharp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace asm1_c_sharp.Services
{
    public class BillDetailsServices : IBillDetailsServices
    {
        ShoppingDbContext _shopDbContext;

        public bool CreateBillDetails(BillDetail billdt)
        {
            try
            {
                billdt.ID = Guid.NewGuid();
                _shopDbContext.BillDetails.Add(billdt);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteBillDetails(Guid id)
        {
            try
            {
                var billdt = _shopDbContext.BillDetails.FirstOrDefault(p => p.ID == id);
                _shopDbContext.BillDetails.Remove(billdt);
                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<BillDetail> GetAllBillDetails()
        {
            try
            {
                return _shopDbContext.BillDetails.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        

        public List<BillDetail> GetAllBillDetailsId()
        {
            try
            {
                return _shopDbContext.BillDetails.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateBillDetails(BillDetail billdt)
        {
            try
            {
                var b = _shopDbContext.BillDetails.FirstOrDefault(b => b.ID == billdt.ID);
                if (b == null)
                {
                    return false;
                }
                b.Price = billdt.Price;
                b.Quantity = billdt.Quantity;
                b.Bill = billdt.Bill;
                b.BillID = billdt.BillID;
                b.Product = billdt.Product;
                b.ProductID = billdt.ProductID;
               

                _shopDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
