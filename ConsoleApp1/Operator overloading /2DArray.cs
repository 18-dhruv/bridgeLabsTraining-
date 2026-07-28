using System.Globalization;

namespace arrays;

public class Array_2D {

  public static void RectangularAraay(int col, int row)
  {
    int[,] matrix = new int[row, col];
    for (int i = 0; i < row; i++)
    {
      for (int j = 0; j < col; j++)
      {
        Console.WriteLine($" matrix {i}  {j}");
        matrix[i, j] = int.Parse(Console.ReadLine());
      }
    }
    print(matrix);
  }

  public static IList<int> spiral(int[][] matrix)
  {
    List<int>list=new List<int>();
    int top =0;
    int bottom=0;
    int left=matrix[0].Length;
    int y=matrix.Length;
    int i =0;
    int j =0;
    while(top<=bottom){
      while(j<left ){
        list.Add(matrix[i][j]);
        j++;
      }
      j--;
      left--;
      i++;
      while(i<y){
        list.Add(matrix[i][j]);
        i++;
      }
      j--;
      i--;
      Console.WriteLine(bottom);
      while(j>=bottom){
        list.Add(matrix[i][j]);
        j--;
      }
      j++;
      top++;
      // while()
      Console.WriteLine(j);
      Console.WriteLine(i);
      break;
    }
    return list;

  }
  
  
  
  
  public static int[,] RectangularAraaydeep(int[,]matrix)
  {
    int[,] copy = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
      for (int j = 0; j < matrix.GetLength(1); j++)
      {
        Console.WriteLine($" matrix {i}  {j}");
        copy[i, j] = matrix[i,j];
      }
    }
    
    return copy;
  }

  
  public static void print(int[,] matrix)
  {
    int row = matrix.GetLength(0);//row
    int col = matrix.GetLength(1);//col
    for (int i = 0; i < row; i++)
    {
      for (int j = 0; j < col; j++)
      {
        Console.Write($"{matrix[i,j]}");
        Console.Write(" ");
        
      }
      Console.WriteLine();
    }
  }
  
  
  
  
  public static void  matrixIteration()
  {
    int[][] matrix = new int[3][];
    matrix[0] = new int[]{1,2,3};
    matrix[1] = new int[] { 4, 5, 6 };
    matrix[2] = new int[] { 7, 8, 9 };
    for (int i = 0; i < matrix.Length; i++)
    {
      for (int j = 0; j < matrix[0].Length; j++)
      {
        Console.WriteLine($"{i} , {j} = {matrix[i][j]}");
      }
    }
  }
}