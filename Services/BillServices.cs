using asm1_c_sharp.Models;
using asm1_c_sharp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace asm1_c_sharp.Services
{
    public class BillServices : IBillServices
    {
        private readonly ShoppingDbContext _shopContext;

        public BillServices(ShoppingDbContext shopContext)
        {
            _shopContext = shopContext;
        }

        public bool CreateBill(Bill bill)
        {
            try
            {
                bill.Id = Guid.NewGuid();
                bill.CreateDate = DateTime.Now;
                _shopContext.Bills.Add(bill);
                _shopContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var bill = _shopContext.Bills.FirstOrDefault(b => b.Id == id);
                if (bill == null)
                {
                    return false;
                }
                _shopContext.Bills.Remove(bill);
                _shopContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Bill> GetAllBill()
        {
            try
            {
                return _shopContext.Bills.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Bill GetBillById(Guid id)
        {
            try
            {
                return _shopContext.Bills.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        

        public bool UpdateBill(Bill bill)
        {
            try
            {
                var b = _shopContext.Bills.FirstOrDefault(b => b.Id == bill.Id);
                if (b == null)
                {
                    return false;
                }
                b.User = bill.User;
                b.UserID = bill.UserID;
                b.Status = bill.Status;
                b.CreateDate = DateTime.Now;

                _shopContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
