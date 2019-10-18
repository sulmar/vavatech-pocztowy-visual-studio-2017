## Skróty klawiszowe Visual Studio 2017

### Testy integracyjne

https://docs.microsoft.com/pl-pl/aspnet/core/test/integration-tests?view=aspnetcore-3.0


### Edytor

| Skrót  | Opis  |
|---|---|
| Ctrl + .  | Wyświetlenie menu refaktoringu  |
| Ctrl + Spacja  | Wyświetl podpowiedzi IntelliSense   |
| Ctrl + Shift + Spacja  | Wyświetl parametry metody   |
| Ctrl-K + Ctrl-C  | Zakomentuj zaznaczony blok |
| Ctrl-K + Ctrl-U  | Odkomentuj zaznaczony blok |
| Ctrl-K + Ctrl- F  | Formatowanie kodu w zaznaczonym bloku |
| Ctrl-K + Ctrl- D  | Formatowanie kodu w całym pliku |
| Ctrl-K + Ctrl-S  | Otocz zaznaczany blok wybraną dyrektywą |
| F12  | Idź do definicji  |
| Alt + F12  | Pokaż definicję ale bez wchodzenia  |
| Ctrl-L | Usuń zaznaczony kod  |
| Ctrl-R + Ctrl + G| Usuń nieużywane przestrzenie nazw |
| Shift + Alt + kursor | Pisanie wielu linii jednocześnie |
| Ctrl-E + Ctrl + V| Zduplikowanie linii kodu |
| Ctrl-]| Skok na początek lub koniec nawiasu  |

### Debugger

| Skrót  | Opis  |
|---|---|
| Ctrl + Shift + B  | Zbudowanie projektu  |
| F5  | Uruchom z debuggowaniem  |
| Ctrl + F5  | Uruchom bez debuggowania  |
| F10 | Wykonaj krok |
| F11 | Wykonaj krok i wejdź |
| F9   | Dodaj lub usuń pułapkę  |
| Ctrl + F9  | Wyłącz pułapkę  |
| Ctrl + Shift + F9  | Usuń wszystkie pułapki  |


## Promocje



1. "Trzeci produkt gratis"
- wszystkie produkty sa takie same
- co 3 produkt gratis

2. "Każdy piątek"
- w kazdy piatek
- 50% taniej


3. Happy Hours
- jesli pomiedzy 9 - 17 i wartosc zakupow powyzej 100
- 10 zl taniej 


## Skrypty
- z użyciem Roslyn
https://github.com/dotnet/roslyn/wiki/Scripting-API-Samples#delegate

## Testy jednostkowe

### NUnit

Utworzenie projektu

~~~ bash
dotnet new nunit
~~~

Przykładowa klasa

~~~ csharp
public class Calculator
{
    public int Add(int x, int y) => x + y;
}
~~~


#### Test
~~~ csharp

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
         var calculator = new Calculator();

        var result = calculator.Add(2, 2);

        Assert.AreEqual(4, result);
    }
}
~~~

#### Wyjątki

~~~ csharp
[ExpectedException(typeof(ArgumentNullException)]
[TestMethod]
public void ExceptionTest()
{
    // Arrange
    Order order = null;

    IOrderCalculator orderCalculator = new MyOrderCalculator();

    // Act
    Action act = () => orderCalculator.CalculateDiscount(order);

}
~~~

### xUnit

Utworzenie projektu

~~~ bash
dotnet new xunit
~~~

Przykładowa klasa

~~~ csharp
public class Calculator
{
    public int Add(int x, int y) => x + y;
}
~~~

#### Fakt

~~~ csharp
[Fact]
    public void Test1()
    {
        var calculator = new Calculator();

        int result = calculator.Add(2, 2);

        Assert.Equal(4, result);

    }
~~~

#### Teoria - inlinedata

~~~ csharp
[Theory]
[InlineData(1, 2, 3)]
[InlineData(-4, -6, -10)]
[InlineData(-2, 2, 0)]
[InlineData(int.MinValue, -1, int.MaxValue)]
public void CanAddTheory(int value1, int value2, int expected)
{
    var calculator = new Calculator();
    var result = calculator.Add(value1, value2);
    Assert.Equal(expected, result);
}
~~~


#### Teoria - classdata

~~~ csharp
public class CalculatorTestData : TheoryData<int, int, int>
{
    public CalculatorTestData()
    {
        Add(1, 2, 3);
        Add(-4, -6, -10);
        Add(-2, 2, 0);
        Add(int.MinValue, -1, int.MaxValue);
        
    }
}

[Theory]
[ClassData(typeof(CalculatorTestData))]
public void CanAdd(int value1, int value2, int expected)
{
    var calculator = new Calculator();
    var result = calculator.Add(value1, value2);
    Assert.Equal(expected, result);
}
~~~


#### Teoria - memberdata


~~~ csharp

public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
        };

[Theory]
  [MemberData(nameof(Data))]
  public void CanAddTheoryMemberDataProperty(int value1, int value2, int expected)
  {
      var calculator = new Calculator();

      var result = calculator.Add(value1, value2);

      Assert.Equal(expected, result);
  }
~~~


#### Wyjątki

~~~ csharp
[Fact]
public void ExceptionTest()
{
    // Arrange
    Order order = null;

    IOrderCalculator orderCalculator = new MyOrderCalculator();

    // Act
    Action act = () => orderCalculator.CalculateDiscount(order);

    // Assert
    Assert.Throws<ArgumentNullException>(act);  
}
~~~

~~~ csharp
[Fact]
public void ExceptionTest()
{
    // Arrange
    Order order = null;

    IOrderCalculator orderCalculator = new MyOrderCalculator();

    // Act and Assert
    Assert.Throws<ArgumentNullException>(()=>orderCalculator.CalculateDiscount(order));
 
}
~~~



### FluentAssertions

Instalacja biblioteki
~~~ bash
 dotnet add package FluentAssertions
 ~~~

#### Analiza wyniku

 ~~~ csharp
[Fact]
public void CustomerTest()
{
    // Arrange
    Customer customer = new Customer("John", "Smith");

    // Act
    var result = customer.FullName;

    // Assert
    result
        .Should()
        .StartWith("John")
        .And
        .EndWith("Smith");


}
~~~


~~~ csharp
 [Fact]
public void CalculateTest()
{
    // Arrange
    var order = new Order
    {
        TotalAmount = 1000
    };

    IOrderCalculator orderCalculator = new MyOrderCalculator();

    // Act
    var result = orderCalculator.CalculateDiscount(order);

    // Assert
    result.Should().Be(1000);


}
~~~

#### Wyjątki

~~~ csharp
[Fact]
public void ExceptionTest()
{
    // Arrange
    Order order = null;

    IOrderCalculator orderCalculator = new MyOrderCalculator();

    // Act
    Action act = () => orderCalculator.CalculateDiscount(order);

    // Assert
    act
        .Should()
        .Throw<ArgumentNullException>();
}
~~~

#### Czas wykonania

~~~ csharp
[Fact]
public void CalculateTest()
{
    // Arrange
    var order = new Order
    {
        TotalAmount = 1000
    };

    IOrderCalculator orderCalculator = new DiscountOrderCalculator();

    // Act
    orderCalculator
        .ExecutionTimeOf(s => s.CalculateDiscount(order))
        .Should()
        .BeLessOrEqualTo(500.Milliseconds());

   // ekwiwalent
    Action act = () => orderCalculator.CalculateDiscount(order);

    act
    .ExecutionTime()
    .Should()
    .BeLessOrEqualTo(500.Milliseconds());
}
~~~

#### Operacje asynchroniczne

~~~ csharp
[Fact]
public void SendAsyncTest()
{
    // Arrange
    ISender sender = new EmailSender();

    // Act
    Func<Task> act = () => sender.SendAsync();

    // Assert
    act
        .Should()
        .CompleteWithinAsync(500.Milliseconds());

}
~~~


~~~ csharp
[Fact]
public void CalculateAsyncTest()
{
    // Arrange
    var order = new Order
    {
        TotalAmount = 1000
    };

    IOrderCalculator orderCalculator = new MyOrderCalculator();


    // Act
    Func<Task<decimal>> act = () => orderCalculator.CalculateDiscountAsync(order);

    // Assert
    // add using FluentAssertions.Extensions
    act
        .Should()
        .CompleteWithin(500.Milliseconds())
        .Which
        .Should()
        .Be(1000);
}
~~~


