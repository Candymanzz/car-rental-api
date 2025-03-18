namespace server.Exceptions;

public sealed class CarNotFoundException : NotFoundException
{
    public CarNotFoundException() : base() { }
    public CarNotFoundException(string message) : base(message) { }
    public CarNotFoundException(string message, Exception inner) : base(message, inner) { }
}

public sealed class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException() : base() { }
    public CustomerNotFoundException(string message) : base(message) { }
    public CustomerNotFoundException(string message, Exception inner) : base(message, inner) { }
}

public sealed class RentalNotFoundException : NotFoundException
{
    public RentalNotFoundException() : base() { }
    public RentalNotFoundException(string message) : base(message) { }
    public RentalNotFoundException(string message, Exception inner) : base(message, inner) { }
}

public sealed class PaymentNotFoundException : NotFoundException
{
    public PaymentNotFoundException() : base() { }
    public PaymentNotFoundException(string message) : base(message) { }
    public PaymentNotFoundException(string message, Exception inner) : base(message, inner) { }
}

public sealed class ReviewNotFoundException : NotFoundException
{
    public ReviewNotFoundException() : base() { }
    public ReviewNotFoundException(string message) : base(message) { }
    public ReviewNotFoundException(string message, Exception inner) : base(message, inner) { }
}