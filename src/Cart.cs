class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    /* Write indexer property to get nth item from _cart */
        public OrderItem? this[int index]
        {
            get
            {
                if(index >=0 && index < _cart.Count)
                {
                    return _cart[index];
                }
                return null;
            }
        }
         
    /* Write indexer property to get items of a range from _cart */
    public List<OrderItem>? this[int start, int end]
    {
        get
        {
            if(start >=0 && end <_cart.Count && start <=end)
            {
                return _cart.GetRange(start, end-start);
            }
            return null;
        }
    }

    public void AddToCart(params OrderItem[] items)
    {
        /* this method should check if each item exists --> increase value / or else, add item to cart */
       foreach( var item in items)
       {
            var existingItem = _cart.Find(i=> i.Id == item.Id);
            if(existingItem ==null)
            {
                _cart.Add(item);
            }else
            {
                existingItem.Quantity++;
            }
       }
    }
    /* Write another method called Index */
    public string? Index(int index)
    {
        var item = this[index];
        if(item ==null){
            return "Item not found";
        }else
        {
            return item.ToString();
        }
    }

    /* Write another method called GetCartInfo(), which out put 2 values: 
    total price, total products in cart*/
    
    public void GetCartInfo(out int totalPrice, out int totalProducts)
    {
        totalPrice= _cart.Sum(item=>item.Price * item.Quantity);
        totalProducts=_cart.Count;
    }

    /* Override ToString() method so Console.WriteLine(cart) can print
    id, unit price, unit quantity of each item*/

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _cart.Select(item=>item.ToString()));
    }

}

