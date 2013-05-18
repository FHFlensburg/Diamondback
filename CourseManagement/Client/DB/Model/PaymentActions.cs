using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the PaymentModel
    /// </summary>
    public partial class Payment
    {
        public static List<Payment> getAll()
        {
            try
            {
                return PaymentQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void addToDB()
        {
            try
            {
                PaymentQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Payment getById(int paymentId)
        {
            try
            {
                return PaymentQuery.getById(paymentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void delete()
        {
            try
            {
                PaymentQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
