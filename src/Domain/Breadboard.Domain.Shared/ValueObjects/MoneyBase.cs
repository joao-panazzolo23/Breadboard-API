namespace Breadboard.Shared.Entities;

//Todo: make a struct for using money base on NodaMoney
public readonly struct MoneyBase
{
    //private Money Value { get; }

    ////todo: this variable could be set in appsettings.json and achieved through IConfiguration DI
    //public MoneyBase(decimal amount, string code = "pt-BR")
    //{
    //    Value = new Money(amount, code);
    //}

    //public static MoneyBase operator +(MoneyBase a, MoneyBase b)
    //    => new MoneyBase(a.Value.Amount + b.Value.Amount);
}