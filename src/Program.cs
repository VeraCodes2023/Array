// 1

int[] CommonItems(int[][] jaggedArray)
{
    if(jaggedArray ==null || jaggedArray.Length ==0){
        return Array.Empty<int>();
    }
    var commonElements = new HashSet<int>(jaggedArray[0]);
    foreach(int[] subArray in jaggedArray.Skip(1))
    {
     commonElements.IntersectWith(subArray);
    };
    return commonElements.ToArray();
}
int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
int[] arr1Common = CommonItems(arr1);

Console.Write("arr1Common elements are: ");
for(int i=0; i<arr1Common.Length;i++)
{
    Console.Write(arr1Common[i] + " ");
}
Console.WriteLine();


// 2 
void InverseJagged(int[][] jaggedArray)
{
    for( int i=0; i<jaggedArray.Length;i++)
    {
        Array.Reverse(jaggedArray[i]);
    }
}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);

foreach(int[] subArray in arr2)
{
    Console.WriteLine(string.Join(", ", subArray));
}

// 3
void CalculateDiff(int[][] jaggedArray)
{
for (int i = 0; i < jaggedArray.Length; i++)
    {
        int[] subArray = jaggedArray[i];
        int[] diffArray = new int[subArray.Length - 1];

        for (int j = 0; j < subArray.Length - 1; j++)
        {
            diffArray[j] = subArray[j]  - subArray[j + 1];
        }

        jaggedArray[i] = diffArray;
    }
}
int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(arr3);

foreach (int[] subArray in arr3)
{
    Console.WriteLine(string.Join(", ", subArray));
}


// 4
int[,] InverseRec(int[,] recArray)
{
    int rows = recArray.GetLength(0);
    int cols = recArray.GetLength(1);
    int[,] inverseArray = new int [cols,rows];
    for( int row =0; row<rows; row++){
        for(int col=0; col<cols;col++){
            inverseArray[col,row]=recArray[row,col];
        }
    }
   return inverseArray;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);

for (int i = 0; i < arr4Inverse.GetLength(0); i++)
{
    for (int j = 0; j < arr4Inverse.GetLength(1); j++)
    {
        Console.Write(arr4Inverse[i, j] + " ");
    }
    Console.WriteLine();
}

//5
void Demo(params object[] args)
{
    string sentence = "";
    double total = 0;

   foreach( var arg in args)
   {
        if(arg is string str)
        { 
            sentence += str+" ";
        }
        else if(arg is int || arg is double)
        {
            total+= Convert.ToDouble(arg);
        }
   }
    if (!string.IsNullOrEmpty(sentence))
    {
        sentence = sentence.Trim(); // Remove trailing space
        Console.Write(sentence);
    }
   if (!string.IsNullOrEmpty(sentence) && total != 0)
    {
        Console.Write("; ");
    }
    if (total != 0)
    {
        Console.Write(total);
    }
    Console.WriteLine();
    
}
Demo("hello", 1, 2, "world");  //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is"); //should print put "My daughter is; 5"

//6
void SwapTwo(ref object a, ref object b)
{
    if(a.GetType()==b.GetType())
    {
        if(a is string && ((string)a).Length >5 && ((string)b).Length >5)
        {
            object temp = a;
            a=b;
            b=temp;
        }else if(a is int && ((int)a) > 18 && ((int)b)>18)
        {
            object temp = a;
            a=b;
            b=temp;
        }
    }
}

object obj1 = "Hello";
object obj2 = "Vera Chang";
SwapTwo(ref obj1,ref obj2);
Console.WriteLine(obj1);
Console.WriteLine(obj2);

object obj3 = 20;
object obj4 = 30;
SwapTwo(ref obj3,ref obj4);
Console.WriteLine(obj3); // 30
Console.WriteLine(obj4); // 20
Console.WriteLine(obj3); // 30

//7
void GuessingGame()
{
    Random randomNum = new Random();
    int targetNum = randomNum.Next(0,100);
    int gussNum;
    int attemps=0;
    do
    {
        Console.Write("Enter your guess, number should between 0-100: ");
        if(int.TryParse(Console.ReadLine(), out gussNum))
    {
        attemps++;
        if(gussNum < targetNum){
             Console.WriteLine("Try a higher number.");
        }else if(gussNum > targetNum)
        {
            Console.WriteLine("Try a lower number.");
        }else
        {
            Console.WriteLine($"Congratulations! You guessed the number {targetNum} in {attemps} attempts.");
        }
    }else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }while(gussNum !=targetNum);
}

GuessingGame();

//8
var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);


var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
if (subCart != null)
{
 
    foreach (var item in subCart)
    {
        Console.WriteLine(item);
    }
}
else
{
    Console.WriteLine("Invalid range specified.");
}
