class OrderItem : Product
{
    public int Quantity { get; set; }

    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
    }

    /* Override ToString() method so the item can be printed out conveniently with Id, Price, and Quantity */
    public override string ToString()
    {
        return $"Id:{Id}, Price:{Price}, Quantity:{Quantity}";
    }
}
