using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_1
{
    public class MyMatrix
    {
        int rows;
        int cols;
        double[,] matrix;

        public MyMatrix(int r, int c, int a, int b)
        {
            this.matrix = new double[r, c];
            this.rows = r;
            this.cols = c;
            Random random = new Random();
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    this.matrix[i, j] = a+(b-a)*random.NextDouble();
                }
            }
        }

        public void Fill(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = a + (b - a) * random.NextDouble();
                }
            }
        }

        public void ChangeSize(int r, int c)
        {
            Random random = new Random();
            double[,] matrix2 = new double[r, c];
            for (int i = 0; i < Math.Min(rows, r); i++)
            {
                for (int j = 0; j < Math.Min(cols, c); j++)
                {
                    matrix2[i, j] = matrix[i, j];
                }
            }

            for(int i = 0; i< r; i++)
            {
                for( int j = 0; j < c; j++)
                {
                    if(matrix2[i, j] == 0)
                    {
                        matrix2[i, j] = 200*random.NextDouble(); // числа от 0 до 200
                    }
                }
            }

            matrix = matrix2;
            rows = r; cols = c;
            return;
        }

        public void ShowPartialy(int startR, int startC, int endR, int endC)
        {
            for (int i = startR; i <= endR; i++)
            {
                for (int j = startC; j <= endC; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Show()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write numbers start and end range random");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            MyMatrix matrix = new MyMatrix(5, 5, a, b);

            Console.WriteLine("Initial matrix:");
            matrix.Show();

            matrix.ChangeSize(7, 7);

            Console.WriteLine("Matrix after changing size:");
            matrix.Show();

            matrix.Fill(1, 100);

            Console.WriteLine("Matrix after filling with new values:");
            matrix.Show();

            Console.WriteLine("Partial view of the matrix (rows 2-4, columns 1-2):");
            matrix.ShowPartialy(2, 1, 4, 2);

            Console.ReadLine();
        }
    }
}
