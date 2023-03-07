using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable

namespace Lab3
{
    class Vecti
    {
        public double[] Arri { get; private set; }


        public int VecLong => Arri.Length;

        public Vecti()
        {
            Arri = new double[0];
        }

        public Vecti(int size)
        {

            Arri = new double[size];
        }

        public Vecti(double[] arr)
        {
            Arri = (double[])arr.Clone();
        }


        public void InputArr()
        {
            Console.WriteLine("Введите массив вещественных чисел: ");
            for (int i = 0; i < Arri.Length; i++)
            {
                Arri[i] = Convert.ToDouble(Console.ReadLine());
            }
        }


        public override string ToString() => String.Join(" ", Arri);

        public void AppendToVector(double value) => Arri.Append(value);

        public double VecModule()
        {
            double result = 0;
            for (int i = 0; i < Arri.Length; i++)
            {
                result += Arri[i] * Arri[i];
            }
            return Math.Sqrt(result);
        }


        public double VecMax()
        {
            double el = Arri[0];
            for (int i = 0; i < Arri.Length; i++)
            {
                if (el < Arri[i])
                {
                    el = Arri[i];
                }
            }
            return el;
        }

        public int VecMinIndex()
        {
            int min_i = 0;
            for (int i = 0; i < Arri.Length; i++)
            {
                if (Arri[min_i] > Arri[i])
                {
                    min_i = i;
                }
            }
            return min_i;
        }

        public double[] PositiveVec()
        {
            int new_size = 0;
            for (int i = 0; i < Arri.Length; i++)
            {
                if (Arri[i] > 0)
                {
                    new_size++;
                }
            }
            double[] result = new double[new_size];
            int j = 0;
            for (int i = 0; i < Arri.Length; i++)
            {
                if (Arri[i] > 0)
                {
                    result[j] = Arri[i];
                    j++;
                }
            }
            return result;
        }

        public double ReturnValue(int i) => Arri[i];

        public void ChangeValue(int i, double new_value) => Arri[i] = new_value;


        public static double[] DoubleVecSum(double[] arr1, double[] arr2)
        {
            if (arr1 == null || arr2 == null || arr1.Length != arr2.Length) { throw new Exception("Вектора не могут быть использоавны для этой операции"); }
            double[] result = new double[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }
            return result;
        }

        public static double[] DoubleVecSum(Vecti arr1, Vecti arr2)
        {
            if (arr1 == null || arr2 == null || arr1.VecLong != arr2.VecLong) { throw new Exception("Вектора не могут быть использоавны для этой операции"); }
            double[] result = new double[arr1.VecLong];
            for (int i = 0; i < arr1.VecLong; i++)
            {
                result[i] = arr1.ReturnValue(i) + arr2.ReturnValue(i);
            }
            return result;
        }

        public static double ScalarVec(double[] arr1, double[] arr2)
        {
            if (arr1 == null || arr2 == null || arr1.Length != arr2.Length) { throw new Exception("Вектора не могут быть использоавны для этой операции"); }
            double result = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                result += (arr1[i] * arr2[i]);
            }
            return result;
        }

        public static double ScalarVec(Vecti arr1, Vecti arr2)
        {
            if (arr1 == null || arr2 == null || arr1.VecLong != arr2.VecLong) { throw new Exception("Вектора не могут быть использоавны для этой операции"); }
            double result = 0;
            for (int i = 0; i < arr1.VecLong; i++)
            {
                result += (arr1.ReturnValue(i) * arr2.ReturnValue(i));
            }
            return result;
        }

        public static bool Equals(double[] arr1, double[] arr2)
        {
            if (arr1 == null || arr2 == null)
            {
                throw new Exception("Вектора не могут быть использоавны для этой операции");
            }
            bool result = false;
            for (int i = 0; i < arr1.Length; i++)
            {
                result = arr1[i] == arr2[i];
            }
            return result;
        }

        public static bool Equals(Vecti arr1, Vecti arr2)
        {
            if (arr1 == null || arr2 == null)
            {
                throw new Exception("Вектора не могут быть использоавны для этой операции");
            }
            bool result = false;
            for (int i = 0; i < arr1.VecLong; i++)
            {
                result = arr1.ReturnValue(i) == arr2.ReturnValue(i);
            }
            return result;
        }

        public static void VecRandFull(Vecti vector, int left_edge, int right_edge)
        {
            Random rnd = new Random();
            if (vector != null)
            {
                for (int i = 0; i < vector.VecLong; i++)
                {
                    vector.Arri[i] = rnd.Next(left_edge, right_edge - 1);
                }
            }
        }

        public int LinearFindElement(double value)
        {
            for (int i = 0; i < Arri.Length; i++)
            {
                if (Arri[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool IsOrdered() //для каждокого элемента проверка далее массива, нет ли там меньше текущего
        {
            if (Arri.Length == 0) { throw new Exception("Вектор не может быть использоавн для этой операции"); }
            int prev_index = 0;
            for (int i = 0; i < Arri.Length; i++)
            {
                for (int j = prev_index + 1; j < Arri.Length; j++)
                {
                    if (Arri[j] < Arri[prev_index])
                    {
                        return false;
                    }
                }
                prev_index = i + 1;
            }
            return true;
        }

        public int BinSearch(int element) //ищем элемент уменьшая границы, ища середну и сравния элементы с искомым и свигаем границу
        {
            if (!IsOrdered())
            {
                throw new Exception("Массив не упорядочен по возрастанию!");
            }
            int left = -1;
            int right = Arri.Length - 1;
            while (left + 1 < right)
            {
                int mid = (left + right) / 2;
                if (Arri[mid] == element)
                {
                    return mid;
                }
                if (Arri[mid] < element)
                {
                    left = mid;
                    continue;
                }
                right = mid;
            }
            return -1;
        }

        public void Shift()
        {
            if (Arri.Length == 0)
            {
                Arri = new double[1];
                return;
            }
            double[] shiftedArri = new double[Arri.Length + 1];
            Arri.CopyTo(shiftedArri, 1);
            Arri = shiftedArri;
        }

        public bool CheckNegative(int count)
        {
            int counter = 0;
            foreach (var el in Arri)
            {
                if (el < 0)
                {
                    counter++;
                }
            }
            return counter >= count;
        }

        public void SortPyramide()
        {
            if (Arri.Length == 0) { return; }
            int size = Arri.Length;

            for (int i = (size / 2) - 1; i >= 0; i--) //сортируем каждую тройку веток с конца и в верхушку наибольший
            {
                SwapStep(Arri, size, i);
            }

            for (int i = size - 1; i >= 0; i--)     //переставляем элементы с конца на самую верхушку и сортируеи тройку самой верхушки, так с каждым элементом
            {
                double helper = Arri[0];
                Arri[0] = Arri[i];
                Arri[i] = helper;
                SwapStep(Arri, i, 0);
            }


            void SwapStep(double[] arr, int size, int i)
            {
                int largest = i;            /*корень дерева i и высчитываем индексы 2х его потомков, учитывая 
                                             * размер поддерева, сравнение элементов дважды и перестановка наибол и наим, 
                                            * рекурсивный вызов для веток ниже, чтобы проверить корректность перестановки*/
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                if (left < size && arr[left] > arr[largest])
                    largest = left;

                if (right < size && arr[right] > arr[largest])
                    largest = right;

                if (largest != i)
                {
                    double helper = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = helper;

                    SwapStep(arr, size, largest);
                }
            }
        }

    }
}
