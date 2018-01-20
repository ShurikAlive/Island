using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island
{
    class Product
    {
        private int typeProduct;// 0 - A, 1 - B
        private Firm firmCreator;
        private int quantity;// Количество товара

        public Product(int typeProduct, int quantity, Firm firmCreator)
        {
            this.typeProduct = typeProduct;
            this.firmCreator = firmCreator;
            this.quantity = quantity;
        }

        public int GetTypeProduct()
        {
            return typeProduct;
        }

        public double GetCost()
        {
            double cost = 0.0; // Цена товара до появления фирм на товары

            if (firmCreator != null)
            {
                cost = firmCreator.GetCost(typeProduct);
            }

            return cost;
        }

        public Firm GetFirmCreator()
        {
            return firmCreator;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetTypeProduct(int typeProduct)
        {
            this.typeProduct = typeProduct;
        }

        public void SetFirmCreator(Firm firmCreator)
        {
            this.firmCreator = firmCreator;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public double BayProduct(int quantity)
        {
            this.quantity -= quantity;

            if (firmCreator != null)
            {
                double firmMony = GetCost();// Какое кол во денег ушло фирме с покупки
                firmCreator.AddMony(firmMony);
            }

            return quantity * GetCost();
        }
    }
}
