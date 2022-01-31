using System;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();

            //NEXT

            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };
            Console.WriteLine("Q2");
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();

            //NEXT

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are :{0}", unique_sum);
            Console.WriteLine();

            //NEXT

            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is: {0}", diagSum);
            Console.WriteLine();

            //NEXT

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0};
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is: {0}", rotated_string);
            Console.WriteLine();

            //NEXT

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            Console.WriteLine("Q6:");
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Resultant string are reversing the prefix: {0}", reversed_string);
            Console.WriteLine();
        }

        private static string RemoveVowels(string s)
        {
            try
            {
                // write your code here
                int l = s.Length;//gets the length of the string s
                if (l > 10000)//user defined exceptions
                {
                    throw new MaxLength(l);
                }
                String final_string = "";
                foreach (char z in s)
                {
                    if (z != 'a' && z != 'e' && z != 'i' && z != 'o' && z != 'u' && z != 'A' && z != 'E' && z != 'I' && z != 'O' && z != 'U')//checking for vowels
                    {
                        final_string = final_string + z;
                    }//removes the characters given in the if statement i.e the vowels
                }
                return final_string;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            try
            {
                string b1 = "";
                foreach (string s in bulls_string1)
                {
                    b1 = b1 + s;//All the strings in the first array are concatinated
                }
                string b2 = "";
                foreach (string s in bulls_string2)
                {
                    b2 = b2 + s;//All the strings in the second array are conacatinated
                }
                if (b1 == b2)//Comparison between the both concatinated strings
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static int SumOfUnique(int[] bull_bucks)
        {
            try
            {
                int l = bull_bucks.Length;//length of the string
                int[] x = bull_bucks;
                if (l > 100)//user defined exceptions
                {
                    throw new MaxLength(l);
                }
                foreach(int i in bull_bucks)//user defined exceptions
                {
                    if(i > 100)
                    {
                        throw new MaxValue(i);
                    }
                }
                int[] sample = new int[l];//a new array is created
                int count = 0;
                for (int i = 0; i < l; i++)
                {
                    int n = bull_bucks[i];
                    if (sample.Contains(n))
                    {
                        count = count - n;//elimination of repeating elements
                    }
                    else
                    {
                        count = count + n;//addition of unique elements
                        sample[i] = bull_bucks[i];//addition of all unique elements to the new array
                    }
                }
                return count;
            }
            catch
            {
                throw;
            }
        }
        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {
                // write your code here.
                int l = Convert.ToInt32(Math.Sqrt(bulls_grid.Length));//length and width of the matrix
                int sum = 0;
                for (int i = 0; i < l; i++)//procuring the diagonal elements 
                {
                    for (int j = 0; j < l; j++)
                    {
                        if (i == j)
                        {
                            sum = sum + bulls_grid[i, j];//left diagonal elements are added
                        }
                        else if (i + j == (l - 1))
                        {
                            sum = sum + bulls_grid[i, j];//right diagonal elements are added
                        }
                    }
                }
                return sum;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {
                int l = indices.Length;//length of array
                if (l>100)//user defined exceptions
                {
                    throw new MaxLength(l);
                }
                if (bulls_string.Length != indices.Length)//user defined exceptions
                {
                    throw new NotSame();
                }
                if (bulls_string.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Upper();
                }
                if (indices.Distinct().Count() != indices.Length)//user defined exceptions
                {
                    throw new Repeat();
                }
                foreach(int i in indices)
                {
                    if(i > bulls_string.Length)
                    {
                        throw new OutOflength();
                    }
                }
                string result = "";
                for (int i = 0; i < l; i++)
                {
                    int n = Array.IndexOf(indices, i);//index value from indices
                    result = result + bulls_string[n];//char from the bull_string is added to the final string at the index
                }
                return result;//return string
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String prefix_string = "";
                int l = bulls_string6.Length;//length of string
                if (bulls_string6.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Upper();
                }
                if (l > 250)//user defined exceptions
                {
                    throw new MaxLength(l);
                }
                int n = bulls_string6.IndexOf(ch, 0, l);//index of the input char
                for (int i = n; i >= 0; i--)
                {
                    prefix_string = prefix_string + bulls_string6[i];//reverse part of the string is concatinated
                }
                for (int i = n + 1; i < l; i++)
                {
                    prefix_string = prefix_string + bulls_string6[i];//remaining part of string is concatinated
                }
                return prefix_string;//return string
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
[Serializable]
public class MaxLength : Exception
{
    public MaxLength(int l) {
        Console.WriteLine("Lenght of input string should be less than "+ l);
    }
}
public class MaxValue : Exception
{
    public MaxValue(int i)
    {
        Console.WriteLine("Value of the input should not exceed 100, current value: "+ i);
    }
}
public class Upper : Exception
{
    public Upper()
    {
        Console.WriteLine("Input string contains Upper case letter");
    }
}

public class Repeat : Exception
{
    public Repeat()
    {
        Console.WriteLine("All the values in indices array should be unique");
    }
}

public class NotSame : Exception
{
    public NotSame()
    {
        Console.WriteLine("Indices length and bull_string length are not same");
    }
}
public class OutOflength : Exception
{
    public OutOflength()
    {
        Console.WriteLine("Value in indices is exceeding the number of characters in the string");
    }
}
