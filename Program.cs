
using Lab3;


double[] arr1 = new double[5];
for (int i = 0; i < 5; i++)
{
    arr1[i] = i * 4;
}
Vecti vec1 = new Vecti(arr1);
Vecti vec2 = new Vecti(5);
vec2.InputArr();


Console.WriteLine($"Вектор 1 в строку: {vec1.ToString()}");


double module = vec1.VecModule();
Console.WriteLine($"\nМодуль вектора 1 = {module}");


Console.WriteLine($"\nНаибольший элемент вектора 2 = {vec2.VecMax()}");


int index = vec1.VecMinIndex();
Console.WriteLine($"\nИндекс наименьшего элемента вектора 1 = {index}");


Vecti vec3 = new Vecti(vec2.PositiveVec());
Console.WriteLine($"\nНовый вектор 2, состоящий из положительных элементов: {vec3.ToString()}");


Vecti sum = new Vecti(Vecti.DoubleVecSum(vec1, vec2));
Console.WriteLine($"\nСумма векторов 1 и 2: {sum.ToString()}");


double scalar = Vecti.ScalarVec(vec1, vec2);
Console.WriteLine($"\nСкалярное произведение векторов 1 и 2 = {scalar}");


Console.WriteLine($"\nИтог проверки векторов 1 и 2 на равеноство = \"{Vecti.Equals(vec1, vec2)}\"");


Console.WriteLine($"Введите индекс элемента из 1 вектора:");
int ii = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"\nЗначение элемента в векторе 1 под индексом {ii} = {vec1.ReturnValue(ii)}");


vec1.ChangeValue(0, 1000);
Console.WriteLine($"\nВектор 1, где первый элемент теперь равен 1000: {vec1.ToString()}");


Vecti vec4 = new Vecti(7);
Console.WriteLine("\nВведите левую и правую границу для заполнения вектора рандомными числами: ");
int a = Convert.ToInt32(Console.ReadLine());
int b = Convert.ToInt32(Console.ReadLine());
Vecti.VecRandFull(vec4, a, b);
Console.WriteLine($"\nВектор рандомных значений: {vec4.ToString()}");


Console.WriteLine("\nВведите искомое значение в векторе 4:");
double el = Convert.ToDouble(Console.ReadLine());
int res = vec4.LinearFindElement(el);
if (res == -1)
{
    Console.WriteLine("\nЭлемент не найден");
}
else
{
    Console.WriteLine($"\nИндекс искомого элемента в векторе = {res}");
}


Console.WriteLine("\nВведите искомое значение в векторе 4:");
int ell = Convert.ToInt32(Console.ReadLine());
vec4.SortPyramide();
int result = vec4.BinSearch(ell);
if (result == -1)
{
    Console.WriteLine("\nЭлемент не найден");
}
else
{
    Console.WriteLine($"\nИндекс искомого элемента в отсортированном по возростанию векторе = {result}");
}


vec4.Shift();
Console.WriteLine($"\nВектор 4 со сдвигом: {vec4.ToString()}");


Console.WriteLine("\nВведите кол-во отрицательных элементов, необходимых для содержания в векторе 2:");
int num = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"\nИтог проверки на наличие необходимого кол-ва отрицательных элементов в векторе 2 = \"{vec2.CheckNegative(num)}\"");


vec1.SortPyramide();
Console.WriteLine($"\nВектор 1 отсортированный пирамидной сортировкой: {vec1}");









