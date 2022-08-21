//2.Створення продовження задачі
//Створення масивів та їх сортування.
//Написати 3 методи генерації масивів з 100 елементів. 
//Створити три задачі для виклику цих методів. 
//Створити продовження задачі для сортування цих масивів

public partial class SortingMethods
{
    private class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public double Value { get; set; }
        public void Add(double value)
        {
            if (this.Value > value)
            {
                if (this.Left == null)
                {
                    this.Left = new Node { Value = value };
                }
                else
                {
                    this.Left.Add(value);
                }
            }
            else
            {
                if (this.Right == null)
                {
                    this.Right = new Node { Value = value };
                }
                else
                {
                    this.Right.Add(value);
                }
            }
        }
    }


}

