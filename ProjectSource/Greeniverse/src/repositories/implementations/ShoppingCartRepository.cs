
        public List<ShoppingCartModel> GetAllProducts()
        {
            return _context.ShoppingCart.ToList();
        }

        public ShoppingCartModel GetShoppingCartById(int id)
        {
            return _context.ShoppingCart.FirstOrDefault(s => s.Id == id);
        }

        public void NewShoppingCart(NewShoppingCartDTO ShoppingCart)
        {
            _context.ShoppingCart.Add(new ShoppingCartModel
            {
                AmountProduct = ShoppingCart.AmountProduct,
                PaymentMethod = ShoppingCart.PaymentMethod,
                Voucher = ShoppingCart.Voucher,
                DeliveryAdress = ShoppingCart.DeliveryAdress,
            });
            _context.SaveChanges();
        }


    }
}