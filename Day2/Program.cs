using System;
using System.Linq;
class Employee
{
    static int count = 0;
    public Employee(string name="John", decimal basic = 10000, short deptNo = 10)
    {
        count++;
        empNo = count;
        this.name = name;
        this.deptNo = deptNo;
        this.basic = basic;
    }
    private string name;
    public string Name
    {
        set
        {
             name = String.Concat(value.Where(x => !Char.IsWhiteSpace(x)));
        }
        get
        {
            return name;
        }
    }
    public int empNo
    { set; get; }
    private decimal basic;
    public decimal Basic
    {
        set
        {
            if(value >= 10000 && value <= 50000)
            {
                this.basic = value;
            }
            else
            {
                Console.WriteLine("Invalid basic entry");
            }
        }
        get
        {
            return basic;
        }
    }
    private short deptNo;
    public short DeptNo
    {
        set
        {
           if(deptNo > 0)
            {
                this.deptNo =value;
            }
        }
        get
        {
            return deptNo;
        }
    }
    
}
class MainClass
{
    static void Main(string[] args)
    {
        Employee e = new Employee();
        Employee e1 = new Employee();
        Employee e2 = new Employee("Alex",12345,10);
        Employee e3 = new Employee("Brad", 654321);
        Employee e4 = new Employee("Chloe");
        Console.WriteLine(e.empNo);
        Console.WriteLine(e1.empNo);
        Console.WriteLine(e2.empNo);
        Console.WriteLine(e3.empNo);
        Console.WriteLine(e3.DeptNo);
        Console.WriteLine(e4.Basic);
    }
}
